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

        private Leap4E leap4E;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            // Set leap controller
            this.leap4E = new Leap4E();

            // Add Sample Gesture
            Sample1Leap4EGesture gesture1 = new Sample1Leap4EGesture();
            gesture1.OnGestureStartState += new AbstractLeap4EGesture.GestureStateEventHandler(this.gesture1StartStateEvent);
            this.leap4E.GestureManager.Add(gesture1);

            Sample2Leap4EGesture gesture2 = new Sample2Leap4EGesture();
            gesture2.OnGestureFinishState += new AbstractLeap4EGesture.GestureStateEventHandler(this.gesture2FinishStateEvent);
            this.leap4E.GestureManager.Add(gesture2);
        }

        private void Window_Closed(object sender, EventArgs e) {
            this.leap4E.Dispose();
        }

        #region [Sample Gesture Event Handler]
        // for Sample1Leap4EGesture
        private void gesture1StartStateEvent(object sender, Leap4EEventArgs e) {
            Console.WriteLine("Gesture 1 Start State Event");
            this.Dispatcher.BeginInvoke(new Action(delegate {
                //this.LeapStateLabel.Content = "connected";
            }), null);
        }

        // for Sample2Leap4EGesture
        private void gesture2FinishStateEvent(object sender, Leap4EEventArgs e) {
            Console.WriteLine("Gesture 2 Finish State Event");
            this.Dispatcher.BeginInvoke(new Action(delegate {
                //this.LeapStateLabel.Content = "connected";
            }), null);
        }
        #endregion

    }
}
