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
        public string Composer { get; private set; }
        public int Year { get; private set; }
        
        public Composition( string title, string composer, int year ) : base(title)
        {
            Composer = composer;
            Year = year;
        }
      
        public override string DisplayText 
        {
            get 
            {            
                string displayText = "";
                displayText += $"Composition: \"{Title}\", composed by {Composer}\n";
                displayText += $"Released/first performed in {Year}\n";
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
