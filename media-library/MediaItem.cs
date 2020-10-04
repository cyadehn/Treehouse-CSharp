using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    public abstract class MediaItem
    {
        public string Title { get; set; }
        public bool OnLoan { get; set; } = false;
        public string Loanee { get; set; } = "";

        public MediaItem(string title)
        {
            if ( !string.IsNullOrEmpty(title)) {
                Title = title;
            } else
            {
                throw new Exception("A media type must have a title.");
            }
        }

        public abstract string DisplayText { get; }

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
        public abstract string LoanText { get; }
    }
}
