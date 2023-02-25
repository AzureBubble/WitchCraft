using UnityEngine;
using Bag;

namespace MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        //public List<GameObject> holderList;

        // ��ȡ�����������
        private Vector2 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        private ItemName currentItem; // ��ǰ����
        private GameObject currentObj = null;
        private bool canClick;
        private bool holdItem;
        private bool isSelected; // �Ƿ�ѡ��

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            ChangeMoveState();
        }

        #region �޸�ѡ��������ƶ�״̬

        private void ChangeMoveState()
        {
            // �жϳ����е������Ƿ�ɵ����������ײ����Ϊ true
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

        #endregion �޸�ѡ��������ƶ�״̬

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
                        //interactive?.EmptyClicked();
                    }
                    break;
            }
        }

        #endregion �����껥�����

        #region ����������Χ����ײ��

        private Collider2D ObjectAtMousePosition()
        {
            // �����������Χ����ײ����Ϣ
            //Debug.Log(Physics2D.OverlapPoint(mouseWorldPos).name);
            //Debug.Log(mouseWorldPos);
            return Physics2D.OverlapPoint(mouseWorldPos);
        }

        #endregion ����������Χ����ײ��
    }
}