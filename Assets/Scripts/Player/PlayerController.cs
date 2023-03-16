using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;           //��ɫ����
    public float speed = 3;              //��ɫ�ƶ��ٶ�
    public BoxCollider2D collcap;    //��ɫ��ײ��
    public Animator anim;
    float faceturn;

    void Start()
    {

    }

    void Update()
    {
        Movement(); //��ɫ�ƶ�����
        Animationswitch();  //�����л�����
    }

    void Movement() //��ɫ�ƶ�����
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
            faceturn = 0;
        }
    }

    void Animationswitch()   //�����л�����
    {
        if (rb.velocity.x < 0.1f && rb.velocity.x > -0.1f && rb.velocity.y < 0.1f && rb.velocity.y > -0.1f)
        {
            anim.SetBool("rightwalk", false);
            anim.SetBool("leftwalk", false);
            anim.SetBool("rightstand", true);
            anim.SetBool("leftstand", true);
        }
        else if(rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
        {
            if(faceturn==1) //������
            {
                anim.SetBool("rightwalk", true);
                anim.SetBool("leftwalk", false);
            }
            else if(faceturn==0)    //������
            {
                anim.SetBool("rightwalk", false);
                anim.SetBool("leftwalk", true);
            }
            anim.SetBool("rightstand", false);
            anim.SetBool("leftstand", false);
        }
        else if (rb.velocity.x>0.1f)
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
