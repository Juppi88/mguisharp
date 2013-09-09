﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public enum MGUI_PARAMETERS
	{
		NO_PARAMS		= 0x0,	/* Don't use any special parameters */
		USE_DRAW_EVENT	= 0x1,	/* MGUI will refresh only when the user calls mgui_force_redraw */
		PROCESS_INPUT	= 0x2,	/* Process input within the GUI library without external hooks */
		HOOK_INPUT		= 0x4,	/* Hook window messages and process input within the GUI library */
	};

	public enum MGUI_ALIGNMENT
	{
		ALIGN_LEFT		= 1 << 0,
		ALIGN_RIGHT		= 1 << 1,
		ALIGN_TOP		= 1 << 2,
		ALIGN_BOTTOM	= 1 << 3,
		ALIGN_CENTERV	= 1 << 4,
		ALIGN_CENTERH	= 1 << 5,
		ALIGN_CENTER	= (ALIGN_CENTERV|ALIGN_CENTERH),
	};

	public enum ELEMFLAG
	{
		NONE			= 0,		/* All flags disabled */
		VISIBLE			= 1 << 0,	/* This element is visible and can be processed */
		DISABLED		= 1 << 1,	/* This element is inactive (user can't interact with it) */
		BACKGROUND		= 1 << 2,	/* The element has a background */
		BORDER			= 1 << 3,	/* The element has a border */
		SHADOW			= 1 << 4,	/* The element casts a shadow */
		DRAGGABLE		= 1 << 5,	/* This element can be dragged */
		CLIP			= 1 << 6,	/* Clip text within the element if it exceeds the boundaries */
		WRAP			= 1 << 7,	/* Wrap text if it exceeds the boundaries (if applicable) */
		AUTO_RESIZE		= 1 << 8,	/* Resize element automatically if parent size changes */
		INHERIT_ALPHA	= 1 << 9,	/* Element will inherit alpha from it's parent element */
		ANIMATION		= 1 << 10,	/* Enable animations (if applicable) */
		TABSTOP			= 1 << 11,	/* Tab press can switch focus to this element */
		MOUSECTRL		= 1 << 12,	/* Element triggers mouse input events */
		KBCTRL			= 1 << 13,	/* Element triggers keyboard input events and accepts keyboard focus */
		TEXT_SHADOW		= 1 << 14,	/* Text will cast a shadow */
		TEXT_TAGS		= 1 << 15,	/* Text can be formatted using tags */
		DEPTH_TEST		= 1 << 16,	/* Enable depth testing (useful for 3D text) */
		DRAW_3D			= 1 << 17,	/* This element is fully 3D, use mgui_set_3d_* to manipulate */

		// Element type specific flags
		WINDOW_TITLEBAR	= 1 << 20,	/* Enable window titlebar */
		WINDOW_CLOSEBTN	= 1 << 21,	/* Enable window close button */
		EDIT_MASKINPUT	= 1 << 20,	/* Mask user input in editbox */
		MEMO_TOPBOTTOM	= 1 << 20,	/* Memobox order is top to bottom */
	};

	public enum FONTFLAG
	{
		NONE	= 0,		/* All flags disabled */
		BOLD	= 1 << 0,	/* Bold font */
		ITALIC	= 1 << 1,	/* Italic font */
		ULINE	= 1 << 2,	/* Underlined font */
		STRIKE	= 1 << 3,	/* Strike out */
		NOAA	= 1 << 4,	/* Disable edge smoothing (if possible) */
	};
}
