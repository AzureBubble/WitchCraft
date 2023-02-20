using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ItemDataList", menuName = "Bag/SO_ItemDataList")]
public class SO_ItemDataList : ScriptableObject
{
    public List<ItemDetails> itemDetailsList; // 道具信息列表

    #region 通过道具名获取道具信息

    public ItemDetails GetItemDetails(ItemName itemName)
    {
        return itemDetailsList.Find(i => i.itemName == itemName);
    }

    #endregion 通过道具名获取道具信息
}