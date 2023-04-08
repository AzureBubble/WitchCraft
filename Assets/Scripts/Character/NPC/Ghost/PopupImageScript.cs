using UnityEngine;
using System.Collections;

public class PopupImageScript : MonoBehaviour
{
    public GameObject popupImage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() != null)
        {
            popupImage.SetActive(true);
            StartCoroutine(HidePopupImage());
        }
    }

    private IEnumerator HidePopupImage()
    {
        yield return new WaitForSeconds(3f);
        popupImage.SetActive(false);
    }
}
