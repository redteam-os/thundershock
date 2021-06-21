﻿using System;
using System.Numerics;
using Thundershock.Core;
using Thundershock.Core.Rendering;
using Thundershock.Gui;

namespace Thundershock.Components
{
    public class TextComponent : SceneComponent
    {
        public Font Font = null;
        public string Text = "Text Component";
        public float WrapWidth = 0;
        public TextWrapMode WrapMode = TextWrapMode.None;
        public Color Color = Color.White;
        public TextAlign TextAlign = TextAlign.Left;
        public Vector2 Pivot = new Vector2(0.5f, 0.5f);
    }
}