using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace CFlamingo
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Slide from Right Animation to storyboard
        /// </summary>
        /// <param name="storyboard">Storyboard to add to animation</param>
        /// <param name="seconds">Time animation will take</param>
        /// <param name="offset">Distance to offset from right</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio, 
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        
        /// <summary>
        /// Slide to left Animation to storyboard
        /// </summary>
        /// <param name="storyboard">Storyboard to add to animation</param>
        /// <param name="seconds">Time animation will take</param>
        /// <param name="offset">Distance to offset from right</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Fade in from Right Animation to storyboard
        /// </summary>
        /// <param name="storyboard">Storyboard to add to animation</param>
        /// <param name="seconds">Time animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Fade out to left Animation to storyboard
        /// </summary>
        /// <param name="storyboard">Storyboard to add to animation</param>
        /// <param name="seconds">Time animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }


    }
}
