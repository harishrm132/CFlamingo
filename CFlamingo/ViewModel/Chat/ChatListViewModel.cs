using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFlamingo
{
    /// <summary>
    /// View Model for Chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The Chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
