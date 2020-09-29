using System;
namespace Treehouse.MediaLibrary
{
    public abstract class MediaItem
    {
        public string Title;
        public bool OnLoan = false;
        public string Loanee = null;

        public MediaItem(string title)
        {
            Title = title;
        }

        public abstract string GetDisplayText();

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
        public abstract string GetLoanText();
    }
}
