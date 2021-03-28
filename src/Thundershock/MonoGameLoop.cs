﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Thundershock.Config;
using Thundershock.Debugging;
using Thundershock.Input;

namespace Thundershock
{
    public class MonoGameLoop : Game
    {
        private static MonoGameLoop _instance;
        
        public static MonoGameLoop Instance
            => _instance;

        private App _app;
        private PostProcessor _postProcessor;
        private RenderTarget2D _renderTarget;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _white;
        private Scene _activeScene;
        private ContentManager _thundershockContent;
        
        public Texture2D White => _white;
        
        public PostProcessor.PostProcessSettings PostProcessSettings => _postProcessor.Settings;
        
        public SpriteBatch SpriteBatch => _spriteBatch;

        public int ScreenWidth
            => GraphicsDevice.PresentationParameters.BackBufferWidth;
        
        public int ScreenHeight
            => GraphicsDevice.PresentationParameters.BackBufferHeight;

        public ContentManager EngineContent
            => _thundershockContent;
        
        internal MonoGameLoop(App app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));
            _app.Logger.Log("Bootstrapping MonoGame...");
            _instance = this;
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _thundershockContent = new ContentManager(this.Services);
            _thundershockContent.RootDirectory = "ThundershockContent";
        }
        
        public void LoadScene(Scene scene)
        {
            if (scene == null)
                throw new ArgumentNullException(nameof(scene));

            if (_activeScene != null)
                _activeScene.Unload();

            _activeScene = scene;
            scene.Load(_app, this);
        }
        
        public void LoadScene<T>() where T : Scene, new()
        {
            var scene = new T();
            LoadScene(scene);
        }

        private void AllocateRenderTarget()
        {
            // clean up the old render target.
            if (_renderTarget != null)
            {
                _app.Logger.Log("Disposing the old game render target...");
                _renderTarget.Dispose();
                _renderTarget = null;
            }

            // re-allocate the render target
            _renderTarget = new RenderTarget2D(GraphicsDevice, ScreenWidth, ScreenHeight, false,
                GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.None, 0,
                RenderTargetUsage.PreserveContents);
            _app.Logger.Log($"Allocated game render target ({_renderTarget.Width}x{_renderTarget.Height})");
            
            // re-allocate post-process effect buffers
            _app.Logger.Log("Telling the post-processor to re-allocate effect buffers.");
            _postProcessor.ReallocateEffectBuffers();
        }

        private void ApplyConfig()
        {
            _app.Logger.Log("Configuration has been (re-)loaded.");
            var config = _app.GetComponent<ConfigurationManager>();

            // the configured screen resolution
            var displayMode = config.GetDisplayMode();
            _app.Logger.Log($"Display mode: {displayMode.Width}x{displayMode.Height}");
            _app.Logger.Log($"Full-screen: {config.ActiveConfig.IsFullscreen}");
            _app.Logger.Log($"V-sync: {config.ActiveConfig.VSync}");
            _app.Logger.Log($"Fixed time step: {config.ActiveConfig.FixedTimeStepping}");
            _app.Logger.Log($"Post-process Bloom: {config.ActiveConfig.Effects.Bloom}");
            _app.Logger.Log($"Post-process CRT Shadowmask: {config.ActiveConfig.Effects.ShadowMask}");

            // post-processor settings.
            _postProcessor.EnableBloom = config.ActiveConfig.Effects.Bloom;
            _postProcessor.EnableShadowMask = config.ActiveConfig.Effects.ShadowMask;
            
            // should we reset the gpu?
            var applyGraphicsChanges = false;
            
            // Resolution change
            if (ScreenWidth != displayMode.Width || ScreenHeight != displayMode.Height)
            {
                _graphics.PreferredBackBufferWidth = displayMode.Width;
                _graphics.PreferredBackBufferHeight = displayMode.Height;
                applyGraphicsChanges = true;
            }
            
            // v-sync
            if (_graphics.SynchronizeWithVerticalRetrace != config.ActiveConfig.VSync)
            {
                _graphics.SynchronizeWithVerticalRetrace = config.ActiveConfig.VSync;
                applyGraphicsChanges = true;
            }
            
            // fixed time stepping
            if (IsFixedTimeStep != config.ActiveConfig.FixedTimeStepping)
            {
                IsFixedTimeStep = config.ActiveConfig.FixedTimeStepping;
                applyGraphicsChanges = true;
            }
            
            // fullscreen mode
            if (_graphics.IsFullScreen != config.ActiveConfig.IsFullscreen)
            {
                _graphics.IsFullScreen = config.ActiveConfig.IsFullscreen;
                applyGraphicsChanges = true;
            }
            
            // update the GPU if we need to
            if (applyGraphicsChanges)
            {
                _app.Logger.Log("Graphics mode has been changed in the config. Applying these changes.");
                
                // apply the changes in MonoGame
                _graphics.ApplyChanges();
                
                // re-allocate the render target
                this.AllocateRenderTarget();

                _app.Logger.Log("Done.");
            }
        }
        
        protected override void Initialize()
        {
            _app.Logger.Log("Initializing MonoGame...");
            
            // Initialize the app. This officially completes the gluing of Thundershock to MonoGame.
            // It also gives the game a chance to do pre-graphics initialization.
            _app.Initialize(this);

            // this makes sure we get notified when config values are committed.
            var config = _app.GetComponent<ConfigurationManager>();
            config.ConfigurationLoaded += (sender, args) =>
            {
                ApplyConfig();
            };
                
            // HACK: I don't like that we need to do this. But whatever.
            _white = new Texture2D(GraphicsDevice, 1, 1);
            _white.SetData<uint>(new[] {0xFFFFFFFF});
            
            // Initialize the post-processor.
            // TODO: Honour the --no-postprocessor flag.
            _postProcessor = new PostProcessor(GraphicsDevice);

            // Allocate the game render target.
            ApplyConfig();
            
            base.Initialize();
            _app.Logger.Log("MonoGame initialized successfully.");
        }

        protected override void LoadContent()
        {
            // Create our SpriteBatch object.
            _app.Logger.Log("Setting up the SpriteBatch...");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the shaders used by the post-processor.
            _app.Logger.Log("Loading shaders for post-processor...");
            _postProcessor.LoadContent(_thundershockContent);
            
            // Allow the app to do post-initialization.
            _app.Logger.Log("Engine content ready. Telling the app to load...");
            _app.Load();
        }

        protected override void UnloadContent()
        {
            _app.Logger.Log("MonoGame is tearing us down...");
            if (_activeScene != null)
            {
                _app.Logger.Log("Unloading the current Scene...");
                _activeScene.Unload();
                _activeScene = null;
                _app.Logger.Log("Done.");
            }

            // Allow the app to unload.
            _app.Logger.Log("Telling the app to unload before we tear down gfx resources...");
            _app.Unload();
            
            // Tear down the post-processor.
            _app.Logger.Log("Telling the post-processor to release its resources...");
            _postProcessor.UnloadContent();
            
            // de-allocate the hack texture
            _app.Logger.Log("Releasing engine textures...");
            _app.Logger.Log(
                "Jesus H. Fucking Christ, WHY do we need to have an always-loaded 1x1 texture that's just solid white!? Why is this code necessary!?", LogLevel.Trace);
            _white.Dispose();

            // de-allocate the game render target
            _renderTarget.Dispose();

            _app.Logger.Log("Out gfx resources are gone, telling MonoGame to finish tearing down.");
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Allow the app to update
            _app.Update(gameTime);
            
            _activeScene?.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);

            _activeScene?.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _postProcessor.Process(_renderTarget);
            
            base.Draw(gameTime);
        }
    }
}
