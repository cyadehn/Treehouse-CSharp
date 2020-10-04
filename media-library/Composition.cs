using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    class Composition : MediaItem
    {
        public readonly string Composer;
        public readonly int Year;
        
        public Composition( string title, string composer, int year ) : base(title)
        {
            Composer = composer;
            Year = year;
        }
      
        public override string GetDisplayText() {
          string displayText = "";
          displayText += $"Composition: \"{Title}\", composed by {Composer}\n";
          displayText += $"Released/first performed in {Year}\n";
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
