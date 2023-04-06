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
    public GameObject Bag;  //��������
    void Awake()
    {
        Clickable._instance = new Clickable();
    }
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
        Click();    //���������¼�
    }

    private void Click()
    {
        if(Input.GetKeyDown(KeyCode.F) && Clickable._instance.ClickableF == 1)
        {
            Debug.Log("������F");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Bag.activeSelf == false)
            {
                Bag.SetActive(true);
            }
            else
            {
                Bag.SetActive(false);
            }

        }
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
            faceturn = 0;
        }
    }

    private void Animationswitch()   //�����л�����
    {
        if (rb.velocity.x < 0.1f && rb.velocity.x > -0.1f && rb.velocity.y < 0.1f && rb.velocity.y > -0.1f)
        {
            anim.SetBool("rightwalk", false);
            anim.SetBool("leftwalk", false);
            anim.SetBool("rightstand", true);
            anim.SetBool("leftstand", true);
        }
        else if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
        {
            if (faceturn == 1) //������
            {
                anim.SetBool("rightwalk", true);
                anim.SetBool("leftwalk", false);
            }
            else if (faceturn == 0)    //������
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