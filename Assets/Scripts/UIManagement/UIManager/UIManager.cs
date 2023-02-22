using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIManagement.Panel;

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
            SetIUIManager();
        }

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

        public void PopAll()
        {
            while (PanelStack.Count > 0)
            {
                var panel = PanelStack.Pop();
                panel.OnExit();
                Factory.DestroyPanel(panel.Type);
            }
        }

        public void SetIUIManager()
        {
            MainControl.MainController.Instance.IUIManager.Push += Push;
            MainControl.MainController.Instance.IUIManager.Pop += Pop;
            MainControl.MainController.Instance.IUIManager.PopAll += PopAll;
        }
    }
}

