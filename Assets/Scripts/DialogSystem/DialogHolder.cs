using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using UIManagement.Panel;
using DialogSystem;

public class DialogHolder : MonoBehaviour
{
    [SerializeField]
    private KeyCode dialogKeyCode = KeyCode.F;
    [SerializeField]
    private TextAsset textAsset;

    private DialogLoader dialogLoader;
    private IDialogData dialogData;

    private void Awake()
    {
        dialogLoader = new DialogLoader();
        dialogData = dialogLoader.LoadDialogData(textAsset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{this}: player collision enter");
            MainController.Instance.InputManager.RegisterKeyDown(dialogKeyCode, OpenDialogPanel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{this}: player collision exit");
            MainController.Instance.InputManager.WithdrawKeyDown(dialogKeyCode, OpenDialogPanel);
            if (MainController.Instance.UIManager.Peek().Type.Name == "DialogPanel")
            {
                MainController.Instance.UIManager.Pop();
            }
        }
    }

    private void OpenDialogPanel()
    {
        dialogData.ResetIndex();
        MainController.Instance.UIManager.Push(new DialogPanel(dialogData));
    }
}
