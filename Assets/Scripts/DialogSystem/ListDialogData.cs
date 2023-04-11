using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class ListDialogData : IDialogData
    {
        private List<SingleDialog> dialogs;
        private int index;

        public ListDialogData(List<List<string>> data = null)
        {
            dialogs = new List<SingleDialog>();
            index = -1;
            SetData(data);
        }

        public SingleDialog GetNext()
        {
            ++index;
            if (index >= dialogs.Count) return null;

            return dialogs[index];
        }

        public bool HasNext()
        {
            if (index >= dialogs.Count - 1) return false;
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

        public void SetData(List<List<string>> data)
        {
            if (data != null)
            {
                dialogs.Clear();
                foreach (List<string> each in data)
                {
                    string avatar_path = each[0];

                    Sprite sprite = Resources.Load<Sprite>("Dialogs/Drawing");
                    string speaker = each[1];
                    string content = each[2];

                    List<string> buttons = new List<string>();
                    for(int i = 3; i < each.Count; ++i)
                    {
                        buttons.Add(each[i]);
                    }
                    
                    dialogs.Add(new SingleDialog(sprite, speaker, content, buttons));
                }
            }
        }
    }
}
