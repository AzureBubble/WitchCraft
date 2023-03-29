using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement.Scene;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;

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

        public BaseScene CurrentScene()
        {
            return currentScene;
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

        private IEnumerator SetSceneCoroutine(BaseScene scene)
        {
            if (currentScene != null && currentScene.SceneName != scene.SceneName)
            {
                IEnumerator enumerator = OnExitSceneLoaded();
                Coroutine exitCoroutine = StartCoroutine(enumerator);
                yield return exitCoroutine;
            }
            SetScene(scene);
            UnitySceneManager.sceneLoaded += SceneLoaded;
        }

        private IEnumerator OnEnterSceneLoaded()
        {
            if (currentScene != null &&
                currentScene.GetEnterState() != DynamicSceneState.None)
            {
                currentScene.OnEnterDynamic();
                while (currentScene.GetEnterState() != DynamicSceneState.End)
                    yield return null;
            }
        }

        private IEnumerator OnExitSceneLoaded()
        {
            if (currentScene != null &&
                currentScene.GetExitState() != DynamicSceneState.None)
            {
                currentScene.OnExitDynamic();
                while (currentScene.GetExitState() != DynamicSceneState.End)
                    yield return null;
            }
        }

        private void SceneLoaded(UnityScene scene, LoadSceneMode mode)
        {
            IEnumerator enumerator = OnEnterSceneLoaded();
            StartCoroutine(enumerator);
            UnitySceneManager.sceneLoaded -= SceneLoaded;
        }

        public void DynamicSetScene(BaseScene scene)
        {
            IEnumerator enumerator = SetSceneCoroutine(scene);
            StartCoroutine(enumerator);
        }

        public void ResetScene()
        {
            if (this.currentScene != null)
            {
                this.currentScene.OnExit();
                this.currentScene.OnEnter();
            }
        }

        private IEnumerator ResetSceneCoroutine()
        {
            if (currentScene != null)
            {
                IEnumerator enumerator = OnExitSceneLoaded();
                Coroutine exitCoroutine = StartCoroutine(enumerator);
                yield return exitCoroutine;
            }

            this.ResetScene();
            UnitySceneManager.sceneLoaded += SceneLoaded;
        }

        public void DynamicResetScene()
        {
            if (currentScene != null)
            {
                IEnumerator enumerator = ResetSceneCoroutine();
                StartCoroutine(enumerator);
            }
        }

    }

    public interface ISceneManager
    {
        public BaseScene CurrentScene();
        public void SetScene(BaseScene scene);
        public void DynamicSetScene(BaseScene scene);
        public void ResetScene();
        public void DynamicResetScene();
    }
}


