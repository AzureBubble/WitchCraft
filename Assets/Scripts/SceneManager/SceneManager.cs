using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManager.Scene;

namespace SceneManager
{
    public class SceneManager
    {
        public BaseScene CurrentScene { get; private set; }

        public SceneManager()
        {
            CurrentScene = null;
        }

        public void SetScene(BaseScene scene)
        {
            if (this.CurrentScene != null && this.CurrentScene.SceneName != scene.SceneName)
            {
                CurrentScene.OnExit();
            }
            this.CurrentScene = scene;
            if (this.CurrentScene != null)
            {
                CurrentScene.OnEnter();
            }
        }

        public void ResetScene()
        {
            if (this.CurrentScene != null)
            {
                this.CurrentScene.OnExit();
                this.CurrentScene.OnEnter();
            }
        }

    }

}


