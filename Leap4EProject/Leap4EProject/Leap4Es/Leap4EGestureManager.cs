//
//  Leap4EGestureManager
//  Leap4EProject.Leap4Es
//
//  Created by BillHuang on 2015/2/1 17:03:42.
//  Copyright (c) Bill. All rights reserved.
//
﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace Leap4EProject.Leap4Es {
    class Leap4EGestureManager {

        #region [Private Variables - Field]
        private List<AbstractLeap4EGesture> leap4EGestureList;
        #endregion

        public Leap4EGestureManager() {
            this.leap4EGestureList = new List<AbstractLeap4EGesture>();

            // Test
            this.leap4EGestureList.Add(new AbstractLeap4EGesture());

            // Add default gesture
        }

        public void UpdateGestures() {
            if (this.leap4EGestureList.Count <= 0) {
                return;
            }

            for (int i = 0; i < this.leap4EGestureList.Count; i++) {
                AbstractLeap4EGesture tempGesture = this.leap4EGestureList[i];
                tempGesture.Update();
            }
        }

        public bool Add(AbstractLeap4EGesture gesture) {
            return true;
        }

        public bool Remove(AbstractLeap4EGesture gesture) {
            return true;
        }

        public bool Contain(AbstractLeap4EGesture gesture) {
            return true;
        }
    }
}
