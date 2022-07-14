using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CFlamingo.Core
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

        /// <summary>
        /// Command to Regiser for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginPageViewModel()
        {
            LoginCommand = new RelayParamaterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        /// <summary>
        /// Attempt to log user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in to view for user passowrd</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                // TODO - IMPORTANT: Dont store password in Variable
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }
        
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            //TODO : Go to Register page
            await Task.Delay(1);
        }
    }
}
