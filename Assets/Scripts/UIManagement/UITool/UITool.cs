using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement.UITools 
{
    public class UITool
    {
        private GameObject targetUI;
        
        public Dictionary<string, GameObject> targets = new Dictionary<string, GameObject>();

        public UITool(GameObject ui = null)
        {
            if (ui != null)
                SetTargetUI(ui);
        }

        public UITool SetTargetUI(GameObject ui)
        {
            targetUI = ui;
            UISubObjectSet subObjSet = ui.GetComponent<UISubObjectSet>();
            if (subObjSet != null)
            {
                targets = subObjSet.subObjectDict;
            }
            
            return this;
        }

        public T GetOrAddComponentInChildren<T>(string subObjName) where T : Component
        {
            GameObject subObj = targets[subObjName];
            if (subObj.GetComponent<T>() == null)
            {
                subObj.AddComponent<T>();
            }

            return subObj.GetComponent<T>();
        }

        public T GetOrAddComponent<T>() where T : Component
        {
            if (targetUI.GetComponent<T>() == null)
            {
                targetUI.AddComponent<T>();
            }

            return targetUI.GetComponent<T>();
        }

    }
}
