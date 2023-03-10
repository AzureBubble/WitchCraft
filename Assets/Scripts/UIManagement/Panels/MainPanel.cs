using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MainControl;
using SceneManagement.Scene;

namespace UIManagement.Panel
{
    public class MainPanel : BasePanel
    {
        public static readonly string Path = "UIManagement/Panels/MainPanel";

        public MainPanel() : base(Path) { }

        public override void OnEnter()
        {

            UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
            {
                MainController.Instance.SceneManager.SetScene(new StartGameScene());
            });
        }
    }
}
