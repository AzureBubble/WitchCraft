using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;              //��ɫ�ƶ��ٶ�
    private BoxCollider2D collcap;    //��ɫ��ײ��
    private Animator anim;
    private Rigidbody2D rb;           //��ɫ����
    private float faceturn;
    private int lamp = 0;           //�Ƿ��õ�

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collcap = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement(); //��ɫ�ƶ�����
        Animationswitch();  //�����л�����
    }
    public int Takelamp   //��ȡ�������Ƿ��õ�
    {
        get { return lamp; }
        set { lamp = value; }
    }
    private void Movement() //��ɫ�ƶ�����
    {
        float horizontalmove = Input.GetAxis("Horizontal");   //ˮƽ�ƶ�
        float verticalmove = Input.GetAxisRaw("Vertical");    //��ֱ�ƶ�

        rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);   //�����ƶ���x��Ϊ�ٶȣ�y�᲻��
        rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);     //�����ƶ���y��Ϊ�ٶȣ�x�᲻��
        //��ɫ������
        if (horizontalmove > 0)
        {
            faceturn = 1;
        }
        else if (horizontalmove < 0)
        {
            faceturn = -1;
        }
    }

    private void Animationswitch()   //�����л�����
    {
        if(lamp==0)
        {
            anim.SetBool("lamp", false);
        }
        else if(lamp == 1)
        {
            anim.SetBool("lamp", true);
        }
        if (rb.velocity.x < 0.1f && rb.velocity.x > -0.1f && rb.velocity.y < 0.1f && rb.velocity.y > -0.1f)
        {
            anim.SetBool("rightwalk", false);
            anim.SetBool("leftwalk", false);
            if(faceturn==1)
            {
                anim.SetBool("rightstand", true);
                anim.SetBool("leftstand", false);
            }
            else if(faceturn == -1)
            {
                anim.SetBool("rightstand", false);
                anim.SetBool("leftstand", true);
            }
        }
        else if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
        {
            if (faceturn == 1) //������
            {
                anim.SetBool("rightwalk", true);
                anim.SetBool("leftwalk", false);
            }
            else if (faceturn == -1)    //������
            {
                anim.SetBool("rightwalk", false);
                anim.SetBool("leftwalk", true);
            }
            anim.SetBool("rightstand", false);
            anim.SetBool("leftstand", false);
        }
        else if (rb.velocity.x > 0.1f)
        {
            anim.SetBool("rightwalk", true);
            anim.SetBool("leftwalk", false);
            anim.SetBool("rightstand", false);
            anim.SetBool("leftstand", false);
        }
        else if (rb.velocity.x < -0.1f)
        {
            anim.SetBool("rightwalk", false);
            anim.SetBool("leftwalk", true);
            anim.SetBool("rightstand", false);
            anim.SetBool("leftstand", false);
        }
    }
}