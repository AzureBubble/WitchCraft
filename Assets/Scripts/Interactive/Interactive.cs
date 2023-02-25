using UnityEngine;

public class Interactive : MonoBehaviour
{
    [Header("�ɽ�����Ʒ��Ϣ")]
    [SerializeField]
    private ItemName requireItem; // ��Ʒ����

    private bool isDone; // �����Ƿ����

    public bool IsDone { get => isDone; set => isDone = value; }

    #region ������߼������

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !IsDone)
        {
            IsDone = true;
            OnClickedAction();
        }
    }

    #endregion ������߼������

    #region Ĭ������ȷ����Ʒ�����ִ��

    protected virtual void OnClickedAction()
    {
    }

    #endregion Ĭ������ȷ����Ʒ�����ִ��

    #region ����Ʒʱ��ĵ���¼�

    public virtual void EmptyClicked()
    {
        Debug.Log("�յ�");
    }

    #endregion ����Ʒʱ��ĵ���¼�
}