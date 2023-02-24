using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIManagement.Panel;
using MainControl;

namespace UIManagement.UIManager
{
    public class UIManager
    {
        public Stack<BasePanel> PanelStack { get; private set; }

        public PanelFactory Factory { get; private set; }

        public UIManager()
        {
            PanelStack = new Stack<BasePanel>();
            Factory = new PanelFactory();
            MainController.Instance.UIManager = this;
        }

        /// <summary>
        /// UI界面显示新面板
        /// </summary>
        /// <param name="panel">新面板</param>
        public void Push(BasePanel panel)
        {
            if (PanelStack.Count > 0)
            {
                PanelStack.Peek().OnPause();
            }

            GameObject panelObject = Factory.GetSinglePanel(panel.Type);
            panel.SetInteractObjs(panelObject.GetComponent<InteractList>().InteractObjectDict);
            panel.OnEnter();
            PanelStack.Push(panel);
        }

        /// <summary>
        /// UI界面移除最新的面板
        /// </summary>
        public void Pop()
        {
            if (PanelStack.Count > 0)
            {
                var panel = PanelStack.Pop();
                panel.OnExit();
                Factory.DestroyPanel(panel.Type);
            }
            
            if (PanelStack.Count > 0)
            {
                PanelStack.Peek().OnResume();
            }
        }

        /// <summary>
        /// UI界面清空
        /// </summary>
        public void PopAll()
        {
            while (PanelStack.Count > 0)
            {
                var panel = PanelStack.Pop();
                panel.OnExit();
                Factory.DestroyPanel(panel.Type);
            }
        }
    }
}

