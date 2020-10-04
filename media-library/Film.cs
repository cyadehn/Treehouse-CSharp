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
        public readonly int Year;
        public readonly string Director;
      
        public Film( string title, int year, string director ) : base(title)
        {
            Year = year;
            Director = director;
        }
      
        public override string GetDisplayText() {
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

        public override string GetLoanText()
        {
            string loanText = "";
            loanText += $"{this.GetType().Name} is ";
            if (OnLoan) 
            {
                if (!string.IsNullOrEmpty(Loanee)) 
                {
                    loanText += $"On loan to {Loanee}\n";
                } else 
                {
                    loanText += "On loan\n";
                }
            } else
            {
                loanText += "currently not on loan.";
            }
            return loanText;
        }
    }
}
