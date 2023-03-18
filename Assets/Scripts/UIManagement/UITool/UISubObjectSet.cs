using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement.UITools
{
    public class UISubObjectSet : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> subObjects;

        public Dictionary<string, GameObject> subObjectDict { get; private set; }

        private void Awake()
        {
            subObjectDict = new Dictionary<string, GameObject>();
            foreach (var obj in subObjects)
            {
                subObjectDict.Add(obj.name, obj);
            }
        }
    }
}

