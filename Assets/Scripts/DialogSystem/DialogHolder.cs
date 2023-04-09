using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using UIManagement.Panel;
using DialogSystem.ButtonListener;

namespace DialogSystem
{
    public class DialogHolder : MonoBehaviour
    {
        [SerializeField]
        private KeyCode dialogKeyCode = KeyCode.F;
        [SerializeField]
        private int textIndex = 0;
       
        [SerializeField]
        private List<TextAsset> textAsset;
        
        private BaseButtonListener listener;
        private DialogLoader dialogLoader;
        private IDialogData dialogData;

        public int TextIndex
        {
            get
            {
                return textIndex;
            }
            set
            {
                textIndex = value;
            }
        }

        private void Awake()
        {
            listener = GetComponent<BaseButtonListener>();
            dialogLoader = new DialogLoader();
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
            dialogData = dialogLoader.LoadDialogData(textAsset[textIndex]);
            dialogData.ResetIndex();
            MainController.Instance.UIManager.Push(new DialogPanel(dialogData, listener));
        }
    }
}

