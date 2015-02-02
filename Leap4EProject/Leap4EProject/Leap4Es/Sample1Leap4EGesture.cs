//
//  Test1Leap4EGesture
//  Leap4EProject.Leap4Es
//
//  Created by BillHuang on 2015/2/2 11:25:45.
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
    class Sample1Leap4EGesture : AbstractLeap4EGesture {

        #region [Field]

        #endregion

        #region [Properties]

        #endregion

        public Sample1Leap4EGesture() {

        }

        protected override void GestureDetection(LeapRawData leapRawData) {
            this.currentGestureState = Leap4EGestureState.START_STATE;
        }

        #region [Utility]

        #endregion

    }
}
