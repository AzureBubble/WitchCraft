using UnityEngine;

public class Interactive : MonoBehaviour
{
    [Header("可交互物品信息")]
    [SerializeField]
    private ItemName requireItem; // 物品名称

    private bool isDone; // 互动是否结束

    public bool IsDone { get => isDone; set => isDone = value; }

    #region 鼠标射线检测物体

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !IsDone)
        {
            IsDone = true;
            OnClickedAction();
        }
    }

    #endregion 鼠标射线检测物体

    #region 默认是正确的物品的情况执行

    protected virtual void OnClickedAction()
    {
    }

    #endregion 默认是正确的物品的情况执行

    #region 空物品时候的点击事件

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }

    #endregion 空物品时候的点击事件
}