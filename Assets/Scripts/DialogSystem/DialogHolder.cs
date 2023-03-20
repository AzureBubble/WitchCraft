using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using UIManagement.Panel;
using DialogSystem;

public class DialogHolder : MonoBehaviour
{
    private static readonly string iconPath = "UIManagement/DialogSystem/DialogHint";

    [SerializeField]
    private float Height = 1f;
    [SerializeField]
    private KeyCode dialogKeyCode = KeyCode.R;

    private GameObject dialogHintPrefab;
    private GameObject dialogHint;

    private void Awake()
    {
        dialogHintPrefab = Resources.Load<GameObject>(iconPath);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log($"{this}: player collision enter");
            dialogHint = GameObject.Instantiate(dialogHintPrefab, this.transform);
            dialogHint.transform.position = new Vector2(transform.position.x, transform.position.y + Height);
            MainController.Instance.InputManager.RegisterKeyDown(dialogKeyCode, OpenDialogPanel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log($"{this}: player collision exit");
            
            if (dialogHint != null)
            {
                Destroy(dialogHint);
                MainController.Instance.InputManager.WithdrawKeyDown(dialogKeyCode, OpenDialogPanel);
            }
        }
    }

    private void OpenDialogPanel()
    {
        MainController.Instance.UIManager.Push(new DialogPanel());
    }
}
