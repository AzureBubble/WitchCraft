using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using DialogSystem.ButtonListener;
using UIManagement.UITools;
using MainControl;

namespace DialogSystem
{
    public class DialogShower : MonoBehaviour
    {
        private Image avatar;
        private TextMeshProUGUI speaker;
        private TextMeshProUGUI content;

        private static readonly string dialogButtonPath = "UIManagement/DialogSystem/DialogButton";
        private UITool tool;
        private GameObject dialogButtonPrefab;

        private DialogState state;
        private List<Button> buttons;

        private IDialogData data;
        private BaseButtonListener listener;
        Coroutine mouseEventHandler;

        private void Awake()
        {
            dialogButtonPrefab = Resources.Load<GameObject>(dialogButtonPath);
            tool = new UITool(gameObject);
            buttons = new List<Button>();
            state = DialogState.None;
            data = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            avatar = tool.GetOrAddComponentInChildren<Image>("Role");
            speaker = tool.GetOrAddComponentInChildren<TextMeshProUGUI>("Speaker");
            content = tool.GetOrAddComponentInChildren<TextMeshProUGUI>("Dialog");

            mouseEventHandler = StartCoroutine(MouseHandlerCoroutine());
            StartCoroutine(ShowDialogCoroutine());

        }

        private IEnumerator ShowDialogCoroutine()
        {
            while(state != DialogState.Ready)
            {
                yield return null;
            }

            while(state != DialogState.End)
            {
                Coroutine singleDialogCoroutine = StartCoroutine(ShowSingleDialogCoroutine());
                yield return singleDialogCoroutine;
                yield return new WaitUntil(() => {
                    return state != DialogState.Block;
                });
            }

            StopCoroutine(mouseEventHandler);
            MainController.Instance.UIManager.Pop();
        }

        private IEnumerator ShowSingleDialogCoroutine()
        {
            if (!data.HasNext())
            {
                state = DialogState.End;
                yield break;
            }

            state = DialogState.Show;
            speaker.text = "";
            content.text = "";
            foreach(Button button in buttons)
            {
                DestroyImmediate(button.gameObject);
            }
            buttons.Clear();

            SingleDialog dialog = data.GetNext();
            Debug.Log($"{this}: Buttons Count {dialog.Buttons.Count}");

            var avatarShower = StartCoroutine(ResizeAvatarCoroutine(dialog.Avatar));
            yield return avatarShower;

            speaker.text = dialog.Speaker;
            foreach(char each in dialog.Content)
            {
                if (state == DialogState.Block)
                {
                    content.text = dialog.Content;
                    break;
                }
                content.text += each;
                yield return new WaitForSeconds(0.2f);
            }

            var buttonShower = StartCoroutine(ShowDialogButtonCoroutine(dialog.Buttons));
            yield return buttonShower;

            state = DialogState.Block;

        }

        private IEnumerator ResizeAvatarCoroutine(Sprite sprite)
        {
            float width = avatar.GetComponent<RectTransform>().sizeDelta.x;
            float scale = width / sprite.bounds.size.x;
            float height = sprite.bounds.size.y * scale;
            avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(avatar.GetComponent<RectTransform>().sizeDelta.x, height);
            avatar.sprite = sprite;
            yield break;
        }

        private IEnumerator ShowDialogButtonCoroutine(List<string> buttons)
        {
            foreach(string button in buttons)
            {
                //获取button配置
                var btnNameTextPair = button.Split("/");
                string btnName = btnNameTextPair[0], btnText = btnNameTextPair[1];
                GameObject btnObj = GameObject.Instantiate(dialogButtonPrefab, tool.targets["Options"].transform);
                btnObj.name = btnName;
                new UITool(btnObj).GetOrAddComponentInChildren<TextMeshProUGUI>("Text (TMP)").text = btnText;

                //生成button
                Button btn = btnObj.GetComponent<Button>();
                this.buttons.Add(btn);
                
                // 给Button添加点击事件
                btn.onClick.AddListener(() => {
                    state = DialogState.Wait;
                });
                if (listener && listener.Listeners.ContainsKey(btnName))
                {
                    foreach (var listener in listener.Listeners[btnName])
                    {
                        btn.onClick.AddListener(() => {
                            listener.Invoke(this);
                        });
                    }
                }
            }
            yield break;
        }

        private IEnumerator MouseHandlerCoroutine()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    switch (state)
                    {
                        case DialogState.Show:
                            state = DialogState.Block;
                            break;
                        case DialogState.Block:
                            if (buttons.Count > 0)
                                break;
                            state = DialogState.Wait;
                            break;
                        default:
                            break;
                    }
                }
                yield return null;
            }
        }

        public void SetDialogData(IDialogData data)
        {
            this.data = data;
            state = DialogState.Ready;
        }

        public void LoadBtnListener(BaseButtonListener listener)
        {
            this.listener = listener;
        }

    }

    public enum DialogState
    {
        None, Ready, Show, Block, Wait, End
    }
}
