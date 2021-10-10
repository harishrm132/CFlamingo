using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CFlamingo
{
    /// <summary>
    /// View Model for Custom Window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Window viewmodel control
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for the drop shadow
        /// </summary>
        private int mOutermarginSize = 10;

        /// <summary>
        /// Radius of the window edges
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// Smallest Wdith of window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// Smallest Height of window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        public bool Borderless { get { return mWindow.WindowState == WindowState.Maximized; } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// Size of the resize border around the windows takes into acount of outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// Padding of the Inner Content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// margin around the window to allow for the drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOutermarginSize;
            }
            set
            {
                mOutermarginSize = value;
            }
        }

        /// <summary>
        /// margin around the window to allow for the drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }


        /// <summary>
        /// Radius of the window edges
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// Radius of the window edges
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// Height of the title bar/caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// Height of the title bar/caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// Current Page of Application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Chat;

        #endregion

        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to show system Menu of window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen for Window Resizing
            mWindow.StateChanged += (sender, e) =>
            {
                //Fireoff event for all properties
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //Create Commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            //Fix Windows Resize issue
            var resizer = new WindowResizer(mWindow);
        }

        #region Helpers
        /// <summary>
        /// Get The current Mouse Position on screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            //Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);
            //Add Window position so its a "Toscreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        } 
        #endregion

    }
}
