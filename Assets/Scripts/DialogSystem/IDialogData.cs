using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public interface IDialogData
    {
        public SingleDialog GetNext();
        public bool HasNext();
        public int GetCount();
        public void ResetIndex();
    }

    public class SingleDialog
    {
        public Sprite Avatar;
        public string Speaker;
        public string Content;
        public List<string> Buttons;
        public SingleDialog(Sprite avatar, string speaker, string content, List<string> buttons)
        {
            Avatar = avatar;
            Speaker = speaker;
            Content = content;
            Buttons = buttons;
        }
    }
}


