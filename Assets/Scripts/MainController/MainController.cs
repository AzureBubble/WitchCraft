using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SceneManagement;
using SceneManagement.Scene;
using UIManagement.Panel;
using UIManagement.UIManager;
using InputManagement;
using Bag;

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

        //背包管理器
        public BagManger BagManger { get; private set; }

        // UI管理器
        public IUIManager UIManager;

        public bool GameOver { get; private set; }

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

            GameObject BagManagerObj = MCFactory.GetSubSystem(BagManger.Path);
            SetAsChildObject(BagManagerObj);
            this.BagManger = BagManagerObj.GetComponent<BagManger>();

            this.GameOver = false;
        }

        // Start is called before the first frame update
        private void Start()
        {
            this.SceneManager.DynamicSetScene(new StartGameScene());

            //this.SceneManager.SetScene(new Level1Scene());

            this.InputManager.RegisterKeyDown(KeyCode.T, () => { Debug.Log("test."); });
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
            GameOver = true;
            UIManager.Push(new DeadPanel());
        }

        public void SetAsChildObject(GameObject obj)
        {
            obj.transform.parent = this.transform;
        }
    }
}