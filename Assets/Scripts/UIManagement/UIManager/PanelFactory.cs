using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement.UIManager
{
    public class PanelFactory
    {
        private Dictionary<PanelType, GameObject> factory;

        private GameObject canvas;

        public PanelFactory()
        {
            factory = new Dictionary<PanelType, GameObject>();
            canvas = GameObject.Find("Canvas");
        }

        public GameObject GetSinglePanel(PanelType type)
        {
            if (factory.ContainsKey(type))
            {
                return factory[type];
            }
            else
            {
                if (canvas == null)
                {
                    Debug.Log($"{this}: Canvas not found.");
                    return null;
                }
                GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), canvas.transform);
                panel.name = type.Name;
                return panel;
            }
        }

        public void DestroyPanel(PanelType type)
        {
            if (factory.ContainsKey(type))
            {
                GameObject.Destroy(factory[type]);
                factory.Remove(type);
            }
        }

    }
}


