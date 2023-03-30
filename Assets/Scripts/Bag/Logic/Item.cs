using MainControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bag
{
    public class Item : MonoBehaviour
    {
        [Header("��������")]
        [Tooltip("��������")]
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

        #region ���ߵĵ���¼�

        public void ItemClick()
        {
            // ��ӵ������в����ص���
            MainController.Instance.BagManger.AddItem(ItemName);
            gameObject.SetActive(false);
        }

        #endregion ���ߵĵ���¼�

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