using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    public class InteractList : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> interactLists;

        public Dictionary<string, GameObject> InteractObjectDict { get; private set; }

        private void Awake()
        {
            InteractObjectDict = new Dictionary<string, GameObject>();
            foreach (var obj in interactLists)
            {
                InteractObjectDict.Add(obj.name, obj);
            }
        }
    }
}

