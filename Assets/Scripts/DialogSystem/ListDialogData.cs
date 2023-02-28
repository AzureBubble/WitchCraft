using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class ListDialogData : IDialogData
    {
        private List<SingleDialog> dialogs;
        private int index;

        public ListDialogData()
        {
            dialogs = new List<SingleDialog>();
            index = -1;
            dialogs.Add(new SingleDialog("avatar1", "speaker1", "你好世界！\n你好世界！"));

        }

        public SingleDialog GetNext()
        {
            ++index;
            if (index >= dialogs.Count) return null;

            return dialogs[index];
        }

        public bool HasNext()
        {
            if (index >= dialogs.Count) return false;
            return true;
        }

        public int GetCount()
        {
            return dialogs.Count;
        }

        public void ResetIndex()
        {
            index = -1;
        }
    }
}
