using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    public class UIHint : MonoBehaviour
    {
        [Header("交互UI")]
        [Tooltip("交互按钮")]
        [SerializeField]
        public GameObject ButtonHint;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                ButtonHint.SetActive(true);
                Clickable._instance.ClickableF = 1; //将F键设置为可按下状态
                //Debug.Log(Clickable._instance.ClickableF);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                ButtonHint.SetActive(false);
                Clickable._instance.ClickableF = 0; //将F键设置为不可按下状态
            }
        }
    }
}
