using System;
using System.Collections.Generic;
using UnityEngine;
using UIManagement.BackpackSystem;

namespace Bag
{
    public class BagManger : MonoBehaviour
    {
        public static readonly string Path = "MainControl/BagManger";

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

        private IBackpackUI backPackUI;

        private void Update()
        {
            //UseProps();
        }

        #region 添加道具到背包中

        public void AddItem(ItemName itemName)
        {
            if (!itemList.Contains(itemName))
            {
                // 背包中不存在该数据则添加到背包里
                itemList.Add(itemName);
                //TODO: 同时在背包 UI 中显示出来
                //EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
                backPackUI.AddItemUI(itemName);
            }
        }

        #endregion 添加道具到背包中

        #region 使用道具

        public void UseProps(ItemName itemName)
        {
            switch(itemName)
            {
                case ItemName.Item:
                    Debug.Log($"{this}: invoke item {itemName}.");
                    itemList.Remove(itemName);
                    backPackUI.RemoveItemUI(itemName);
                    break;
                case ItemName.Light:
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

        public void SetBackpackUI(IBackpackUI backpack, Action callback)
        {
            this.backPackUI = backpack;
            callback.Invoke();
        }
    }
}