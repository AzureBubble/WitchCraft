using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("��������")]
    [SerializeField]
    private ItemName itemName;

    #region ���ߵĵ���¼�

    public void ItemClick()
    {
        // ��ӵ������в����ص���
        BagManger.Instance.AddItem(itemName);
        gameObject.SetActive(false);
    }

    #endregion ���ߵĵ���¼�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ItemClick();
        }
    }
}