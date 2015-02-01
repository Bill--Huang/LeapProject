using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Leap;
using Leap4EProject.TestPart;

namespace Leap4EProject {
    public partial class MainWindow : Window {
        private TestListener listener;
        private Controller controller;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Set leap controller
            // Create a sample listener and controller
            this.listener = new TestListener();
            this.listener.OnFrameEvent += listener_OnFrameEvent;
            this.controller = new Controller();

            // Have the sample listener receive events from the controller
            this.controller.AddListener(this.listener);
        }

        void listener_OnFrameEvent(object sender, EventArgs e) {
            this.Dispatcher.BeginInvoke(new Action(delegate {
                //this.LeapStateLabel.Content = "connected";
            }), null);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            // Remove the sample listener when done
            this.controller.RemoveListener(this.listener);
            this.controller.Dispose();
        }
    }
}
