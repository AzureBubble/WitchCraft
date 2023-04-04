using System.Collections;
using UnityEngine;

using MainControl;

public class Interactive : MonoBehaviour
{
    [Header("�ɽ�����Ʒ��Ϣ")]
    [SerializeField]
    private ItemName requireItem; // ��Ʒ����

    private bool isDone; // �����Ƿ����

    public bool IsDone { get => isDone; set => isDone = value; }

    private void Start()
    {
        IEnumerator enumerator = ConnectBagManager();
        StartCoroutine(enumerator);
    }

    #region ������߼������

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !IsDone)
        {
            IsDone = true;
            OnClickedAction();
        }
        else
        {
            EmptyClicked();
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

    private IEnumerator ConnectBagManager()
    {
        while(MainController.Instance.BagManger == null)
        {
            yield return null;
        }
        MainController.Instance.BagManger.ItemConnect(name, gameObject);
    }
}