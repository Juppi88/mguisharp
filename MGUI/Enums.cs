using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	enum ELEMENT
	{
		FLAG_NONE				= 0,		/* All flags disabled */
		FLAG_VISIBLE			= 1 << 0,	/* This element is visible and can be processed */
		FLAG_DISABLED			= 1 << 1,	/* This element is inactive (user can't interact with it) */
		FLAG_BACKGROUND			= 1 << 2,	/* The element has a background */
		FLAG_BORDER				= 1 << 3,	/* The element has a border */
		FLAG_SHADOW				= 1 << 4,	/* The element casts a shadow */
		FLAG_DRAGGABLE			= 1 << 5,	/* This element can be dragged */
		FLAG_CLIP				= 1 << 6,	/* Clip text within the element if it exceeds the boundaries */
		FLAG_WRAP				= 1 << 7,	/* Wrap text if it exceeds the boundaries (if applicable) */
		FLAG_AUTO_RESIZE		= 1 << 8,	/* Resize element automatically if parent size changes */
		FLAG_INHERIT_ALPHA		= 1 << 9,	/* Element will inherit alpha from it's parent element */
		FLAG_ANIMATION			= 1 << 10,	/* Enable animations (if applicable) */
		FLAG_TABSTOP			= 1 << 11,	/* Tab press can switch focus to this element */
		FLAG_MOUSECTRL			= 1 << 12,	/* Element triggers mouse input events */
		FLAG_KBCTRL				= 1 << 13,	/* Element triggers keyboard input events and accepts keyboard focus */
		FLAG_TEXT_SHADOW		= 1 << 14,	/* Text will cast a shadow */
		FLAG_TEXT_TAGS			= 1 << 15,	/* Text can be formatted using tags */
		FLAG_DEPTH_TEST			= 1 << 16,	/* Enable depth testing (useful for 3D text) */
		FLAG_3D_ENTITY			= 1 << 17,	/* This element is fully 3D, use mgui_set_3d_* to manipulate */

		// Element specific flags
		FLAG_WINDOW_TITLEBAR	= 1 << 20,	/* Enable window titlebar */
		FLAG_WINDOW_CLOSEBTN	= 1 << 21,	/* Enable window close button */
		FLAG_EDIT_MASKINPUT		= 1 << 20,	/* Mask user input in editbox */
		FLAG_MEMO_TOPBOTTOM		= 1 << 20,	/* Memobox order is top to bottom */
	};

	enum FONT
	{
		FFLAG_NONE		= 0,		/* All flags disabled */
		FFLAG_BOLD		= 1 << 0,	/* Bold font */
		FFLAG_ITALIC	= 1 << 1,	/* Italic font */
		FFLAG_ULINE		= 1 << 2,	/* Underlined font */
		FFLAG_STRIKE	= 1 << 3,	/* Strike out */
		FFLAG_NOAA		= 1 << 4,	/* Disable edge smoothing (if possible) */
	};
}
