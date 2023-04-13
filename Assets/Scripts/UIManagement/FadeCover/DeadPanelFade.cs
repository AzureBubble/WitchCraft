using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UIManagement.UITools;

public class DeadPanelFade : MonoBehaviour
{
    private UITool tool;

    private void Awake()
    {
        tool = new UITool(gameObject);
        tool.GetOrAddComponent<CanvasGroup>().DOFade(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        tool.GetOrAddComponent<CanvasGroup>().DOFade(1, 0.5f);
    }
}
