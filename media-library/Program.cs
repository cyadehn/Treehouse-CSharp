using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    class Program
    {
        static void DetectMediaType( MediaItem item )
        {
           if ( item == null )
           {
               return;
           } 
           else if(item is Composition)
           {
               Console.WriteLine($"{item.Title} is a composition!");
           } 
           else if(item is VideoGame)
           {
               Console.WriteLine($"{item.Title} is a videogame!");
           } 
           else if(item is Film)
           {
               Console.WriteLine($"{item.Title} is a film!");
           } 
           else {
               throw new Exception("Unexpected media subtype encountered.");
           }
        }

        static void Main()
        {
            try {
                MediaLibrary library = new MediaLibrary(MediaRepository.LoadMedia(), "Chris");
                Console.WriteLine($"There are {library.NumberOfItems} items in {library.Name}");
                library.DisplayItems();
                
                MediaItem search = library.FindItem("Symphony");
                if ( search != null )
                {
                    library.DisplayItem(search);
                }
                else
                {
                    Console.WriteLine("MediaItem not found!");
                }
            }
            catch (Exception ex) {
               Console.WriteLine(ex);
            }
        }
    }
}
