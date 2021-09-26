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
    public class BasePage : Page
    {
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

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            //If we are animating and hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;
        }

        /// <summary>
        /// Once Page is Loaded Peform Animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// Animates in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation) 
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
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
                    await this.SlideAndFadeOuttoLeft(this.SlideSeconds);
                    break;
            }
        }


    }
}
