using System;

namespace Treehouse.MediaLibrary
{
    class Program
    {
        static void DetectMediaType( MediaItem item )
        {
           if(item is Composition)
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
           } else {
               throw new Exception("Unexpected media subtype encountered.");
           }
        }

        static void Main()
        {
            try {

                MediaItem[] mediaItems = new MediaItem[] {
                    VideoGame game1 = new VideoGame("The Legend of Zelda: Ocarina of Time", "November 21, 1998", "Nintendo EAD", "Nintendo", "Nintendo 64");
                    VideoGame game2 = new VideoGame("Megaman Battle Network", "March 21, 2001", "Capcom", "Capcom", "GameBoy Advance");
                    VideoGame game3 = new VideoGame("Billy Hatcher and the Giant Egg", "September 23, 2003", "Sonic Team", "Sega", "Nintendo Gamecube");

                    Film film1 = new Film("Harold and Maude", 1971, "Hal Ashby");
                    Film film2 = new Film("Me and Earl and the Dying Girl", 2013, "Alfonzo Gomez-Rejon");
                    Film film3 = new Film("The Little Prince", 2016, "Mark Osborne");

                    Composition composition1 = new Composition("Symphony No. 5, Op. 67", "Ludwig van Beethoven", 1808);
                    Composition composition2 = new Composition("Hello World", "Louie Zong", 2018);
                    Composition composition3 = new Composition("Just A Quail", "Louie Zong", 2019);
                    Composition composition4 = new Composition("Bird With A Broken Wing", "Adam Young", 2015);
                    Composition composition5 = new Composition("Deer In The Headlights", "Owl City", 2011);
                }

                DetectMediaType(game1);
                DetectMediaType(film1);
                DetectMediaType(composition1);
            }          
            catch (Exception ex) {
               Console.WriteLine(ex);
            }
        }
    }
}
