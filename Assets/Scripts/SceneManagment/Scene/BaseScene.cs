using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement.Scene
{
    public abstract class BaseScene
    {
        public string SceneName { get; private set; }
        public BaseScene(string sceneName)
        {
            SceneName = sceneName;
        }

        public abstract void OnEnter();

        public abstract void OnExit();
    }
}


