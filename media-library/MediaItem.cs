using System;
namespace Treehouse.MediaLibrary
{
    public abstract class MediaItem
    {
        public string Title;

        public MediaItem(string title)
        {
            Title = title;
        }
    }
}
