using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;

using MainControl;
using UIManagement.UIManager;
using UIManagement.Panel;

namespace SceneManagement.Scene
{
    public class Level1Scene : BaseScene
    {
        private static string sceneName = "Level_01";

        public UIManager UIManager { get; private set; }

        public Level1Scene(): base(sceneName) { }

        public override void OnEnter()
        {
            Debug.Log($"{this}：开始加载场景{this.SceneName}");
            UnitySceneManager.LoadScene(this.SceneName);
            UnitySceneManager.sceneLoaded += SceneLoaded;
        }

        public override void OnExit()
        {
            UnitySceneManager.sceneLoaded -= SceneLoaded;
            MainController.Instance.UIManager.PopAll();
            MainController.Instance.InputManager.PopLayer();
        }

        private void SceneLoaded(UnityScene scene, LoadSceneMode mode)
        {
            Debug.Log($"{this}：场景加载完毕{this.SceneName}");

            UIManager = new UIManager();
            MainController.Instance.InputManager.PushLayer();
            MainController.Instance.UIManager.Push(new MainPanel());
            MainController.Instance.UIManager.Push(new DialogPanel(new DialogSystem.ListDialogData()));
        }
    }
}


