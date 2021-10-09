using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CFlamingo
{
    /// <summary>
    /// View Model For Login Page
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// Email of users
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Flag Indicate login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to show system Menu of window
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginPageViewModel()
        {
            LoginCommand = new RelayParamaterizedCommand(async (parameter) => await Login(parameter));
        }

        /// <summary>
        /// Attempt to log user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in to view for user passowrd</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                // TODO - IMPORTANT: Dont store password in Variable
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }
    }
}
