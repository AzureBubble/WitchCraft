using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;
using UnityEngine;

namespace SceneManagement.Scene
{
    public class LockMiniGame : BaseScene
    {
        private static string sceneName = "LockMiniGame";

        public LockMiniGame() : base(sceneName)
        {
        }

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