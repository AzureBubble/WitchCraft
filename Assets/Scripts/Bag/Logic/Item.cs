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
        private KeyCode pickupKeyCode = KeyCode.F;

        //[SerializeField]
        //private GameObject buttonF;
        private bool isPicked = false;

        public ItemName ItemName { get => itemName; private set => itemName = value; }

        private void Update()
        {
            //if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F))
            //{
            //    ItemClick();
            //}
        }

        #region ���ߵĵ���¼�

        public void ItemClick()
        {
            // ���ӵ������в����ص���
            if (!isPicked)
            {
                Debug.Log($"{this}: {itemName}.ItemCLick().");
                MainController.Instance.BagManger.AddItem(ItemName);
                //gameObject.SetActive(false);
            }
        }

        #endregion ���ߵĵ���¼�

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //buttonF.SetActive(true);
                MainController.Instance.InputManager.RegisterKeyDown(pickupKeyCode, ItemClick);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //buttonF.SetActive(false);
                MainController.Instance.InputManager.WithdrawKeyDown(pickupKeyCode, ItemClick);
            }
        }
    }
}