using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManagement.BackpackSystem;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityScene = UnityEngine.SceneManagement.Scene;

using MainControl;
using SceneManagement.Scene;
using UIManagement.Panel;
using UIManagement.UIManager;
using UnityEngine.Rendering.Universal;

namespace Bag
{
    public class BagManger : MonoBehaviour
    {
        public static readonly string Path = "MainControl/BagManger";
        public PlayerController player;

        // 保存场景中的道具状态
        private Dictionary<ItemName, bool> itemAvaiableDict = new Dictionary<ItemName, bool>();

        // 保存场景中的互动物品的状态
        private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();

        // 获取背包数据结构
        [SerializeField]
        private SO_ItemDataList itemData;

        // 背包链表
        [SerializeField]
        private List<ItemName> itemList = new List<ItemName>();

        [SerializeField]
        private GameObject copperLight;

        private IBackpackUI backPackUI = null;

        private Dictionary<string, GameObject> connectedItems = new Dictionary<string, GameObject>();

        #region 添加道具到背包中

        public void AddItem(ItemName itemName)
        {
            if (!itemList.Contains(itemName))
            {
                // 背包中不存在该数据则添加到背包里
                itemList.Add(itemName);
                Debug.Log("添加 " + itemName + " 成功！");
                //EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
                //TODO：获取道具的名字和图片信息
                //itemData.GetItemDetails(itemName).itemSprite;
                backPackUI.AddItemUI(itemName);
            }
        }

        public void RemoveItem(ItemName itemName)
        {
            if (itemList.Contains(itemName))
            {
                itemList.Remove(itemName);
                backPackUI.RemoveItemUI(itemName);
            }
        }

        #endregion 添加道具到背包中

        #region 使用道具

        public void UseProps(ItemName itemName)
        {
            Debug.Log($"{this}: {itemName} clicked");
            switch (itemName)
            {
                case ItemName.Item:
                    RemoveItem(itemName);
                    break;

                case ItemName.Light:
                    Debug.Log("使用 " + itemName + " 成功！");
                    Light2D light = GameObject.Find("Player").GetComponentInChildren<Light2D>();
                    if (light)
                    {
                        light.enabled = !light.enabled;
                    }
                    //TODO:更改提灯动作
                    player = GameObject.Find("Player").GetComponent<PlayerController>();
                    if (player.Takelamp == 1)
                    {
                        player.Takelamp = 0;  // 将player脚本的拿灯状态设置为false
                    }
                    else if (player.Takelamp == 0)
                    {
                        player.Takelamp = 1;  // 将player脚本的拿灯状态设置为true
                    }
                    break;

                case ItemName.Sword:
                    bool success = connectedItems["Alter-Door"].GetComponent<AlterDoor>().CheckItem(itemName);
                    Debug.Log("使用 " + itemName + " 成功！");
                    if (success)
                    {
                        RemoveItem(itemName);
                    }
                    break;

                case ItemName.Staff:
                    var ghost = GameObject.Find("Ghost");
                    if (ghost != null)
                    {
                        Debug.Log($"{this}: find ghost {ghost}");
                        Debug.Log("使用 " + itemName + " 成功！");
                        Destroy(ghost);
                        RemoveItem(itemName);
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion 使用道具

        #region 场景加载前执行的方法

        private void OnBeforeSceneUnLoadEvent()
        {
            // 找到当前场景中的所有道具 Item
            foreach (var item in FindObjectsOfType<Item>())
            {
                // 如果道具状态字典中不存在改道具，则添加进字典里
                if (!itemAvaiableDict.ContainsKey(item.ItemName))
                {
                    itemAvaiableDict.Add(item.ItemName, true);
                }
            }
            // 找到当前场景中的所有交互物品
            foreach (var item in FindObjectsOfType<Interactive>())
            {
                // 如果道具状态字典中不存在改道具，则添加进字典里
                if (!interactiveStateDict.ContainsKey(item.name))
                {
                    interactiveStateDict[item.name] = item.IsDone;
                }
                else
                {
                    interactiveStateDict.Add(item.name, item.IsDone);
                }
            }
        }

        #endregion 场景加载前执行的方法

        #region 场景加载后执行的方法

        private void OnAfterSceneLoadEvent()
        {
            // 找到当前场景中的所有道具 Item
            foreach (var item in FindObjectsOfType<Item>())
            {
                // 如果道具状态字典中不存在改道具，则添加进字典里
                if (!itemAvaiableDict.ContainsKey(item.ItemName))
                {
                    itemAvaiableDict.Add(item.ItemName, true);
                }
                else
                {
                    // 设置场景中道具显示状态是字典中的状态
                    item.gameObject.SetActive(itemAvaiableDict[item.ItemName]);
                }
            }

            // 找到当前场景中的所有交互物品
            foreach (var item in FindObjectsOfType<Interactive>())
            {
                // 如果道具状态字典中不存在改道具，则添加进字典里
                if (!interactiveStateDict.ContainsKey(item.name))
                {
                    item.IsDone = interactiveStateDict[item.name];
                }
                else
                {
                    interactiveStateDict.Add(item.name, item.IsDone);
                }
            }
        }

        #endregion 场景加载后执行的方法

        #region 拾取道具的时候，修改道具的状态位不可见

        private void OnUpdateUIEvent(ItemDetails itemDetails)
        {
            // 拾取道具的时候，修改道具的状态为不可见
            if (itemDetails != null)
            {
                itemAvaiableDict[itemDetails.itemName] = false;
            }
        }

        #endregion 拾取道具的时候，修改道具的状态位不可见

        // 背包后端前端链接方法与回调
        public void SetBackpackUI(IBackpackUI backpack, Action callback)
        {
            this.backPackUI = backpack;
            callback.Invoke();
        }

        // 场景链接互动物体对象
        public void ItemConnect(string name, GameObject obj)
        {
            connectedItems.Add(name, obj);
        }

        // 清除场景互动对象
        public void CleanConncectedItems()
        {
            connectedItems.Clear();
        }

        // 场景切换时BagManager的处理，由场景类调用
        public void OnSceneExit()
        {
            backPackUI = null;
            CleanConncectedItems();
            UnitySceneManager.sceneLoaded += SceneLoaded;
        }

        private void SceneLoaded(UnityScene scene, LoadSceneMode mode)
        {
            IEnumerator enumerator = RecoverBackpackUICoroutine();
            StartCoroutine(enumerator);
            UnitySceneManager.sceneLoaded -= SceneLoaded;
        }

        private IEnumerator RecoverBackpackUICoroutine()
        {
            while (backPackUI == null)
            {
                yield return null;
            }
            foreach (var item in itemList)
            {
                backPackUI.AddItemUI(item);
            }
        }
    }
}