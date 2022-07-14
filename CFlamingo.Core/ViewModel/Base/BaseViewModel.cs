using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;

namespace CFlamingo.Core
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event fireeed when child property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Run the command if updating flag is not set
        /// If Flag is true (func is already running) then action will not run
        /// If Flag is false (no func is running) then action will run
        /// Once the Action is finished Flang is set to false
        /// </summary>
        /// <param name="updatingFlag">Boolean Property flag on Preoperty running</param>
        /// <param name="action">Action to Run If comman is not running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action) 
        {
            //Check if flag is true (means funtion is already running)
            if (updatingFlag.GetPropertyValue()) return;

            //Set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed action
                await action();
            }
            finally
            {
                //set the property flag as false now its finished
                updatingFlag.SetPropertyValue(false); 
            }
        }
    }
}