using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using MainControl;

public class Ghost : MonoBehaviour
{
    public Collider2D attackArea;
    public Transform target;
    public float moveSpeed = 3;
    public float waitForAttack = 0.5f;
    public float multipleSpeed = 0.01f;

    private float timer;
    private bool isWaiting = true;

    // Start is called before the first frame update
    private void Start()
    {
        //TODO:注释这个方法，对话完后调用这个方法，等待一定时间后，开始追逐玩家
        StartTime();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isWaiting && timer <= Time.time)
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
    }

    private void Move()
    {
        attackArea.enabled = true;
        moveSpeed += Time.deltaTime * multipleSpeed;
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed);
        }
    }

    public void StartTime()
    {
        isWaiting = false;
        timer = Time.time + waitForAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isWaiting = true;
            Debug.Log("You Lose!");
            MainController.Instance.OnDefeat();
        }
    }
}