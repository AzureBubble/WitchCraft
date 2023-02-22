using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIManagement.Panel;

namespace MainControl.Interface
{
    public class IUIManager
    {
        public Action<BasePanel> Push;
        public Action Pop;
        public Action PopAll;
    }
}
