using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCover : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 2.0f;
    private RawImage backGround;

    public bool IsDown { get; private set; } = false;

    void Awake()
    {
        transform.position = transform.parent.position;
        backGround = GetComponent<RawImage>();
        SizeInit();
        //SetInitColor(Color.clear);
        //FadeOut();
    }

    private void SizeInit()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect canvas = transform.parent.GetComponent<RectTransform>().rect;
        //Debug.Log($"{this}: {canvas.width}, {canvas.height}");
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvas.width);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvas.height);
    }

    public void SetInitColor(Color color)
    {
        //Debug.Log($"{this}: Color-black: {Color.black}, Color-clear: {Color.clear}");
        backGround.color = color;
    }

    public void FadeIn(Action callback)
    {
        IEnumerator enumerator = FadeCoroutine(Color.clear, () => {
            IsDown = true;
            callback?.Invoke();
            Destroy(gameObject);
        });
        StartCoroutine(enumerator);
    }

    public void FadeOut(Action callback)
    {
        IEnumerator enumerator = FadeCoroutine(Color.black, () => {
            IsDown = true;
            callback?.Invoke();
        });
        StartCoroutine(enumerator);
    }

    private IEnumerator FadeCoroutine(Color targetColor, Action action)
    {
        while (backGround.color.a != targetColor.a)
        {
            //Debug.Log($"{this}: fade_speed = {fadeSpeed * Time.deltaTime}");
            backGround.color = Color.Lerp(backGround.color, targetColor, fadeSpeed * Time.deltaTime);
            //Debug.Log($"{this}: {backGround.color}, {targetColor}");
            //Debug.Log($"{this}: difference = {backGround.color.a - targetColor.a}");
            if (Mathf.Abs(backGround.color.a - targetColor.a) < 0.05)
            {
                backGround.color = targetColor;
            }
            yield return null;
        }
        //Debug.Log($"{this}: {backGround.color}, {targetColor}");
        action?.Invoke();
    }

}
