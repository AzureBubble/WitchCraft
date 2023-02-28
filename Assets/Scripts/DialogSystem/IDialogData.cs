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
        public string Avatar;
        public string Speaker;
        public string Content;
        public SingleDialog(string avatar, string speaker, string content)
        {
            Avatar = new string(avatar);
            Speaker = new string(speaker);
            Content = new string(content);
        }
    }
}


