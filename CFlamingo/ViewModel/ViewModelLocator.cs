using CFlamingo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFlamingo
{
    /// <summary>
    /// Locate ViewModel from IoC for use in XAML files
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Singleton Instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// Actual <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
