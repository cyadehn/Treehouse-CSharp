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
        
        public string Name { get; private set; }

        public MediaLibrary( List<MediaItem> items, string name )
        {
           _items = items; 
           Name = $"{name}'s Media Library";
        }

        public MediaItem GetItemAt( int i )
        {
            if ( i < _items.Count() )
            {
                return _items[i];
            }
            else
            {
                Console.WriteLine($"Index {i} is out of bounds for {this.Name}");
                return null;
            }
        }

        public int NumberOfItems => _items.Count();
    }
}
