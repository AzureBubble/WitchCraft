using System.Collections.Generic;
using UnityEngine;

public class BagManger : Singleton<BagManger>
{
    // 获取背包
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
}