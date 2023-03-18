using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainControl
{
    public class MCFactory
    {
        private Dictionary<string, GameObject> subSystems;

        public MCFactory()
        {
            subSystems = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// 载入某个子系统
        /// </summary>
        /// <param name="path">子系统路径</param>
        /// <returns></returns>
        public GameObject GetSubSystem(string path)
        {
            if (!subSystems.ContainsKey(path))
            {
                GameObject prefab = Resources.Load<GameObject>(path);
                GameObject instance = GameObject.Instantiate(prefab);
                instance.name = path[(path.LastIndexOf("/") + 1)..];
                subSystems.Add(path, instance);
            }

            return subSystems[path];
        }

        /// <summary>
        /// 删除某个子系统
        /// </summary>
        /// <param name="path">子系统路径</param>
        public void DestroySystem(string path)
        {
            if (!subSystems.ContainsKey(path)) return;

            GameObject.Destroy(subSystems[path]);
            subSystems.Remove(path);
        }
    }

}