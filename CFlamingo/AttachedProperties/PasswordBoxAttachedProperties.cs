using System.Windows;
using System.Windows.Controls;

namespace CFlamingo
{
    /// <summary>
    /// Monitor password attached property for the <see cref="PasswordBox"/>
    /// </summary>
    public class MointorPasswordProperty : BaseAttachedProperty<MointorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;

            //Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //If the caller set monitor password true..
            if ((bool)e.NewValue)
            {
                //Set default value
                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when password box value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Set default value
            HasTextProperty.SetValue((DependencyObject)sender);
        }
    }

    /// <summary>
    /// HasText attached property for the <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Set the Hastext propertybased on if caller <see cref="PasswordBox"/> have any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
