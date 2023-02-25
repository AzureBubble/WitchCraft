using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // ��ȡ�����������
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y), 0);

    private ItemName currentItem; // ��ǰ����
    private bool canClick;
    private bool holdItem;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // �жϳ����е������Ƿ�ɵ����������ײ����Ϊ true
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

    #region �����껥�����

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

    #endregion �����껥�����

    #region ����������Χ����ײ��

    private Collider2D ObjectAtMousePosition()
    {
        // �����������Χ����ײ����Ϣ
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    #endregion ����������Χ����ײ��
}