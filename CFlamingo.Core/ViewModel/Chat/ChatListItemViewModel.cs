using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFlamingo.Core
{
    /// <summary>
    /// View Model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Initials to show for profile picture
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// RGB values of the backgroud color of profile picture
        /// For Example FF00FF for Red and Blue Mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if unread Messages in this chat
        /// </summary>
        public bool NewContentAvaliable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
