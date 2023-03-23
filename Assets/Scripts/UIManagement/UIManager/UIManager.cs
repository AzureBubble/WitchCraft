using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIManagement.Panel;
using UIManagement.UITools;
using MainControl;

namespace UIManagement.UIManager
{
    public class UIManager: IUIManager
    {
        public Stack<BasePanel> PanelStack { get; private set; }

        private PanelFactory factory;

        public UIManager()
        {
            PanelStack = new Stack<BasePanel>();
            factory = new PanelFactory();
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

            GameObject panelObject = factory.GetSinglePanel(panel.Type);
            panel.SetUITool(new UITool(panelObject));
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
                factory.DestroyPanel(panel.Type);
            }
            
            if (PanelStack.Count > 0)
            {
                PanelStack.Peek().OnResume();
            }
        }

        public BasePanel Peek()
        {
            if (PanelStack.Count > 0)
            {
                return PanelStack.Peek();
            } else
            {
                return null;
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
                factory.DestroyPanel(panel.Type);
            }
        }
    }

    public interface IUIManager
    {
        public void Push(BasePanel panel);
        public void Pop();
        public BasePanel Peek();
        public void PopAll();
    }

}

