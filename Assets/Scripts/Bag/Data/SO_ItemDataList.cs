using System.Collections.Generic;
using UnityEngine;

namespace Bag
{
    [CreateAssetMenu(fileName = "SO_ItemDataList", menuName = "Bag/SO_ItemDataList")]
    public class SO_ItemDataList : ScriptableObject
    {
        public List<ItemDetails> itemDetailsList; // ������Ϣ�б�

        #region ͨ����������ȡ������Ϣ

        public ItemDetails GetItemDetails(ItemName itemName)
        {
            return itemDetailsList.Find(i => i.itemName == itemName);
        }

        #endregion ͨ����������ȡ������Ϣ
    }
}