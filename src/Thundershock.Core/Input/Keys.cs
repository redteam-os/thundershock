// Friendly 1:1 mapping of SDL2 key codes to Thundershock key event values.
//
// There is definitely optimization needed hete.
//
// I've never HEARD of some of these keys. Whoever has a number pad
// with hexadecimal digits on it please text "ritchie" to +1 (555) 867-5309
// and nobody will answer because you aren't real.

namespace Thundershock.Core.Input
{
	public enum Keys
	{
		None = 0,
		Return = '\r',
		Enter = Return,
		Escape = 27, // '\033'
		Backspace = '\b',
		Tab = '\t',
		Space = ' ',
		Exclaim = '!',
		Quote = '"',
		Hash = '#',
		Percent = '%',
		Dollar = '$',
		Ampersand = '&',
		Apostrophe = '\'',
		OpenParenthesis = '(',
		CloseParanthesis = ')',
		Asterisk = '*',
		Plus = '+',
		Comma = ',',
		Minus = '-',
		Period = '.',
		Slash = '/',
		D0 = '0',
		D1 = '1',
		D2 = '2',
		D3 = '3',
		D4 = '4',
		D5 = '5',
		D6 = '6',
		D7 = '7',
		D8 = '8',
		D9 = '9',
		Colon = ':',
		Semicolon = ';',
		LessThan = '<',
		Equal = '=',
		GreaterThan = '>',
		Question = '?',
		At = '@',

		/*
		Skip uppercase letters
		*/
		OpenBracket = '[',
		Backslash = '\\',
		CloseBracket = ']',
		Caret = '^',
		Underscore = '_',
		BackQuote = '`',
		A = 'a',
		B = 'b',
		C = 'c',
		D = 'd',
		E = 'e',
		F = 'f',
		G = 'g',
		H = 'h',
		I = 'i',
		J = 'j',
		K = 'k',
		L = 'l',
		M = 'm',
		N = 'n',
		O = 'o',
		P = 'p',
		Q = 'q',
		R = 'r',
		S = 's',
		T = 't',
		U = 'u',
		V = 'v',
		W = 'w',
		X = 'x',
		Y = 'y',
		Z = 'z',

		ScancodeBit = (1 << 30),
		
		F1 = 58 | ScancodeBit,
		F2 = 59 | ScancodeBit,
		F3 = 60 | ScancodeBit,
		F4 = 61 | ScancodeBit,
		F5 = 62 | ScancodeBit,
		F6 = 63 | ScancodeBit,
		F7 = 64 | ScancodeBit,
		F8 = 65 | ScancodeBit,
		F9 = 66 | ScancodeBit,
		F10 = 67 | ScancodeBit,
		F11 = 68 | ScancodeBit,
		F12 = 69 | ScancodeBit,

		PrintScreen = 70 | ScancodeBit,
		CapsLock = 71 | ScancodeBit,
		Pause = 72 | ScancodeBit,
		Insert = 73 | ScancodeBit,
		Home = 74 | ScancodeBit,
		PageUp = 75 | ScancodeBit,
		Delete = 127,
		End = 77 | ScancodeBit,
		PageDown = 78 | ScancodeBit,
		Right = 79 | ScancodeBit,
		Left = 80 | ScancodeBit,
		Down = 81 | ScancodeBit,
		Up = 82 | ScancodeBit,

		NumLockClear = 83 | ScancodeBit,
		OemDivide = 84 | ScancodeBit,
		OemMultiply = 85 | ScancodeBit,
		OemMinus = 86 | ScancodeBit,
		OemPlus = 87 | ScancodeBit,
		OemEnter = 88 | ScancodeBit,
		Num1 = 89 | ScancodeBit,
		Num2 = 90 | ScancodeBit,
		Num3 = 91 | ScancodeBit,
		Num4 = 92 | ScancodeBit,
		Num5 = 93 | ScancodeBit,
		Num6 = 94 | ScancodeBit,
		Num7 = 95 | ScancodeBit,
		Num8 = 96 | ScancodeBit,
		Num9 = 97 | ScancodeBit,
		Num0 = 98 | ScancodeBit,
		OemPeriod = 99 | ScancodeBit,

		OemApplication = 101 | ScancodeBit,
		OemPower = 102 | ScancodeBit,
		OemEqual = 103 | ScancodeBit,
		F13 = 104 | ScancodeBit,
		F14 = 105 | ScancodeBit,
		F15 = 106 | ScancodeBit,
		F16 = 107 | ScancodeBit,
		F17 = 108 | ScancodeBit,
		F18 = 109 | ScancodeBit,
		F19 = 110 | ScancodeBit,
		F20 = 111 | ScancodeBit,
		F21 = 112 | ScancodeBit,
		F22 = 113 | ScancodeBit,
		F23 = 114 | ScancodeBit,
		F24 = 115 | ScancodeBit,
		
