using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UIManagement.UITools;
using MainControl;

namespace DialogSystem
{
    public class DialogShower : MonoBehaviour
    {
        private Image avatar;
        private TextMeshProUGUI speaker;
        private TextMeshProUGUI content;
        private IDialogData data;
        private UITool tool;

        private bool isReady;
        private bool showing;
        private bool isSkip;

        private void Awake()
        {
            tool = new UITool(gameObject);
            isReady = false;
            showing = false;
            isSkip = false;
            data = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            avatar = tool.GetOrAddComponentInChildren<Image>("Role");
            speaker = tool.GetOrAddComponentInChildren<TextMeshProUGUI>("Speaker");
            content = tool.GetOrAddComponentInChildren<TextMeshProUGUI>("Dialog");

            speaker.text = "未知：";
            content.text = "";
        }

        // Update is called once per frame
        void Update()
        {
            if (isReady && !showing)
            {
                if (data.HasNext())
                {
                    content.text = "";
                    IEnumerator enumerator = ShowDialogCoroutine(data.GetNext());
                    StartCoroutine(enumerator);
                }
            }

            if (data != null && Input.GetMouseButtonDown(0))
            {
                if (isReady == true)
                {
                    isSkip = true;
                    return;
                }

                if (data.HasNext())
                {
                    isReady = true;
                }
                else
                {
                    MainController.Instance.UIManager.Pop();
                }
            }
        }

        private IEnumerator ShowDialogCoroutine(SingleDialog dialog)
        {
            showing = true;
            avatar.sprite = dialog.Avatar;
            speaker.text = dialog.Speaker;
            foreach(char each in dialog.Content)
            {
                if (isSkip)
                {
                    content.text = dialog.Content;
                    break;
                }
                content.text += each;
                yield return new WaitForSeconds(0.2f);
            }

            showing = false;
            isReady = false;
            isSkip = false;
        }

        public void SetDialogData(IDialogData data)
        {
            this.data = data;
            isReady = true;
        }

    }
}
