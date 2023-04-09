using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    // 单例实例
    public static Clickable _instance;

    // 全局变量
    public int Fclickable = 0;


    // 公共的访问器
    public int ClickableF   //获取和设置F是否可按的状态
    {
        get { return Fclickable; }
        set { Fclickable = value; }
    }

    void Update()
    {

    }

}
