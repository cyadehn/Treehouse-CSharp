using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    public class MediaRepository
    {
        public static List<MediaItem> LoadMedia()
        {
            var items = new List<MediaItem>();
            
            items.Add(new VideoGame("The Legend of Zelda: Ocarina of Time", "November 21, 1998", "Nintendo EAD", "Nintendo", "Nintendo 64"));
            items.Add(new VideoGame("Megaman Battle Network", "March 21, 2001", "Capcom", "Capcom", "GameBoy Advance"));
            items.Add(new VideoGame("Billy Hatcher and the Giant Egg", "September 23, 2003", "Sonic Team", "Sega", "Nintendo Gamecube"));
            items.Add(new Film("Harold and Maude", 1971, "Hal Ashby"));
            items.Add(new Film("Me and Earl and the Dying Girl", 2013, "Alfonzo Gomez-Rejon"));
            items.Add(new Film("The Little Prince", 2016, "Mark Osborne"));
            items.Add(new Composition("Symphony No. 5, Op. 67", "Ludwig van Beethoven", 1808));
            items.Add(new Composition("Hello World", "Louie Zong", 2018));
            items.Add(new Composition("Just A Quail", "Louie Zong", 2019));
            items.Add(new Composition("Bird With A Broken Wing", "Adam Young", 2015));
            items.Add(new Composition("Deer In The Headlights", "Owl City", 2011));

            return items;
        }

    }
}
