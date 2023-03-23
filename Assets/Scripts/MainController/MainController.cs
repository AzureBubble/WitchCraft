using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SceneManagement;
using SceneManagement.Scene;
using UIManagement.UIManager;
using UIManagement.BackpackSystem;
using InputManagement;


namespace MainControl
{
    public class MainController : MonoBehaviour
    {
        public static MainController Instance { get; private set; }

        //子系统工厂
        public MCFactory MCFactory { get; private set; }

        // 场景切换管理器
        public ISceneManager SceneManager { get; private set; }

        //键盘输入管理器
        public IInputManager InputManager { get; private set; }

        // UI管理器
        public IUIManager UIManager;

        // 背包UI
        public IBackpackUI BackpackUI;

        public bool GameOver { get; private set; }


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

            Initiate();
            DontDestroyOnLoad(this.gameObject);
        }

        private void Initiate()
        {
            this.MCFactory = new MCFactory();
            //this.SceneManager = new SceneManager();

            GameObject sceneManagerObj = MCFactory.GetSubSystem(SceneManagement.SceneManager.Path);
            SetAsChildObject(sceneManagerObj);
            SceneManager = sceneManagerObj.GetComponent<SceneManager>();

            GameObject inputManagerObj = MCFactory.GetSubSystem(InputManagement.InputManager.Path);
            SetAsChildObject(inputManagerObj);
            this.InputManager = inputManagerObj.GetComponent<InputManager>();

            this.GameOver = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            this.SceneManager.SetScene(new StartGameScene());

            //this.SceneManager.SetScene(new Level1Scene());

            this.InputManager.RegisterKeyDown(KeyCode.T, () => { Debug.Log("test."); });
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
