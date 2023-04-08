using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUIControl_Test : MonoBehaviour
{
    [Header("对话UI")]
    [Tooltip("对话框按钮")]
    [SerializeField]
    public GameObject Button_dialogue;
    [Tooltip("对话框显示")]
    [SerializeField]
    //public GameObject TalkUI;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Button_dialogue.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Button_dialogue.SetActive(false);
            //TalkUI.SetActive(false);
        }

    }

    private void Update()
    {
        if(Button_dialogue.activeSelf && Input.GetKeyDown(KeyCode.F))

        {
            //TalkUI.SetActive(true);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
