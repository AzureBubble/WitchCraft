using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public RectTransform imageTransform; // The RectTransform component of the image
    public float scrollSpeed = 50f; // The speed at which the image scrolls down
    public float bottomY = -100f; // The y position at which the image stops scrolling

    private bool isScrolling = true; // Whether the image is currently scrolling

    void Update()
    {
        if (isScrolling)
        {
            // Move the image downwards at a constant speed
            imageTransform.anchoredPosition -= new Vector2(0f, scrollSpeed * Time.deltaTime);

            // Check if the image has reached the bottom
            if (imageTransform.anchoredPosition.y <= bottomY)
            {
                // Stop scrolling
                isScrolling = false;
            }
        }
    }
}
