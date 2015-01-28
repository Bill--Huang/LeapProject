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

namespace LeapTest {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            
            // set leap controller
            // Create a sample listener and controller
            SampleListener listener = new SampleListener();
            listener.leapInfoLabel = this.LeapInfoLabel;
            listener.leapStateLabel = this.LeapStateLabel;
            Controller controller = new Controller();

            // Have the sample listener receive events from the controller
            controller.AddListener(listener);

            // Keep this process running until Enter is pressed
            //Console.WriteLine("Press Enter to quit...");
            //Console.ReadLine();

            //// Remove the sample listener when done
            //controller.RemoveListener(listener);
            //controller.Dispose();
        }
    }
}
