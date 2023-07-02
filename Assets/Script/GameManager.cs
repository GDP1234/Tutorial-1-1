using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    //�÷��̾� ����� ��ġ
    public string playerStartingPt;

    //���� �� �̸�
    //playerStatus�� ���ӵǾ� ����.. �ʱ�ȭ ���ϸ� �Ƿε� �ο� ������ ���� �̤� ���ľ���
    public string currentMapName;
    public int SceneIndex;

    //�κ��丮
    public GameObject inventoryPanel;
    bool activeInventory;

    //���������
    [HideInInspector]
    public bool isGameover;

    //���ӿ��� UI
    public GameObject OverUI;

    //���̵�
    //FadeEffect fadeEffect;

    //ESC UI
    public GameObject escPanel;
    bool activeEscPanel;

    void Start()
    {
        activeInventory = false;
        isGameover = false;
        activeEscPanel = false;
        SceneIndex = 1;
        //fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
        //fadeEffect.OnFade(FadeState.FadeIn);
        //inventoryPanel.SetActive(activeInventory);
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // I Ű�� ������ �� �κ��丮
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INVENTORY]))
            {
                Debug.Log("Inventory ��� !!");

                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
            }
            // M Ű�� ������ �� ��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map ��� !!");
            }
            // SPACEBAR ������ �� ��ȣ�ۿ�
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
            {
                Debug.Log("Interaction ��� !!");
            }
            // ������ 1��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKONE]))
            {
                Debug.Log("Quick1 ��� !!");
            }
            // ������ 2��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTWO]))
            {
                Debug.Log("Quick2 ��� !!");
            }
            // ������ 3��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTHREE]))
            {
                Debug.Log("Quick3 ��� !!");
            }
            // ������ 4��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFOUR]))
            {
                Debug.Log("Quick4 ��� !!");
            }
            // ������ 5��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFIVE]))
            {
                Debug.Log("Quick5 ��� !!");
            }
            // esc
            if(Input.GetKeyDown(KeySetting.keys[KeyAction.ESC]))
            {
                Debug.Log("ESC ��� !");

                activeEscPanel = !activeEscPanel;
                escPanel.SetActive(activeEscPanel);

            }
        }
        else
        {
            
        }



    }

    // ���ӿ����� ��� UI Ȱ��ȭ
    public void StartGame()
    {
        isGameover = false;
        OverUI.SetActive(false);
    }

    public void EndGame()
    {
        isGameover = true;
        OverUI.SetActive(true);

    }
}
