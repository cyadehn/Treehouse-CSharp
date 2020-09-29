using System;
namespace Treehouse.MediaLibrary
{
    class Film : MediaItem
    {
        public readonly int Year;
        public readonly string Director;
        public bool OnLoan = false;
        public string Loanee = null;
      
        public Film( string title, int year, string director ) : base(title)
        {
            Year = year;
            Director = director;
        }
      
        public string GetDisplayText() {
          string displayText = "";
          displayText += $"Film: \"{Title}\", directed by {Director}\n";
          displayText += $"Released in {Year}\n";
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
            Console.Write($"Are you sure you want to loan {Title} out without storing a loanee? ");
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
