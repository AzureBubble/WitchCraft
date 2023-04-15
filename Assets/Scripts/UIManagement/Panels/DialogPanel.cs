using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DialogSystem;
using DialogSystem.ButtonListener;
using MainControl;

namespace UIManagement.Panel
{
    public class DialogPanel : BasePanel
    {
        public static readonly string Path = "UIManagement/Panels/DialogPanel";
        private IDialogData data;
        private BaseButtonListener listener;

        public DialogPanel(IDialogData data, BaseButtonListener listener = null) : base(Path)
        {
            this.data = data;
            this.listener = listener;
        }

        public override void OnEnter()
        {
            var panel = UITool.GetOrAddComponent<DialogShower>();
            panel.LoadBtnListener(listener);
            panel.SetDialogData(data);

            UITool.GetOrAddComponentInChildren<Button>("SkipButton").onClick.AddListener(() =>
            {
                MainController.Instance.BagManger.PlayClickMusic();
                Debug.Log($"{this}: skip button pressed.");
                MainController.Instance.UIManager.Pop();
            });
        }
    }
}