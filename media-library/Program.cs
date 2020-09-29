using System;

namespace Treehouse.MediaLibrary
{
    class Program
    {
        static void Main()
        {
          
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
          
          game1.Loan("Gracie Reece");
          game2.Loan("Mike Elder");
          game3.Loan("Joey Geneseo");
          
          game1.TransferLoan("Jonah Larison");
          game2.Return();
          game2.Loan();
          
//          Console.WriteLine(game1.GetDisplayText());
//          Console.WriteLine(game2.GetDisplayText());
//          Console.WriteLine(game3.GetDisplayText());

//         Console.WriteLine(composition1.GetDisplayText());
//          Console.WriteLine(composition2.GetDisplayText());
//          Console.WriteLine(composition3.GetDisplayText());
//          Console.WriteLine(composition4.GetDisplayText());
//          Console.WriteLine(composition5.GetDisplayText());

          Console.WriteLine(game1.GetLoanText());
        }
    }
}
