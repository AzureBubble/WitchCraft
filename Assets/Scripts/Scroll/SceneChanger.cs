using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
                
                    SceneManager.LoadScene(sceneName);
                
            }
        }
    }