		OemExecute = 116 | ScancodeBit,
		OemHelp = 117 | ScancodeBit,
		OemMenu = 118 | ScancodeBit,
		OemSelect = 119 | ScancodeBit,
		OemStop = 120 | ScancodeBit,
		OemAgain = 121 | ScancodeBit,
		OemUndo = 122 | ScancodeBit,
		OemCut = 123 | ScancodeBit,
		OemCopy = 124 | ScancodeBit,
		OemPaste = 125 | ScancodeBit,
		OemFind = 126 | ScancodeBit,
		OemMute = 127 | ScancodeBit,
		OemVolumeUp = 128 | ScancodeBit,
		OemVolumeDown = 129 | ScancodeBit,
		
		OemComma = 133 | ScancodeBit,

		EqualsAs400 = 134 | ScancodeBit,

		AltErase = 153 | ScancodeBit,
		SysReq = 154 | ScancodeBit,
		Cancel = 155 | ScancodeBit,
		Clear = 156 | ScancodeBit,
		Print = 157 | ScancodeBit,
		OemReturn = 158 | ScancodeBit,
		Separator = 159 | ScancodeBit,
		Out = 160 | ScancodeBit,
		Oper = 161 | ScancodeBit,
		ClearAgain = 162 | ScancodeBit,
		CrSel = 163 | ScancodeBit,
		ExSel = 164 | ScancodeBit,

		// what????
		Num00 = 176 | ScancodeBit,
		Num000 = 177 | ScancodeBit,
		ThousandsSeparator = 178 | ScancodeBit,
		DecimalSeparator = 179 | ScancodeBit,
		CurrencyUnit = 180 | ScancodeBit,
		CurrencySubunit = 181 | ScancodeBit,
		
		OemOpenParenthesis = 182 | ScancodeBit,
		OemCloseParenthesis = 183 | ScancodeBit,
		OemOpenBrace = 184 | ScancodeBit,
		OemCloseBrace = 185 | ScancodeBit,
		OemTab = 186 | ScancodeBit,
		OemBackspace = 187 | ScancodeBit,
		Oem10 = 188 | ScancodeBit,
		Oem11 = 189 | ScancodeBit,
		Oem12 = 190 | ScancodeBit,
		Oem13 = 191 | ScancodeBit,
		Oem14 = 192 | ScancodeBit,
		Oem15 = 193 | ScancodeBit,
		OemXor = 194 | ScancodeBit,
		OemExponent = 195 | ScancodeBit,
		OemPercent = 196 | ScancodeBit,
		OemLessThan = 197 | ScancodeBit,
		OemGreaterThan = 198 | ScancodeBit,
		OemAmpersand = 199 | ScancodeBit,

