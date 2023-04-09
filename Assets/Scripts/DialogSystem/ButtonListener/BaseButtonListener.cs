using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem.ButtonListener {
    public abstract class BaseButtonListener: MonoBehaviour
    {
        public Dictionary<string, List<Action<DialogShower>>> Listeners = new Dictionary<string, List<Action<DialogShower>>>();
    }
}
