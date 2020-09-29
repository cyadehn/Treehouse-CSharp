using System;
namespace Treehouse.MediaLibrary
{
    class VideoGame : MediaItem
    {
        public readonly string ReleaseDate;
        public readonly string Developer;
        public readonly string Studio;
        public readonly string Platform;
      
        public VideoGame( string title, string releaseDate, string studio, string developer, string platform ) : base(title)
        {
            ReleaseDate = releaseDate;
            Developer = developer;
            Studio = studio;
            Platform = platform;
        }
      
        public override string GetDisplayText() {
          string displayText = "";
          displayText += $"Game: \"{Title}\",\n";
          displayText += $"developed/produced by {Developer} & {Studio}\n";
          displayText += $"Release Date: {ReleaseDate}\n";
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
