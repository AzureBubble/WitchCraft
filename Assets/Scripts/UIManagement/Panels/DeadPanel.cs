using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MainControl;
using SceneManagement.Scene;

namespace UIManagement.Panel
{
    public class DeadPanel : BasePanel
    {
        public static readonly string Path = "UIManagement/Panels/DeadPanel";

        public DeadPanel() : base(Path) { }

        public override void OnEnter()
        {

            UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
            {
                MainController.Instance.SceneManager.DynamicSetScene(new StartGameScene());
            });
        }
    }
}
