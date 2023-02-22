using System.Collections.Generic;
using UnityEngine;

public class BagManger : Singleton<BagManger>
{
    // 保存场景中的道具状态
    private Dictionary<ItemName, bool> itemAvaiableDict = new Dictionary<ItemName, bool>();

    // 获取背包数据结构
    [SerializeField]
    private SO_ItemDataList itemData;

    // 背包链表
    [SerializeField]
    private List<ItemName> itemList = new List<ItemName>();

    [SerializeField]
    private GameObject copperLight;

    private void Update()
    {
        UseProps();
    }

    #region 添加道具到背包中

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            // 背包中不存在该数据则添加到背包里
            itemList.Add(itemName);
            // 同时在背包 UI 中显示出来
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }

    #endregion 添加道具到背包中

    #region 使用道具

    private void UseProps()
    {
        // 使用道具栏 1 的道具
        if (Input.GetKeyDown(KeyCode.Alpha1) && itemList.Contains(ItemName.Light))
        {
            copperLight.SetActive(!copperLight.activeSelf);
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
}