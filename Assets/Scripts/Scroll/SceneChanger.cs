using UnityEngine;
using UnityEngine.SceneManagement;

using SceneManagement.Scene;
using MainControl;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MainController.Instance.SceneManager.DynamicSetScene(new Level1Scene());
            //SceneManager.LoadScene();
        }
    }
}