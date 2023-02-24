using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;

using UIManagement.UIManager;
using UIManagement.Panel;

namespace SceneManagement.Scene
{
    public class StartGameScene : BaseScene
    {
        private static string sceneName = "StartGame";

        public UIManager UIManager { get; private set; }

        public StartGameScene(): base(sceneName)
        {
            
        }

        public override void OnEnter()
        {
            Debug.Log($"{this}: Start to load {this.SceneName}");
            //this.panelManager = new PanelManager(new PanelFactory());
            UnitySceneManager.LoadScene(this.SceneName);
            UnitySceneManager.sceneLoaded += SceneLoaded;
        }

        public override void OnExit()
        {
            UnitySceneManager.sceneLoaded -= SceneLoaded;
            //this.panelManager.PopAll();
        }

        private void SceneLoaded(UnityScene scene, LoadSceneMode mode)
        {
            Debug.Log($"{this}: scene load already {this.SceneName}");
            UIManager = new UIManager();
            MainControl.MainController.Instance.UIManager.Push(new StartGamePanel());

        }
    }
}


