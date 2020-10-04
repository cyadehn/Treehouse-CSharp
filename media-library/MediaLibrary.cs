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

        public void DisplayItems()
        {
            foreach ( var item in _items )
            {
                Console.WriteLine(item.DisplayText);
            }
        }

        public void DisplayItem( MediaItem item )
        {
            if ( item != null )
            {
                Console.WriteLine(item.DisplayText);
            }
            else
            {
                Console.WriteLine("MediaItem is not defined/null");
            }
        }

        public MediaItem FindItem(string criteria)
        {
            MediaItem result = null;
            foreach ( var item in _items )
            {
                if ( item.Title.ToLower().Contains(criteria.ToLower()) )
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
    }
}
