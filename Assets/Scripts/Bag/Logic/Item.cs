using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("道具属性")]
    [Tooltip("道具名字")]
    [SerializeField]
    private ItemName itemName;

    #region 道具的点击事件

    public void ItemClick()
    {
        // 添加到背包中并隐藏道具
        BagManger.Instance.AddItem(itemName);
        gameObject.SetActive(false);
    }

    #endregion 道具的点击事件

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ItemClick();
        }
    }
}