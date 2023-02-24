using UnityEngine;
using Bag;

namespace MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        //public List<GameObject> holderList;

        // 获取鼠标世界坐标
        private Vector2 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        private ItemName currentItem; // 当前物体
        private GameObject currentObj = null;
        private bool canClick;
        private bool holdItem;
        private bool isSelected; // 是否被选中

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            ChangeMoveState();
        }

        #region 修改选中物体的移动状态

        private void ChangeMoveState()
        {
            // 判断场景中的物体是否可点击，返回碰撞体则为 true
            canClick = ObjectAtMousePosition();
            if (canClick && Input.GetMouseButtonDown(0))
            {
                var gameObj = ObjectAtMousePosition().gameObject;
                if (gameObj != currentObj && currentObj != null && isSelected)
                {
                    currentObj.GetComponent<MiniGameHolder>().EmptyClicked();
                }
                currentObj = gameObj;
                currentObj.GetComponent<MiniGameHolder>().EmptyClicked();
                isSelected = currentObj.GetComponent<MiniGameHolder>().isSelected;
                //Debug.Log(ObjectAtMousePosition().name);
                ClickAction(currentObj);
            }
        }

        #endregion 修改选中物体的移动状态

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
                        //interactive?.EmptyClicked();
                    }
                    break;
            }
        }

        #endregion 检测鼠标互动情况

        #region 检测鼠标点击范围的碰撞体

        private Collider2D ObjectAtMousePosition()
        {
            // 返回鼠标点击范围的碰撞体信息
            //Debug.Log(Physics2D.OverlapPoint(mouseWorldPos).name);
            //Debug.Log(mouseWorldPos);
            return Physics2D.OverlapPoint(mouseWorldPos);
        }

        #endregion 检测鼠标点击范围的碰撞体
    }
}