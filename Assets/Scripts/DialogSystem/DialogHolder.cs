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
    private KeyCode dialogKeyCode = KeyCode.F;
    [SerializeField]
    private string textPath = "";

    private GameObject dialogHintPrefab;
    private GameObject dialogHint;

    private DialogLoader dialogLoader;
    private IDialogData dialogData;

    private void Awake()
    {
        dialogHintPrefab = Resources.Load<GameObject>(iconPath);
        dialogLoader = new DialogLoader();
        dialogData = dialogLoader.LoadDialogData(textPath);
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

            if (MainController.Instance.UIManager.Peek().Type.Name == "DialogPanel")
            {
                MainController.Instance.UIManager.Pop();
            }

            if (dialogHint != null)
            {
                Destroy(dialogHint);
                MainController.Instance.InputManager.WithdrawKeyDown(dialogKeyCode, OpenDialogPanel);
            }
        }
    }

    private void OpenDialogPanel()
    {
        dialogData.ResetIndex();
        MainController.Instance.UIManager.Push(new DialogPanel(dialogData));
    }
}
