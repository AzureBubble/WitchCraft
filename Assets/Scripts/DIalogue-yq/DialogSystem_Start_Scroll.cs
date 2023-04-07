using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogSystem_Start_Scroll : MonoBehaviour
{

    [Header("UI")]
    [Tooltip("�ı���")]
    [SerializeField]
    public Text textLabel;

    [Header("�ı��ļ�")]
    public TextAsset textFile;

    [Header("����Ի���")]
    public GameObject TalkUI;

    [Header("�Ի�����")]
    [Tooltip("����")]
    [SerializeField]
    public int index;
    [Tooltip("�ı�����")]
    [SerializeField]
    public int columnNum;
    [Tooltip("�����ı��ٶ�")]
    [SerializeField]
    public float textSpeed;

    public string nextScene;
    bool textFinished;
    bool ifend;
    List<string> textList = new List<string>();
    private AudioSource audioSource;
    void Awake()
    {
        GetTextFormFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && index == columnNum)  // index һ���ж����� �ص��Ի���
        {
            index = 0;
            TalkUI.SetActive(false);
            SceneManager.LoadScene(nextScene);
            return;
        }

        if (Input.GetButtonDown("Fire1") && textFinished)  // ����������
      {
            //textLabel.text = textList[index];
            //index++;
            
            StartCoroutine(SetTextUI());
      }
       
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();  // ��list���涫�����
        index = 0;

        var lineDate = file.text.Split('\n');   // �ûس����ָ�

        foreach (var line in lineDate)
        {
            textList.Add(line);  // ���ָ��õĶ�����ӽ�LIst
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        //ifend = true;
        index++;

        //if (ifend)
        //{
        //    SceneManager.LoadScene(nextScene);
        //}
    }
}
