using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bag
{
    public class ItemUI : MonoBehaviour
    {
        public Image itemImage;

        private ItemDetails currentItem;
        private bool isSelect;

        public void SetItem(ItemDetails itemDetails)
        {
            // ��õ�ǰ������Ϣ
            currentItem = itemDetails;
            // ʹ���߿ɼ�
            this.gameObject.SetActive(true);
            itemImage.sprite = itemDetails.itemSprite;
            itemImage.color = Color.yellow;
            itemImage.SetNativeSize();
        }

        public void SetEmpty()
        {
            // ʹ���߲��ɼ�
            this.gameObject.SetActive(false);
        }
    }
}