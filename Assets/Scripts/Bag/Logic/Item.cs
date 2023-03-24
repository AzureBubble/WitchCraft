using MainControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bag
{
    public class Item : MonoBehaviour
    {
        [Header("道具属性")]
        [Tooltip("道具名字")]
        [SerializeField]
        private ItemName itemName;

        [SerializeField]
        private GameObject buttonF;

        public ItemName ItemName { get => itemName; private set => itemName = value; }

        private void Update()
        {
            if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F))
            {
                ItemClick();
            }
        }

        #region 道具的点击事件

        public void ItemClick()
        {
            // 添加到背包中并隐藏道具
            MainController.Instance.BagManger.AddItem(ItemName);
            gameObject.SetActive(false);
        }

        #endregion 道具的点击事件

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                buttonF.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                buttonF.SetActive(false);
            }
        }
    }
}