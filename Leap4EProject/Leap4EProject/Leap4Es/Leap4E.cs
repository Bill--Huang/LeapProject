//
//  Leap4E
//  Leap4EProject.Leap4Es
//
//  Created by BillHuang on 2015/2/1 17:03:42.
//  Copyright (c) Bill. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace Leap4EProject.Leap4Es {

    /// <summary>
    /// Leap4E: leap for education
    /// It contains LeapRawData & Leap4EGesture, and it refresh raw data and update all gesture info in update loop function (or use listener)
    /// ...
    /// </summary>
    class Leap4E : Listener {

        #region [Private Variables - Field]
        /// <summary>
        /// Leap Original Controller
        /// </summary>
        private Controller leapOriginalController;

        /// <summary>
        /// Contains all raw data from leap original controller in leap's library
        /// </summary>
        private LeapRawData leapRawData;

        /// <summary>
        /// Manage all gesture instance
        /// </summary>
        private Leap4EGestureManager leap4EGestureManager;

        private Object thisLock = new Object();
        #endregion

        #region [Properties]
        public LeapRawData RawData {
            get {
                return this.leapRawData;
            }
        }

        public Leap4EGestureManager GestureManager {
            get {
                return this.leap4EGestureManager;
            }
        }
        #endregion

        public Leap4E() {

            this.SafeWriteLine("Leap4E: Leap4E Init");
            //
            this.leapRawData = new LeapRawData();
            this.leap4EGestureManager = new Leap4EGestureManager(this);

            // init leap controller
            this.leapOriginalController = new Controller();
            this.leapOriginalController.AddListener(this);

            // init Timer

            // 
        }

        private void Update(Controller controller) {

            Frame frame = controller.Frame();

            this.leapRawData.LeapFrame = frame;
            this.leap4EGestureManager.UpdateGestures();

            //this.SafeWriteLine("Leap4E: Leap update");
            //this.SafeWriteLine("Frame id: " + frame.Id
            //            + ", timestamp: " + frame.Timestamp
            //            + ", hands: " + frame.Hands.Count
            //            + ", fingers: " + frame.Fingers.Count
            //            + ", tools: " + frame.Tools.Count
            //            + ", gestures: " + frame.Gestures().Count);
        }

        public new void Dispose() {
            this.leapOriginalController.RemoveListener(this);
            this.leapOriginalController.Dispose();
            this.SafeWriteLine("Leap4E: Dispose");
        }
        #region Override Function
        public override void OnInit(Controller controller) {
            this.SafeWriteLine("Leap4E: Leap Initialized");
        }

        public override void OnConnect(Controller controller) {
            this.SafeWriteLine("Leap4E: Leap Connected");
            //controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            //controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            //controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            //controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller) {
            //Note: not dispatched when running in a debugger.
            this.SafeWriteLine("Leap4E: Leap Disconnected");
        }

        public override void OnExit(Controller controller) {
            this.SafeWriteLine("Leap4E: Leap Exited");
        }

        public override void OnFrame(Controller controller) {
            this.Update(controller);
        }
        #endregion

        #region Utility Function
        private void SafeWriteLine(String line) {
            lock (thisLock) {
                Console.WriteLine(line);
            }
        }
        #endregion
    }
}
