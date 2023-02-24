using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManager.Scene;

public class MainController : MonoBehaviour
{
    public static MainController Instance { get; private set; }

    // 场景切换管理器
    public SceneManager.SceneManager SceneManager { get; private set; }

    public bool IsGameEnd { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        this.SceneManager = new SceneManager.SceneManager();
        this.IsGameEnd = true;

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.SceneManager.SetScene(new StartGameScene());

        //this.SceneManager.SetScene(new Level1Scene());
    }

    // Update is called once per frame
    private void Update()
    {
        this.DetectDefeat();
    }

    private void DetectDefeat()
    {
    }

    public void OnVictory()
    {
    }

    public void OnDefeat()
    {
    }

    public void SetAsChildObject(GameObject obj)
    {
        obj.transform.parent = this.transform;
    }
}