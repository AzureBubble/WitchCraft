using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SceneManagement.Scene;
using MainControl;

namespace UIManagement.Panel
{
    public class StartGamePanel : BasePanel
    {
        public static readonly string Path = "UIManagement/Panels/StartGamePanel";

        public StartGamePanel() : base(Path) { }

        public override void OnEnter()
        {
            UITool.GetOrAddComponentInChildren<Button>("StartBtn").onClick.AddListener(() =>
            {
                MainController.Instance.SceneManager.SetScene(new Level1Scene());
            });

            UITool.GetOrAddComponentInChildren<Button>("LoadBtn").onClick.AddListener(() =>
            {
                Debug.Log($"{this}: press LoadBtn");
            });

            UITool.GetOrAddComponentInChildren<Button>("DevListBtn").onClick.AddListener(() =>
            {
                Debug.Log($"{this}: press DevListBtn");
            });

            UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

    }
}


