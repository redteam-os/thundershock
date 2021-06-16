using Thundershock.Config;
using Thundershock.Core;
using Thundershock.Core.Rendering;

namespace Thundershock
{
    public abstract class GraphicalAppBase : AppBase
    {
        private bool _borderless = false;
        private bool _fullscreen = false;
        private int _width;
        private int _height;
        private GraphicsProcessor _graphicsProcessor;
        private GameWindow _gameWindow;
        private bool _aboutToExit = false;

        public bool SwapMouseButtons
        {
            get => _gameWindow.PrimaryMouseButtonIsRightMouseButton;
            set => _gameWindow.PrimaryMouseButtonIsRightMouseButton = value;
        }
        
        public bool IsBorderless
        {
            get => _borderless;
            protected set => _borderless = value;
        }

        public bool IsFullScreen
        {
            get => _fullscreen;
            protected set => _fullscreen = value;
        }

        public int ScreenWidth => _width;
        public int ScreenHeight => _height;
        
        protected sealed override void Bootstrap()
        {
            Logger.Log("Creating the game window...");
            _gameWindow = CreateGameWindow();
            _gameWindow.Show(this);
            Logger.Log("Game window created.");

            PreInit();
            
            _graphicsProcessor = _gameWindow.GraphicsProcessor;
            
            RunLoop();

            Logger.Log("RunLoop just returned. That means we're about to die.");
            _gameWindow.Close();
            _gameWindow = null;
            Logger.Log("Game window destroyed.");
        }

        private void RunLoop()
        {
            while (!_aboutToExit)
            {
                _graphicsProcessor.Clear(new Color(0x1b, 0xaa, 0xf7));
                
                _gameWindow.Update();
            }
        }

        protected override void BeforeExit(AppExitEventArgs args)
        {
            // call the base method to dispatch the event to the rest of the engine.
            base.BeforeExit(args);
            
            // Terminate the game loop if args.Cancelled isn't set
            if (!args.CancelExit)
            {
                _aboutToExit = true;
            }
        }

        private void PreInit()
        {
            Logger.Log("PreInit reached. Setting up core components.");
            RegisterComponent<ConfigurationManager>();

            OnPreInit();
        }

        protected void ApplyGraphicsChanges()
        {
            _gameWindow.IsBorderless = _borderless;
            _gameWindow.IsFullScreen = _fullscreen;
            
            // TODO: V-Sync, Fixed Time Stepping, Monitor Positioning
            _gameWindow.Width = _width;
            _gameWindow.Height = _height;
        }

        protected void SetScreenSize(int width, int height, bool apply = false)
        {
            _width = width;
            _height = height;
            
            if (apply) ApplyGraphicsChanges();
        }
        
        protected virtual void OnPreInit() {}
        
        protected abstract GameWindow CreateGameWindow();
    }
}