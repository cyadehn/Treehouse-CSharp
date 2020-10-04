using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    class Film : MediaItem
    {
        public int Year { get; private set; }
        public string Director { get; private set; }
      
        public Film( string title, int year, string director ) : base(title)
        {
            Year = year;
            Director = director;
        }
      
        public override string DisplayText {
            get
            {
                string displayText = "";
                displayText += $"Film: \"{Title}\", directed by {Director}\n";
                displayText += $"Released in {Year}\n";
                if (!string.IsNullOrEmpty(Loanee)) {
                    displayText += "(On loan)";
                }
                return displayText;
            }
        }

        public override string LoanText
        {
            get
            {
                string loanText = "";
                loanText += $"{this.GetType().Name} is ";
                if (OnLoan) 
                {
                    if (!string.IsNullOrEmpty(Loanee)) 
                    {
                        loanText += $"On loan to {Loanee}";
                    } else 
                    {
                        loanText += "On loan";
                    }
                } else
                {
                    loanText += "currently not on loan.";
                }
                return loanText;
            }
        }
    }
}
