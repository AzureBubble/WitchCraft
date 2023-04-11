using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using Bag;

namespace DialogSystem.ButtonListener
{
    public class InterStaffListener : BaseButtonListener
    {
        private void Awake()
        {
            Listeners["Confirm"] = new List<System.Action<DialogShower>>
            {
                (shower) =>
                {
                    GetComponent<Item>().ItemClick();
                    Destroy(gameObject);
                }
            };

            Listeners["Cancel"] = new List<System.Action<DialogShower>>
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


