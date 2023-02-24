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
            // 获得当前道具信息
            currentItem = itemDetails;
            // 使道具可见
            this.gameObject.SetActive(true);
            itemImage.sprite = itemDetails.itemSprite;
            itemImage.color = Color.yellow;
            itemImage.SetNativeSize();
        }

        public void SetEmpty()
        {
            // 使道具不可见
            this.gameObject.SetActive(false);
        }
    }
}