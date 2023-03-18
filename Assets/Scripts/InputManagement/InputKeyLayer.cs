using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputManagement
{
    public class InputKeyLayer
    {
        public Dictionary<KeyCode, Action> KeyDownDic { get; private set; }

        public Dictionary<KeyCode, Action> KeyStayDic { get; private set; }

        public Dictionary<KeyCode, Action> KeyUpDic { get; private set; }

        public InputKeyLayer()
        {
            KeyDownDic = new Dictionary<KeyCode, Action>();
            KeyStayDic = new Dictionary<KeyCode, Action>();
            KeyUpDic = new Dictionary<KeyCode, Action>();
        }

        public void Register(KeyCode code, Action action, PressType type)
        {

            Dictionary<KeyCode, Action> dic;
            switch (type)
            {
                case PressType.Down:
                    dic = KeyDownDic;
                    break;
                case PressType.Stay:
                    dic = KeyStayDic;
                    break;
                case PressType.Up:
                    dic = KeyUpDic;
                    break;
                default:
                    return;
            }

            if (dic.ContainsKey(code))
            {
                dic[code] += action;
                return;
            }
            dic.Add(code, action);
        }

        public void Withdraw(KeyCode code, Action action, PressType type)
        {
            Dictionary<KeyCode, Action> dic;
            switch (type)
            {
                case PressType.Down:
                    dic = KeyDownDic;
                    break;
                case PressType.Stay:
                    dic = KeyStayDic;
                    break;
                case PressType.Up:
                    dic = KeyUpDic;
                    break;
                default:
                    return;
            }

            if (!dic.ContainsKey(code)) return;
            dic[code] -= action;
            if (dic[code] == null)
            {
                dic.Remove(code);
            }
        }
    }

    public enum PressType
    {
        Down,
        Stay,
        Up
    }

}


