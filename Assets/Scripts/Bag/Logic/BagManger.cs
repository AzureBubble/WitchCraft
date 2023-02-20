using System.Collections;
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
}