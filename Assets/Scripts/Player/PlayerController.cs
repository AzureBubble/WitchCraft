using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;           //角色刚体
    public float speed = 3;              //角色移动速度
    public BoxCollider2D collcap;    //角色碰撞体
    public Animator anim;
    float faceturn;

    void Start()
    {

    }

    void Update()
    {
        Movement(); //角色移动函数
        Animationswitch();  //动画切换函数
    }

    void Movement() //角色移动函数
    {
        float horizontalmove = Input.GetAxis("Horizontal");   //水平移动
        float verticalmove = Input.GetAxisRaw("Vertical");    //垂直移动

        rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);   //左右移动，x轴为速度，y轴不变
        rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);     //上下移动，y轴为速度，x轴不变
        //角色脸朝向
        if (horizontalmove > 0)
        {
            faceturn = 1;
        }
        else if (horizontalmove < 0)
        {
            faceturn = 0;
        }
    }

    void Animationswitch()   //动画切换函数
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
            if(faceturn==1) //向右走
            {
                anim.SetBool("rightwalk", true);
                anim.SetBool("leftwalk", false);
            }
            else if(faceturn==0)    //向左走
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
