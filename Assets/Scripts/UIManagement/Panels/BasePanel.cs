using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement.Panel
{
    public abstract class BasePanel
    {
        public PanelType Type { get; private set; }

        public Dictionary<string, GameObject> InteractObjs { get; private set; }

        public BasePanel(string path)
        {
            Type = new PanelType(path);
        }

        public void SetInteractObjs(Dictionary<string, GameObject> dict)
        {
            InteractObjs = dict;
        }

        public virtual void OnEnter()
        {
            Debug.Log($"{this}: invoke OnEnter().");
        }

        public virtual void OnPause()
        {
            Debug.Log($"{this}: invoke OnPause().");
        }

        public virtual void OnResume()
        {
            Debug.Log($"{this}: invoke OnResume().");
        }

        public virtual void OnExit()
        {
            Debug.Log($"{this}: invoke OnExit().");
        }
    }
}


