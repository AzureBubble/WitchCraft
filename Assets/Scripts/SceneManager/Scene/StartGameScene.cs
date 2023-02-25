using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;

namespace SceneManager.Scene
{
    public class StartGameScene : BaseScene
    {
        private static string sceneName = "StartGame";

        public StartGameScene(): base(sceneName) { }

        public override void OnEnter()
        {
            Debug.Log($"{this}����ʼ���س���{this.SceneName}");
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
            Debug.Log($"{this}�������������{this.SceneName}");


            //this.panelManager.Push(new StartPanel());
        }
    }
}


