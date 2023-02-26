using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;           //角色刚体
    public float speed;              //角色移动速度
    public BoxCollider2D collcap;    //角色碰撞体

    void Start()
    {

    }

    void Update()
    {
        Movement(); //角色移动函数
    }

    void Movement() //角色移动函数
    {
        float horizontalmove = Input.GetAxis("Horizontal");   //水平移动

        rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);   //左右移动，x轴为速度，y轴不变

        //角色脸朝向
        if (horizontalmove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);   //设置x轴的1和-1决定角色脸朝向
        }
        else if (horizontalmove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
