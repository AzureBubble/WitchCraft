using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement.SceneAttribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class FadeInAttribute : EnterSceneAttribute
    {
        public override void OnEnter(Dictionary<string, GameObject> dict, Action endCall)
        {
            GameObject canvasObj = dict["Canvas"];
            GameObject prefab = Resources.Load<GameObject>("UIManagement/Panels/FadeCover");
            GameObject fade = GameObject.Instantiate(prefab, canvasObj.transform);
            FadeCover fadecover = fade.GetComponent<FadeCover>();
            fadecover.SetInitColor(Color.black);
            fadecover.FadeIn(endCall);
        }
    }
}