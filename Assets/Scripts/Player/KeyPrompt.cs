using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyPrompt : MonoBehaviour
{
    public GameObject ButtonR;
    public GameObject DialogPanel;

    public void Update()
    {
        if (ButtonR.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            ButtonRClick();
        }
        CloseDialog();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ButtonR.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ButtonR.SetActive(false);
        }
    }

    void ButtonRClick()
    {
        //角色与npc或场景对话，按R弹出对话框
        DialogPanel.SetActive(true);
    }
    void CloseDialog()
    {
        //按esc关闭对话框
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DialogPanel.SetActive(false);
        }
    }
    

}
