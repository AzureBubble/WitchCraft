using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;           //��ɫ����
    public float speed;              //��ɫ�ƶ��ٶ�
    public BoxCollider2D collcap;    //��ɫ��ײ��

    void Start()
    {

    }

    void Update()
    {
        Movement(); //��ɫ�ƶ�����
    }

    void Movement() //��ɫ�ƶ�����
    {
        float horizontalmove = Input.GetAxis("Horizontal");   //ˮƽ�ƶ�

        rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);   //�����ƶ���x��Ϊ�ٶȣ�y�᲻��

        //��ɫ������
        if (horizontalmove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);   //����x���1��-1������ɫ������
        }
        else if (horizontalmove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
