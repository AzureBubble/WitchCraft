using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement.Scene;

namespace SceneManagement
{
    public class SceneManager
    {
        public BaseScene CurrentScene { get; private set; }

        public SceneManager()
        {
            CurrentScene = null;
        }

        /// <summary>
        /// 设置要切换的场景
        /// </summary>
        /// <param name="scene">要载入的场景</param>
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

        /// <summary>
        /// 重新加载当前场景
        /// </summary>
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


