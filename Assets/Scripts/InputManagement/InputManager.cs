using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputManagement
{
    public class InputManager : MonoBehaviour
    {
        public static string Path = "MainControl/InputManager";

        public Stack<InputKeyLayer> LayerStack { get; private set; }

        private void Awake()
        {
            LayerStack = new Stack<InputKeyLayer>();
            //PushLayer();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (LayerStack.Count == 0) return;
            IEnumerator[] enumerators = {
                KeyDownCoroutine(LayerStack.Peek().KeyDownDic),
                KeyStayCoroutine(LayerStack.Peek().KeyStayDic),
                KeyUpCoroutine(LayerStack.Peek().KeyUpDic)
            };
            foreach (var enumerator in enumerators)
            {
                StartCoroutine(enumerator);
            }
        }

        private IEnumerator KeyDownCoroutine(Dictionary<KeyCode, Action> keyMap)
        {
            if (Input.anyKeyDown)
            {
                foreach(var keyCode in keyMap.Keys)
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        keyMap[keyCode]?.Invoke();
                    }
                }
            }
            yield break;
        }

        private IEnumerator KeyStayCoroutine(Dictionary<KeyCode, Action> keyMap)
        {
            if (Input.anyKey)
            {
                foreach (var keyCode in keyMap.Keys)
                {
                    if (Input.GetKey(keyCode))
                    {
                        keyMap[keyCode]?.Invoke();
                    }
                }
            }
            yield break;
        }

        private IEnumerator KeyUpCoroutine(Dictionary<KeyCode, Action> keyMap)
        {
            if (!Input.anyKeyDown)
            {
                foreach (var keyCode in keyMap.Keys)
                {
                    if (Input.GetKeyUp(keyCode))
                    {
                        keyMap[keyCode]?.Invoke();
                    }
                }
            }
            yield break;
        }

        private void RegisterOnTopLayer(KeyCode code, Action callback, PressType type) 
        {
            if (LayerStack.Count > 0)
            {
                LayerStack.Peek().Register(code, callback, type);
            }
        }

        private void WithdrawOnTopLayer(KeyCode code, Action callback, PressType type)
        {
            if (LayerStack.Count > 0)
            {
                LayerStack.Peek().Withdraw(code, callback, type);
            }
        }

        /// <summary>
        /// 压入新的键盘映射
        /// </summary>
        public void PushLayer()
        {
            LayerStack.Push(new InputKeyLayer());
        }

        /// <summary>
        /// 退出当前键盘映射
        /// </summary>
        public void PopLayer()
        {
            if (LayerStack.Count > 0)
            {
                LayerStack.Pop();
            }
        }

        /// <summary>
        /// 注册键盘按下事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void RegisterKeyDown(KeyCode code, Action callback)
        {
            RegisterOnTopLayer(code, callback, PressType.Down);
        }

        /// <summary>
        /// 注册键盘按住事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void RegisterKeyStay(KeyCode code, Action callback)
        {
            RegisterOnTopLayer(code, callback, PressType.Stay);
        }

        /// <summary>
        /// 注册键盘抬起事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void RegisterKeyUp(KeyCode code, Action callback)
        {
            RegisterOnTopLayer(code, callback, PressType.Up);
        }

        /// <summary>
        /// 撤回键盘按下事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void WithdrawKeyDown(KeyCode code, Action callback)
        {
            WithdrawOnTopLayer(code, callback, PressType.Down);
        }

        /// <summary>
        /// 撤回键盘按住事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void WithdrawKeyStay(KeyCode code, Action callback)
        {
            WithdrawOnTopLayer(code, callback, PressType.Stay);
        }

        /// <summary>
        /// 撤回键盘抬起事件
        /// </summary>
        /// <param name="code">键盘按键</param>
        /// <param name="callback">按键触发后的回调函数(必须为返回值为void的无参函数)</param>
        public void WithdrawKeyUp(KeyCode code, Action callback)
        {
            WithdrawOnTopLayer(code, callback, PressType.Up);
        }
    }
}

