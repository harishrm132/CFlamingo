using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFlamingo.Core
{
    /// <summary>
    ///  Design Time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This Chat app is awesome!!. I want you to see it soon.",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvaliable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "HP",
                    Name = "Harish",
                    Message = "This app is awesome!!. I want you to see it soon.",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "AR",
                    Name = "Aadhish",
                    Message = "What is this awesome!!. I want you to see it soon.",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "PS",
                    Name = "Paros",
                    Message = "Its a good time!!. I want you to see it soon.",
                    ProfilePictureRGB = "30e3c5"
                },



                new ChatListItemViewModel
                {
                    Initials = "HP",
                    Name = "Harish",
                    Message = "This app is awesome!!. I want you to see it soon.",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "AR",
                    Name = "Aadhish",
                    Message = "What is this awesome!!. I want you to see it soon.",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "PS",
                    Name = "Paros",
                    Message = "Its a good time!!. I want you to see it soon.",
                    ProfilePictureRGB = "30e3c5"
                },

            };
        }

    }
}
