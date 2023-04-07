using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogLoader
    {
        public static readonly int lineCount = 5;
        public DialogLoader() { }

        public IDialogData LoadDialogData(TextAsset textAsset)
        {
            List<string> originTexts = new List<string>(textAsset.text.Split("\n"));

            var overflow = originTexts.Count % lineCount;
            for (int i = 0; i < overflow; ++i)
            {
                originTexts.RemoveAt(originTexts.Count - 1);
            }

            var data = new List<List<string>>();
            int length = originTexts.Count / lineCount;
            for (int i = 0; i < length; ++i)
            {
                var tmp = new List<string>();
                for (int j = 0; j < 3; ++j)
                {
                    tmp.Add(originTexts[lineCount * i + j]);
                }

                foreach(string button in originTexts[lineCount * i + 3].Split(" "))
                {
                    if (button.Contains("/"))
                    {
                        tmp.Add(button);
                    }
                }
                data.Add(tmp);
            }

            //Debug.Log($"{this}: {data.Count} {data[0].Count}");

            IDialogData dialogData = new ListDialogData(data);
            return dialogData;
        }
    }
}
