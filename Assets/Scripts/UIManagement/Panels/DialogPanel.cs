using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DialogSystem;
using MainControl;

namespace UIManagement.Panel
{
    public class DialogPanel : BasePanel
    {
        public static readonly string Path = "UIManagement/Panels/DialogPanel";
        private IDialogData data;

        public DialogPanel(IDialogData data) : base(Path)
        {
            this.data = data;
        }

        public override void OnEnter()
        {
            UITool.GetOrAddComponent<DialogShower>().SetDialogData(data);

            UITool.GetOrAddComponentInChildren<Button>("SkipButton").onClick.AddListener(() =>
            {
                Debug.Log($"{this}: skip button pressed.");
                MainController.Instance.UIManager.Pop();
            });
        }

    }
}
