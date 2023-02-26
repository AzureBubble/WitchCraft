using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using MainControl;
using UIManagement.UITools;

namespace UIManagement.BackpackSystem
{
    public class BackpackUI : MonoBehaviour
    {
        [SerializeField]
        private KeyCode openKeyCode = KeyCode.B;

        [SerializeField]
        private bool isAppear;

        [SerializeField]
        private float fadeTime = 1;

        private UITool tool;

        private void Awake()
        {
            isAppear = false;
            tool = new UITool(gameObject);
            tool.GetOrAddComponent<CanvasGroup>().interactable = false;
            tool.GetOrAddComponent<CanvasGroup>().DOFade(0, 0);
        }

        // Start is called before the first frame update
        void Start()
        {
            KeyBoardBind();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void KeyBoardBind()
        {
            Debug.Log($"{this}: bind openKeycode to {openKeyCode}");
            MainController.Instance.InputManager.RegisterKeyDown(openKeyCode, OpenKeyCallBack);
        }

        private void OpenKeyCallBack()
        {
            SwitchActiveStatus();
        }

        private void SwitchActiveStatus()
        {
            if (isAppear)
            {
                Disappear();
            } else
            {
                Appear();
            }
        }

        private void Appear()
        {
            Debug.Log($"{this}: open backpack");
            isAppear = true;
            tool.GetOrAddComponent<CanvasGroup>().DOFade(1, 0.5f);
            tool.GetOrAddComponent<CanvasGroup>().interactable = true;

        }

        private void Disappear()
        {
            Debug.Log($"{this}: hide backpack");
            isAppear = false;
            tool.GetOrAddComponent<CanvasGroup>().interactable = false;
            tool.GetOrAddComponent<CanvasGroup>().DOFade(0, 0.5f);

        }
    }
}

