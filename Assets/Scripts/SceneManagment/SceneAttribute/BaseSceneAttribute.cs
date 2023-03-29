using System;
using System.Collections;
using System.Collections.Generic;
using SceneManagement.Scene;
using UnityEngine;

namespace SceneManagement.SceneAttribute
{
    public abstract class EnterSceneAttribute : Attribute
    {
        /// <summary>
        /// 场景进入调用方法动态
        /// </summary>
        /// <param name="dict">传入参数（可在BaseScene中添加所需参数）</param>
        /// <param name="endCall">本属性结束后主动调用的回调方法（不调用会进入死循环）</param>
        public abstract void OnEnter(Dictionary<string, GameObject> dict, Action endCall);
    }

    public abstract class ExitSceneAttribute: Attribute
    {
        /// <summary>
        /// 场景退出调用方法动态
        /// </summary>
        /// <param name="dict">传入参数（可在BaseScene中添加所需参数）</param>
        /// <param name="endCall">本属性结束后主动调用的回调方法（不调用会进入死循环）</param>
        public abstract void OnExit(Dictionary<string, GameObject> dict, Action endCall);
    }
}


