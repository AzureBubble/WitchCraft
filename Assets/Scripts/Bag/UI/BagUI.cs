using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bag
{
    public class BagUI : MonoBehaviour
    {
        // 新增test
        public Button test;
        public Button leftBtn;
        public Button rightBtn;
        public ItemUI itemUI;
        public int currentIndex; // 显示道具序号

        private void OnEnable()
        {
            EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        }

        private void OnDestroy()
        {
            EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
        }

        private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            if (itemDetails == null)
            {
                itemUI.SetEmpty();
                currentIndex = -1;
                leftBtn.interactable = false;
                rightBtn.interactable = false;
            }
            else
            {
                currentIndex = index;
                itemUI.SetItem(itemDetails);
            }
        }
    }
}