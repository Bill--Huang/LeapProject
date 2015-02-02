//
//  AbstractLeap4EGesture
//  Leap4EProject.Leap4Es
//
//  Created by BillHuang on 2015/2/1 17:33:37.
//  Copyright (c) Bill. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Leap;

namespace Leap4EProject.Leap4Es {

    enum Leap4EGestureState {
        NONE_STATE,
        START_STATE,
        // Processing
        UPDATE_STATE,
        // Unfinished
        STOP_STATE,
        // finished
        FINISH_STATE,
    }

    class AbstractLeap4EGesture {
        
        /// <summary>
        /// Custom Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GestureStateEventHandler(object sender, Leap4EEventArgs e);

        public event GestureStateEventHandler OnGestureStartState;
        public event GestureStateEventHandler OnGestureUpdateState;
        public event GestureStateEventHandler OnGestureFinishState;
        public event GestureStateEventHandler OnGestureStopState;
        
        protected Leap4EGestureState currentGestureState = Leap4EGestureState.NONE_STATE;

        protected LeapRawData leapRawData;
        public AbstractLeap4EGesture() {
            Console.WriteLine("AbstractLeap4EGesture Init");
        }

        public void Update(LeapRawData leapRawData) {
            this.leapRawData = leapRawData;
            //Console.WriteLine("AbstractLeap4EGesture Update");
            this.GestureDetection(this.leapRawData);
            this.RunGestureHandler();
        }

        protected void RunGestureHandler() {
            switch (this.currentGestureState) {
                case Leap4EGestureState.NONE_STATE:
                    break;
                case Leap4EGestureState.START_STATE:
                    this.InvokeEventHandle(this.OnGestureStartState);
                    break;
                case Leap4EGestureState.UPDATE_STATE:
                    this.InvokeEventHandle(this.OnGestureUpdateState);
                    break;
                case Leap4EGestureState.FINISH_STATE:
                    this.InvokeEventHandle(this.OnGestureFinishState);
                    // this.currentGestureState = Leap4EGestureState.NONE_STATE;
                    break;
                case Leap4EGestureState.STOP_STATE:
                    this.InvokeEventHandle(this.OnGestureStopState);
                    // this.currentGestureState = Leap4EGestureState.NONE_STATE;
                    break;
            }
        }

        protected void InvokeEventHandle(GestureStateEventHandler handler) {
            if (handler != null) {
                handler.Invoke(this, new Leap4EEventArgs(this.leapRawData));
            }
        }

        protected virtual void GestureDetection(LeapRawData leapRawData) {
            this.currentGestureState = Leap4EGestureState.FINISH_STATE;
        }
    }
}
