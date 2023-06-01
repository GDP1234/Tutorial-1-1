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
    bool activeInventory = false;

    //���������
    [HideInInspector]
    public bool isGameover;

    //���ӿ��� UI
    public GameObject OverUI;

    void Start()
    {
        isGameover = false;
        SceneIndex = 1;
        //inventoryPanel.SetActive(activeInventory);
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // R Ű�� ������ ��� �� �����
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneIndex);
            }
            // I Ű�� ������ �� �κ��丮
            if (Input.GetKeyDown(KeyCode.I))
            {
                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
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
