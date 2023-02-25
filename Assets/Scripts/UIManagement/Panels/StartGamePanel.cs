using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SceneManagement.Scene;

namespace UIManagement.Panel
{
    public class StartGamePanel : BasePanel
    {
        public static string Path = "UIManagement/Panels/StartGamePanel";

        public StartGamePanel() : base(Path) { }

        public override void OnEnter()
        {
            InteractObjs["StartBtn"].GetComponent<Button>().onClick.AddListener(() =>
            {
                MainControl.MainController.Instance.SceneManager.SetScene(new Level1Scene());
            });

            InteractObjs["LoadBtn"].GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log($"{this}: press LoadBtn");
            });

            InteractObjs["DevListBtn"].GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log($"{this}: press DevListBtn");
            });

            InteractObjs["ExitBtn"].GetComponent<Button>().onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

    }
}


