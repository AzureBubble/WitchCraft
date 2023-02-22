using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SceneManagement;
using SceneManagement.Scene;
using MainControl.Interface;

namespace MainControl
{
    public class MainController : MonoBehaviour
    {
        public static MainController Instance { get; private set; }

        // 场景切换管理器
        public SceneManager SceneManager { get; private set; }

        public bool IsGameEnd { get; private set; }


        public IUIManager IUIManager;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            this.SceneManager = new SceneManager();
            this.IUIManager = new IUIManager();
            this.IsGameEnd = false;

            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            this.SceneManager.SetScene(new StartGameScene());

            //this.SceneManager.SetScene(new Level1Scene());
        }

        // Update is called once per frame
        void Update()
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
}
