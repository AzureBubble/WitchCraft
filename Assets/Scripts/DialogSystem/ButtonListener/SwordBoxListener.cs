using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using Bag;

namespace DialogSystem.ButtonListener
{
    public class SwordBoxListener : BaseButtonListener
    {
        private void Awake()
        {
            Listeners["GetSwordBtn"] = new List<System.Action<DialogShower>>
            {
                (shower) =>
                {
                    GetComponent<Item>().ItemClick();
                    GetComponent<DialogHolder>().TextIndex = 1;
                }
            };

            Listeners["CancelBtn"] = new List<System.Action<DialogShower>>
            {
                (shower) =>
                {
                    if (MainController.Instance.UIManager.Peek().Type.Name == "DialogPanel")
                        MainController.Instance.UIManager.Pop();
                }
            };
        }
    }
}


