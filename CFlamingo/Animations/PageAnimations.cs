using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CFlamingo
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slide the Page in from the right
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">total animation seconds</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, page.WindowWidth);
            sb.AddFadeIn(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slide the Page out to the left
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">total animation seconds</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOuttoLeftAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, page.WindowWidth);
            sb.AddFadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}
