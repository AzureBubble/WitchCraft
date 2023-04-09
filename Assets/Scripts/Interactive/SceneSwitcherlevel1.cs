using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

using MainControl;
using SceneManagement.Scene;


public class SceneSwitcherlevel1 : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(sceneName);
            MainController.Instance.SceneManager.DynamicSetScene(new Level1Scene());
            
        }
        
        
    }
}
