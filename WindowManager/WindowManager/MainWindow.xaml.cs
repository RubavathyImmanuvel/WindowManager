using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace WindowManager
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public MainWindow()
        {
            InitializeComponent();
            LoadActiveWindows();
        }

        private void LoadActiveWindows()
        {
            List<WindowItem> windows = new List<WindowItem>();
            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    System.Text.StringBuilder windowText = new System.Text.StringBuilder(256);
                    GetWindowText(hWnd, windowText, 256);
                    if (!string.IsNullOrWhiteSpace(windowText.ToString()))
                    {
                        windows.Add(new WindowItem { Handle = hWnd, Title = windowText.ToString() });
                    }
                }
                return true;
            }, IntPtr.Zero);

            WindowsList.ItemsSource = windows;
        }

        private void MoveWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowsList.SelectedItem is WindowItem selectedWindow)
            {
                // Example: Move window to the top-left corner of the primary screen
                SetWindowPos(selectedWindow.Handle, IntPtr.Zero, 0, 0, 800, 600, 0x0040); // SWP_SHOWWINDOW
            }
        }

        private void ArrangeWindowsButton_Click(object sender, RoutedEventArgs e)
        {
            var windows = WindowsList.ItemsSource.Cast<WindowItem>().ToList();
            int screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            int columns = 2; // Example for a grid layout
            int rows = (int)Math.Ceiling((double)windows.Count / columns);
            int windowWidth = screenWidth / columns;
            int windowHeight = screenHeight / rows;

            for (int i = 0; i < windows.Count; i++)
            {
                int x = (i % columns) * windowWidth;
                int y = (i / columns) * windowHeight;
                SetWindowPos(windows[i].Handle, IntPtr.Zero, x, y, windowWidth, windowHeight, 0x0040);
            }
        }

    }

    public class WindowItem
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }
    }
}