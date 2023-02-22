using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    public class PanelType
    {
        public string Name { get; private set; }

        public string Path { get; private set; }

        public PanelType(string path)
        {
            Path = path;
            Name = path[(path.LastIndexOf('/') + 1)..];
        }
    }
}


