using UnityEngine;
using UnityEngine.UI;

public class PopUpImage : MonoBehaviour
{
    public Image popupImage;
    [SerializeField]
    private Ghost ghost;
    private bool isDisplaying = false;

    private void Start()
    {
        popupImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDisplaying)
        {
            Invoke("HideImage", 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupImage.gameObject.SetActive(true);
            isDisplaying = true;
            ghost.StartTime();
        }
    }

    private void HideImage()
    {
        popupImage.gameObject.SetActive(false);
        isDisplaying = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideImage();
        }
    }
}
