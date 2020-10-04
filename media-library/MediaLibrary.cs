using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    public class MediaLibrary
    {
        private List<MediaItem> _items;

        public MediaLibrary( List<MediaItem> items )
        {
           _items = items; 
        }

        public MediaItem GetItemAt( int i )
        {
            return index < _items.Count() ? _items.ElementAt(i) : return null;
        }
    }
}
