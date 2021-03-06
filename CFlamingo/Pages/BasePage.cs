using CFlamingo.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CFlamingo
{
    /// <summary>
    /// BAse Page for all the pages to gain functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {

        /// <summary>
        /// View Model Associated with Page
        /// </summary>
        private VM mViewModel;

        #region Public Props
        /// <summary>
        /// Animation when page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Animation when page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Time for slide animation takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// View Model Associated with Page
        /// </summary>
        public VM ViewModel 
        { 
            get { return mViewModel; } 
            set 
            {
                //if nothing has changed, return
                if (mViewModel == value) return;
                //Update the value
                mViewModel = value;
                //Set Datacontext
                this.DataContext = mViewModel;
            } 
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            //If we are animating and hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;

            //Create a default view model
            this.ViewModel = new VM();
        } 
        #endregion

        #region Animation Load/UnLoad
        /// <summary>
        /// Once Page is Loaded Peform Animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             await AnimateInAsync();
        }

        /// <summary>
        /// Animates in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(this.SlideSeconds);
                    break;
            }
        }

        /// <summary>
        /// Animate this page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOuttoLeftAsync(this.SlideSeconds);
                    break;
            }
        }

        #endregion

    }
}
