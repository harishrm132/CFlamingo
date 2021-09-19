using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CFlamingo
{
    /// <summary>
    /// Base Attached Propery to replace default WPF attached property
    /// </summary>
    /// <typeparam name="Parent">the parent classs to the attached property</typeparam>
    /// <typeparam name="Property">the type of the attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {

        #region Public Events

        /// <summary>
        ///  Fired When Value Changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Public properties
        /// <summary>
        /// Singleton instance of our parent class 
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions
        /// <summary>
        /// Attached Property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>),
                new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Call back event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had its property was changed</param>
        /// <param name="e">Arguments for the events</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call the parent function
            Instance.OnValueChanged(d, e);   

            //call event listeners
            Instance.ValueChanged(d, e);   
        }

        /// <summary>
        /// Get the Value of attached property
        /// </summary>
        /// <param name="d">Eleemnt to get the propery from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Set the attached Property
        /// </summary>
        /// <param name="d">Eleemnt to get the propery from</param>
        /// <param name="value">Set the value to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// Method is called when attached property changed
        /// </summary>
        /// <param name="sender">he UI element that had its property was changed</param>
        /// <param name="e">>Arguments for the events</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}
