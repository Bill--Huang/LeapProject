//
//  LeapRawData
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
    class LeapRawData {

        #region [Private Variables - Field]
        private Frame leapFrame;
        #endregion

        #region [Properties]
        public Frame LeapFrame {
            get {
                return this.leapFrame;
            }
            set {
                this.leapFrame = value;
            }
        }
        #endregion

        public LeapRawData() {

        }

    }
}
