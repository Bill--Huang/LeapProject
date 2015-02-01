﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Leap;

namespace Leap4EProject.TestPart {
    class TestListener : Listener {
        private Object thisLock = new Object();

        public event EventHandler OnFrameEvent = null;

        private void SafeWriteLine(String line) {
            lock (thisLock) {
                Console.WriteLine(line);
                //this.leapStateLabel.Content = line;
            }
        }

        public override void OnInit(Controller controller) {
            SafeWriteLine("Initialized");
        }

        public override void OnConnect(Controller controller) {
            SafeWriteLine("Connected");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller) {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine("Disconnected");
        }

        public override void OnExit(Controller controller) {
            SafeWriteLine("Exited");
        }

        public override void OnFrame(Controller controller) {
            // Get the most recent frame and report some basic information

            if (OnFrameEvent != null) {
                OnFrameEvent.Invoke(controller, null);
            }

            Frame frame = controller.Frame();

            SafeWriteLine("Frame id: " + frame.Id
                        + ", timestamp: " + frame.Timestamp
                        + ", hands: " + frame.Hands.Count
                        + ", fingers: " + frame.Fingers.Count
                        + ", tools: " + frame.Tools.Count
                        + ", gestures: " + frame.Gestures().Count);

            //foreach (Hand hand in frame.Hands) {
            //    SafeWriteLine("  Hand id: " + hand.Id
            //                + ", palm position: " + hand.PalmPosition);
            //    // Get the hand's normal vector and direction
            //    Vector normal = hand.PalmNormal;
            //    Vector direction = hand.Direction;

            //    // Calculate the hand's pitch, roll, and yaw angles
            //    SafeWriteLine("  Hand pitch: " + direction.Pitch * 180.0f / (float)Math.PI + " degrees, "
            //                + "roll: " + normal.Roll * 180.0f / (float)Math.PI + " degrees, "
            //                + "yaw: " + direction.Yaw * 180.0f / (float)Math.PI + " degrees");
            //}

            if (!frame.Hands.IsEmpty || !frame.Gestures().IsEmpty) {
                SafeWriteLine("");
            }
        }
    
    }
}
