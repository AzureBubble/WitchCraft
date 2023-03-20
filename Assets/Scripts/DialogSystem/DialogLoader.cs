using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogLoader
    {
        public DialogLoader() { }

        public IDialogData LoadDialogData(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            Debug.Log(textAsset.text);

            List<string> originTexts = new List<string>(textAsset.text.Split("\n"));

            var overflow = originTexts.Count % 4;
            for (int i = 0; i < overflow; ++i)
            {
                originTexts.RemoveAt(originTexts.Count - 1);
            }

            var data = new List<List<string>>();
            int length = originTexts.Count / 4;
            for (int i = 0; i < length; ++i)
            {
                var tmp = new List<string>();
                for (int j = 0; j < 3; ++j)
                {
                    tmp.Add(originTexts[4 * i + j]);
                }
                data.Add(tmp);
            }

            //Debug.Log($"{this}: {data.Count} {data[0].Count}");

            IDialogData dialogData = new ListDialogData(data);
            return dialogData;
        }
    }
}
