using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public partial class Listbox : Element
	{
		public Listbox( Element parentElement )
		{
			items = new Dictionary<IntPtr, ListboxItem>();
			Handle = API.mgui_create_listbox( parentElement.Handle );
		}

		public Listbox( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour col, Colour selectCol )
		{
			items = new Dictionary<IntPtr, ListboxItem>();
			Handle = API.mgui_create_listbox_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex(), selectCol.AsHex() );
		}

		public ListboxItem AddItem( string text )
		{
			IntPtr itemHandle = API.mgui_listbox_add_item( Handle, text );
			ListboxItem item = new ListboxItem( this, itemHandle );

			items.Add( itemHandle, item );
			return item;
		}

		public void RemoveItem( ListboxItem item )
		{
			items.Remove( item.Handle );
			API.mgui_listbox_remove_item( Handle, item.Handle );
		}

		public void Clean()
		{
			items.Clear();
			API.mgui_listbox_clean( Handle );
		}

		public uint ItemCount
		{
			get { return API.mgui_listbox_get_item_count( Handle ); }
		}

		public uint SelectedCount
		{
			get { return API.mgui_listbox_get_selected_count( Handle ); }
		}

		public ListboxItem First
		{
			get
			{
				IntPtr handle = API.mgui_listbox_get_first_item( Handle );
				return GetItemFromPointer( handle );
			}
		}

		public ListboxItem FirstSelected
		{
			get
			{
				IntPtr handle = API.mgui_listbox_get_selected_item( Handle );
				return GetItemFromPointer( handle );
			}
		}

		public Colour SeletedColour
		{
			get { Colour col; API.mgui_listbox_get_selected_colour( Handle, out col ); return col; }
			set { API.mgui_listbox_set_selected_colour( Handle, ref value ); }
		}

		public ListboxItem GetItemFromPointer( IntPtr pointer )
		{
			if ( !items.ContainsKey( pointer ) )
				return ListboxItem.Null;

			return items[pointer];
		}

		// --------------------------------------------------
		// Element flag properties
		// --------------------------------------------------

		public bool Scrollable
		{
			get { return GetFlag( ELEMFLAG.SCROLLABLE ); }
			set { SetFlag( ELEMFLAG.SCROLLABLE, value ); }
		}

		public bool MultiSelect
		{
			get { return GetFlag( ELEMFLAG.LISTBOX_MULTISELECT ); }
			set { SetFlag( ELEMFLAG.LISTBOX_MULTISELECT, value ); }
		}

		public bool AutoSort
		{
			get { return GetFlag( ELEMFLAG.LISTBOX_SORTING ); }
			set { SetFlag( ELEMFLAG.LISTBOX_SORTING, value ); }
		}

		// --------------------------------------------------
		// Storage
		// --------------------------------------------------

		// A list of items and their pointers on this listbox.
		private Dictionary<IntPtr, ListboxItem> items;

		// --------------------------------------------------
		// Events
		// --------------------------------------------------

		public event ListEventHandler OnItemSelect;
	}

	public class ListboxItem : IDisposable
	{
		public ListboxItem()
		{
			itemHandle = IntPtr.Zero;
		}

		public ListboxItem( Listbox parent, IntPtr handle )
		{
			parentListbox = parent;
			itemHandle = handle;
		}

		public void Dispose()
		{
			// We don't have to delete the handle, the library will handle it (no pun intended).
			itemHandle = IntPtr.Zero;
		}

		public IntPtr Handle
		{
			get { return itemHandle; }
			set { if ( value != IntPtr.Zero ) { itemHandle = value; } }
		}

		public ListboxItem Next
		{
			get
			{
				IntPtr next = API.mgui_listbox_get_next_item( itemHandle );
				return parentListbox.GetItemFromPointer( next );
			}
		}

		public ListboxItem NextSelected
		{
			get
			{
				IntPtr next = API.mgui_listbox_get_next_selected_item( itemHandle );
				return parentListbox.GetItemFromPointer( next );
			}
		}

		public string Text
		{
			set { API.mgui_listbox_set_item_text( itemHandle, value ); }
		}

		// Handle to the internal MGuiListboxItem struct
		private IntPtr itemHandle;

		// Parent element
		private Listbox parentListbox;

		// A null item (used as the last item of a list)
		public static ListboxItem Null;
	}
}
