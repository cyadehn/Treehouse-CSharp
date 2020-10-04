using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Treehouse.MediaLibrary
{
    class VideoGame : MediaItem
    {
        public string ReleaseDate { get; private set; }
        public string Developer { get; private set; }
        public string Studio { get; private set; }
        public string Platform { get; private set; }
      
        public VideoGame( string title, string releaseDate, string studio, string developer, string platform ) : base(title)
        {
            ReleaseDate = releaseDate;
            Developer = developer;
            Studio = studio;
            Platform = platform;
        }
      
        public override string DisplayText 
        {
            get
            {
                string displayText = "";
                displayText += $"Game: \"{Title}\",\n";
                displayText += $"developed/produced by {Developer} & {Studio}\n";
                displayText += $"Release Date: {ReleaseDate}\n";
                if (OnLoan)
                {
                    displayText += $"(on loan)";
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