		/* TODO
		SDLK_KP_DBLAMPERSAND =
			(int) SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND | ScancodeBit,

		SDLK_KP_VERTICALBAR =
			(int) SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR | ScancodeBit,

		SDLK_KP_DBLVERTICALBAR =
			(int) SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR | ScancodeBit,
		SDLK_KP_COLON = SDL_Scancode.SDL_SCANCODE_KP_COLON | ScancodeBit,
		SDLK_KP_HASH = SDL_Scancode.SDL_SCANCODE_KP_HASH | ScancodeBit,
		SDLK_KP_SPACE = SDL_Scancode.SDL_SCANCODE_KP_SPACE | ScancodeBit,
		SDLK_KP_AT = SDL_Scancode.SDL_SCANCODE_KP_AT | ScancodeBit,
		SDLK_KP_EXCLAM = SDL_Scancode.SDL_SCANCODE_KP_EXCLAM | ScancodeBit,
		SDLK_KP_MEMSTORE = SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE | ScancodeBit,
		SDLK_KP_MEMRECALL = SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL | ScancodeBit,
		SDLK_KP_MEMCLEAR = SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR | ScancodeBit,
		SDLK_KP_MEMADD = SDL_Scancode.SDL_SCANCODE_KP_MEMADD | ScancodeBit,

		SDLK_KP_MEMSUBTRACT =
			(int) SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT | ScancodeBit,

		SDLK_KP_MEMMULTIPLY =
			(int) SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY | ScancodeBit,
		SDLK_KP_MEMDIVIDE = SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE | ScancodeBit,
		SDLK_KP_PLUSMINUS = SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS | ScancodeBit,
		SDLK_KP_CLEAR = SDL_Scancode.SDL_SCANCODE_KP_CLEAR | ScancodeBit,
		SDLK_KP_CLEARENTRY = SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY | ScancodeBit,
		SDLK_KP_BINARY = SDL_Scancode.SDL_SCANCODE_KP_BINARY | ScancodeBit,
		SDLK_KP_OCTAL = SDL_Scancode.SDL_SCANCODE_KP_OCTAL | ScancodeBit,
		SDLK_KP_DECIMAL = SDL_Scancode.SDL_SCANCODE_KP_DECIMAL | ScancodeBit,

		SDLK_KP_HEXADECIMAL =
			(int) SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL | ScancodeBit,

		SDLK_LCTRL = SDL_Scancode.SDL_SCANCODE_LCTRL | ScancodeBit,
		SDLK_LSHIFT = SDL_Scancode.SDL_SCANCODE_LSHIFT | ScancodeBit,
		SDLK_LALT = SDL_Scancode.SDL_SCANCODE_LALT | ScancodeBit,
		SDLK_LGUI = SDL_Scancode.SDL_SCANCODE_LGUI | ScancodeBit,
		SDLK_RCTRL = SDL_Scancode.SDL_SCANCODE_RCTRL | ScancodeBit,
		SDLK_RSHIFT = SDL_Scancode.SDL_SCANCODE_RSHIFT | ScancodeBit,
		SDLK_RALT = SDL_Scancode.SDL_SCANCODE_RALT | ScancodeBit,
		SDLK_RGUI = SDL_Scancode.SDL_SCANCODE_RGUI | ScancodeBit,

		SDLK_MODE = SDL_Scancode.SDL_SCANCODE_MODE | ScancodeBit,

		SDLK_AUDIONEXT = SDL_Scancode.SDL_SCANCODE_AUDIONEXT | ScancodeBit,
		SDLK_AUDIOPREV = SDL_Scancode.SDL_SCANCODE_AUDIOPREV | ScancodeBit,
		SDLK_AUDIOSTOP = SDL_Scancode.SDL_SCANCODE_AUDIOSTOP | ScancodeBit,
		SDLK_AUDIOPLAY = SDL_Scancode.SDL_SCANCODE_AUDIOPLAY | ScancodeBit,
		SDLK_AUDIOMUTE = SDL_Scancode.SDL_SCANCODE_AUDIOMUTE | ScancodeBit,
		SDLK_MEDIASELECT = SDL_Scancode.SDL_SCANCODE_MEDIASELECT | ScancodeBit,
		SDLK_WWW = SDL_Scancode.SDL_SCANCODE_WWW | ScancodeBit,
		SDLK_MAIL = SDL_Scancode.SDL_SCANCODE_MAIL | ScancodeBit,
		SDLK_CALCULATOR = SDL_Scancode.SDL_SCANCODE_CALCULATOR | ScancodeBit,
		SDLK_COMPUTER = SDL_Scancode.SDL_SCANCODE_COMPUTER | ScancodeBit,
		SDLK_AC_SEARCH = SDL_Scancode.SDL_SCANCODE_AC_SEARCH | ScancodeBit,
		SDLK_AC_HOME = SDL_Scancode.SDL_SCANCODE_AC_HOME | ScancodeBit,
		SDLK_AC_BACK = SDL_Scancode.SDL_SCANCODE_AC_BACK | ScancodeBit,
		SDLK_AC_FORWARD = SDL_Scancode.SDL_SCANCODE_AC_FORWARD | ScancodeBit,
		SDLK_AC_STOP = SDL_Scancode.SDL_SCANCODE_AC_STOP | ScancodeBit,
		SDLK_AC_REFRESH = SDL_Scancode.SDL_SCANCODE_AC_REFRESH | ScancodeBit,
		SDLK_AC_BOOKMARKS = SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS | ScancodeBit,

		SDLK_BRIGHTNESSDOWN =
			(int) SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN | ScancodeBit,
		SDLK_BRIGHTNESSUP = SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP | ScancodeBit,
		SDLK_DISPLAYSWITCH = SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH | ScancodeBit,

		SDLK_KBDILLUMTOGGLE =
			(int) SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE | ScancodeBit,
		SDLK_KBDILLUMDOWN = SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN | ScancodeBit,
		SDLK_KBDILLUMUP = SDL_Scancode.SDL_SCANCODE_KBDILLUMUP | ScancodeBit,
		SDLK_EJECT = SDL_Scancode.SDL_SCANCODE_EJECT | ScancodeBit,
		SDLK_SLEEP = SDL_Scancode.SDL_SCANCODE_SLEEP | ScancodeBit,
		SDLK_APP1 = SDL_Scancode.SDL_SCANCODE_APP1 | ScancodeBit,
		SDLK_APP2 = SDL_Scancode.SDL_SCANCODE_APP2 | ScancodeBit,

		SDLK_AUDIOREWIND = SDL_Scancode.SDL_SCANCODE_AUDIOREWIND | ScancodeBit,
		SDLK_AUDIOFASTFORWARD = SDL_Scancode.SDL_SCANCODE_AUDIOFASTFORWARD | ScancodeBit */
	}
}