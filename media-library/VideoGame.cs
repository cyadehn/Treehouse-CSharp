using System;
namespace Treehouse.MediaLibrary
{
    class VideoGame : MediaItem
    {
        public readonly string ReleaseDate;
        public readonly string Developer;
        public readonly string Studio;
        public readonly string Platform;
        public bool OnLoan = false;
        public string Loanee = null;
      
        public VideoGame( string title, string releaseDate, string studio, string developer, string platform ) : base(title)
        {
            ReleaseDate = releaseDate;
            Developer = developer;
            Studio = studio;
            Platform = platform;
        }
      
        public string GetDisplayText() {
          string displayText = "";
          displayText += $"Game: \"{base.Title}\",\n";
          displayText += $"developed/produced by {Developer} & {Studio}\n";
          displayText += $"Release Date: {ReleaseDate}\n";
          if (OnLoan) {
            if (!string.IsNullOrEmpty(Loanee)) {
                displayText += $"(On loan to {Loanee})\n";
              } else {
                displayText += "(On loan)\n";
              }
          }
          return displayText;
        }
      
        public void Loan( string loanee ) {
            Loanee = loanee;
            OnLoan = true;
        }
        public void Loan() {
            Console.Write($"Are you sure you want to loan {base.Title} out without storing a loanee? ");
            string verify = Console.ReadLine();
            if (verify == "Y" || verify == "y") {
                Loanee = null;
                OnLoan = true;
            } else {
                Console.WriteLine("Loan canceled.");
            }
        }
        public void Return() {
            Loanee = null;
            OnLoan = false;
        }
        public void TransferLoan( string loanee ) {
            Loanee = loanee;
        }
        public void TransferLoan() {
            Loan();
        }
    }
}
