using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    // ����ʵ��
    public static Clickable _instance;

    // ȫ�ֱ���
    public int Fclickable = 0;


    // �����ķ�����
    public int ClickableF   //��ȡ������F�Ƿ�ɰ���״̬
    {
        get { return Fclickable; }
        set { Fclickable = value; }
    }

    void Update()
    {

    }

}
