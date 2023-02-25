using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManger : Singleton<BagManger>
{
    // ��ȡ����
    [SerializeField]
    private SO_ItemDataList itemData;

    // ��������
    [SerializeField]
    private List<ItemName> itemList = new List<ItemName>();

    #region ��ӵ��ߵ�������

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            // �����в����ڸ���������ӵ�������
            itemList.Add(itemName);
            // ͬʱ�ڱ��� UI ����ʾ����
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }

    #endregion ��ӵ��ߵ�������
}