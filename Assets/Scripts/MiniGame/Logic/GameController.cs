using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // 获取鼠标世界坐标
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y), 0);

    private ItemName currentItem; // 当前物体
    private bool canClick;
    private bool holdItem;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // 判断场景中的物体是否可点击，返回碰撞体则为 true
        canClick = ObjectAtMousePosition();
        if (canClick && Input.GetMouseButtonDown(0))
        {
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        holdItem = isSelected;
        if (isSelected)
        {
            currentItem = itemDetails.itemName;
        }
    }

    #region 检测鼠标互动情况

    private void ClickAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Interactive":
                var interactive = clickObject.GetComponent<Interactive>();
                if (holdItem)
                {
                    interactive?.CheckItem(currentItem);
                }
                else
                {
                    interactive?.EmptyClicked();
                }
                break;
        }
    }

    #endregion 检测鼠标互动情况

    #region 检测鼠标点击范围的碰撞体

    private Collider2D ObjectAtMousePosition()
    {
        // 返回鼠标点击范围的碰撞体信息
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    #endregion 检测鼠标点击范围的碰撞体
}