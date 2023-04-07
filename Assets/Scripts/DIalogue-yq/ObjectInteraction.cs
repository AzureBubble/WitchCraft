using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public AudioClip interactionSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        // Your code for interacting with the object goes here

        // Play the interaction sound if it's assigned
        if (interactionSound != null)
        {
            AudioSource.PlayClipAtPoint(interactionSound, transform.position);
        }
    }
}
