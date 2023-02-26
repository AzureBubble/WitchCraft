using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIManagement.UITools;

namespace UIManagement.Panel
{
    public abstract class BasePanel
    {
        public PanelType Type { get; private set; }

        public UITool UITool { get; private set; }

        public BasePanel(string path)
        {
            Type = new PanelType(path);
        }

        public void SetUITool(UITool tool)
        {
            UITool = tool;
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


