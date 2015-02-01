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
    using Leap4Es;

    public partial class MainWindow : Window {
        //private TestListener listener;
        //private Controller controller;

        private Leap4E leap4E;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Set leap controller
            // Create a sample listener and controller
            //this.listener = new TestListener();
            //this.listener.OnFrameEvent += listener_OnFrameEvent;
            //this.controller = new Controller();

            //// Have the sample listener receive events from the controller
            //this.controller.AddListener(this.listener);

            this.leap4E = new Leap4E();
        }

        //void listener_OnFrameEvent(object sender, EventArgs e) {
        //    this.Dispatcher.BeginInvoke(new Action(delegate {
        //        //this.LeapStateLabel.Content = "connected";
        //    }), null);
        //}

        private void Window_Closed(object sender, EventArgs e) {
            this.leap4E.Dispose();
        }
    }
}
