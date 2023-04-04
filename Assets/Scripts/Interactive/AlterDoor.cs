using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MainControl;
using SceneManagement.Scene;

public class AlterDoor : Interactive
{
    private bool isPlayerIn = false;

    public bool IsPlayerIn { get => isPlayerIn; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = true;
            Debug.Log($"{this}: Collision Player In. Status: {isPlayerIn}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = false;
            Debug.Log($"{this}: Collision Player Out. Status: {isPlayerIn}");
        }
    }

    public new void CheckItem(ItemName name)
    {
        if (isPlayerIn)
        {
            base.CheckItem(name);
        }
    }

    protected override void OnClickedAction()
    {
        MainController.Instance.SceneManager.DynamicSetScene(new Level2Scene());
    }
}
