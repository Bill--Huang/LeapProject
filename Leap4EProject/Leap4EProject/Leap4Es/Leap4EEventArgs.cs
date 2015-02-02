//
//  Leap4EEventArgs
//  Leap4EProject.Leap4Es
//
//  Created by BillHuang on 2015/2/2 13:44:27.
//  Copyright (c) Bill. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap4EProject.Leap4Es {
    class Leap4EEventArgs : EventArgs {

        #region [Field]
        private LeapRawData leapRawData;
        #endregion

        #region [Properties]
        public LeapRawData RawData {
            get {
                return this.leapRawData;
            }
        }
        #endregion

        public Leap4EEventArgs(LeapRawData data) {
            this.leapRawData = data;
        }

        #region [Utility]

        #endregion

    }
}
