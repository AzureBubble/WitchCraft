using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using MainControl;
using UIManagement.UITools;

namespace UIManagement.BackpackSystem
{
    public class BackpackUI : MonoBehaviour, IBackpackUI
    {
        private static readonly string uiPath = "UIManagement/ItemUIs/";

        [SerializeField]
        private KeyCode openKeyCode = KeyCode.B;

        [SerializeField]
        private bool isAppear;

        [SerializeField]
        private float fadeTime = 1;

        private UITool tool;

        private GameObject backPackContent;

        private void Awake()
        {
            isAppear = false;
            tool = new UITool(gameObject);
            tool.GetOrAddComponent<CanvasGroup>().interactable = false;
            tool.GetOrAddComponent<CanvasGroup>().DOFade(0, 0);
            MainController.Instance.BackpackUI = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            backPackContent = transform.Find("Viewport/Content").gameObject;
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
            
            Debug.Log($"{this}: bind '=' KeyCode to add an ItemUI for testing.");
            MainController.Instance.InputManager.RegisterKeyDown(KeyCode.Equals, () =>
            {
                MainController.Instance.BackpackUI.AddItemUI("ItemUI", () =>
                {
                    Debug.Log("ItemUI clicked.");
                    MainController.Instance.BackpackUI.RemoveItemUI("ItemUI");
                });
            });
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

        public void AddItemUI(string name, Action action)
        {
            GameObject prefab = Resources.Load<GameObject>(uiPath + name);
            if (prefab != null) 
            {
                GameObject item = GameObject.Instantiate(prefab, this.backPackContent.transform);
                item.name = prefab.name;
                Button btn = item.GetComponentInChildren<Button>();
                btn.onClick.AddListener(()=>
                {
                    action();
                });
                Debug.Log($"{this}: backpack add an item - {item.name}");
            }
        }

        public void RemoveItemUI(string name)
        {
            GameObject item = this.backPackContent.transform.Find(name).gameObject;
            if (item != null)
            {
                Destroy(item);
                Debug.Log($"{this}: backpack remove an item - {name}");
            }
        }
    }


    public interface IBackpackUI
    {
        /// <summary>
        /// 给背包添加物品
        /// </summary>
        /// <param name="name">物品名</param>
        /// <param name="action">回调方法</param>
        void AddItemUI(string name, Action action);
        /// <summary>
        /// 给背包删除物品
        /// </summary>
        /// <param name="name">物品名</param>
        void RemoveItemUI(string name);
    }
}

