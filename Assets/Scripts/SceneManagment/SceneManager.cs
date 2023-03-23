using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement.Scene;

namespace SceneManagement
{
    public class SceneManager: MonoBehaviour, ISceneManager
    {
        public static readonly string Path = "MainControl/SceneManager";

        private BaseScene currentScene;

        void Awake()
        {
            currentScene = null;
        }

        public void SetScene(BaseScene scene)
        {
            if (this.currentScene != null && this.currentScene.SceneName != scene.SceneName)
            {
                currentScene.OnExit();
            }
            this.currentScene = scene;
            if (this.currentScene != null)
            {
                currentScene.OnEnter();
            }
        }

        public BaseScene CurrentScene()
        {
            return currentScene;
        }

        public void ResetScene()
        {
            if (this.currentScene != null)
            {
                this.currentScene.OnExit();
                this.currentScene.OnEnter();
            }
        }

    }

    public interface ISceneManager
    {
        public void SetScene(BaseScene scene);
        public BaseScene CurrentScene();
        public void ResetScene();
    }
}


