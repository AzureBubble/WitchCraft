using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using SceneManagement.Scene;

namespace DialogSystem.ButtonListener
{
    public class Door2Listener : BaseButtonListener
    {
        private void Awake()
        {
            Listeners["Confirm"] = new List<System.Action<DialogShower>>();
            Listeners["Confirm"].Add((shower) => {
                MainController.Instance.SceneManager.DynamicSetScene(new Level4Scene());
            });
        }
    }
}
