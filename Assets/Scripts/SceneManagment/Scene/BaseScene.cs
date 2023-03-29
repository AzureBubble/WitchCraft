using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SceneManagement.SceneAttribute;
using UnityEngine;

namespace SceneManagement.Scene
{
    public abstract class BaseScene
    {
        public string SceneName { get; private set; }

        private DynamicSceneState EnterState = DynamicSceneState.None;
        private List<EnterSceneAttribute> enterList;
        private DynamicSceneState ExitState = DynamicSceneState.None;
        private List<ExitSceneAttribute> exitList;

        public BaseScene(string sceneName)
        {
            SceneName = sceneName;
            EnterAttrInit();
            ExitAttrInit();
        }

        private void EnterAttrInit()
        {
            enterList = new List<EnterSceneAttribute>();
            foreach (var attr in this.GetType().GetCustomAttributes<EnterSceneAttribute>())
            {
                enterList.Add(attr);
            }
            Debug.Log($"{this}: enterAttributes = {enterList}");
            if (enterList.Count > 0)
            {
                EnterState = DynamicSceneState.Ready;
            }
        }

        private void ExitAttrInit()
        {
            exitList = new List<ExitSceneAttribute>();
            foreach (var attr in this.GetType().GetCustomAttributes<ExitSceneAttribute>())
            {
                exitList.Add(attr);
            }
            Debug.Log($"{this}: exitAttributes = {exitList}");
            if (exitList.Count > 0)
            {
                ExitState = DynamicSceneState.Ready;
            }
        }

        # region 静态切换场景，一帧完成
        public abstract void OnEnter();
        public abstract void OnExit();
        #endregion

        #region 动态切换场景，多帧完成
        public virtual void OnEnterDynamic()
        {
            EnterState = DynamicSceneState.Run;

            GameObject canvas = GameObject.Find("Canvas");
            Dictionary<string, GameObject> param = new Dictionary<string, GameObject>();
            param[canvas.name] = canvas;

            foreach (var attribute in enterList)
            {
                attribute.OnEnter(param, () => {
                    enterList.Remove(attribute);
                });
            }
        }
        public virtual void OnExitDynamic()
        {
            ExitState = DynamicSceneState.Run;

            GameObject canvas = GameObject.Find("Canvas");
            Dictionary<string, GameObject> param = new Dictionary<string, GameObject>();
            param[canvas.name] = canvas;

            foreach (var attribute in exitList)
            {
                attribute.OnExit(param, () => {
                    exitList.Remove(attribute);
                });
            }
        }

        public virtual DynamicSceneState GetEnterState()
        {
            if (enterList.Count == 0)
                EnterState = DynamicSceneState.End;
            return EnterState;
        }
        public virtual DynamicSceneState GetExitState()
        {
            if (exitList.Count == 0)
                ExitState = DynamicSceneState.End;
            return ExitState;
        }
        #endregion
    }

    public enum DynamicSceneState
    {
        None, Ready, Run, End
    }
}


