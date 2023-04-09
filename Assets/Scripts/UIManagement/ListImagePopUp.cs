using UnityEngine;
using UnityEngine.UI;

public class ListImagePopUp : MonoBehaviour
{
    public GameObject imageObject;
    public Button closeButton;

    void Start()
    {
        // Disable the image object to start with
        imageObject.SetActive(false);

        // Add an event listener to the button to show the image
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ShowImage);

        // Add an event listener to the close button to hide the image
        closeButton.onClick.AddListener(HideImage);
    }

    void ShowImage()
    {
        // Enable the image object
        imageObject.SetActive(true);
    }

    void HideImage()
    {
        // Disable the image object
        imageObject.SetActive(false);
    }
}
