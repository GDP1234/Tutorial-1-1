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

    //플레이어 재시작 위치
    public string playerStartingPt;

    //현재 맵 이름
    //playerStatus와 종속되어 있음.. 초기화 안하면 피로도 부여 오류가 생김 ㅜㅜ 고쳐야함
    public string currentMapName;
    public int SceneIndex;

    //인벤토리
    public GameObject inventoryPanel;
    bool activeInventory;

    //게임재시작
    [HideInInspector]
    public bool isGameover;

    //게임오버 UI
    public GameObject OverUI;

    //페이드
    //FadeEffect fadeEffect;

    //ESC UI [임시로 바로 Option창으로 활용 중 , 변경 시 주석 삭제]
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
        // 게임오버가 아닌 동안
        if (!isGameover)
        {
            // I 키를 눌렀을 때 인벤토리
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INVENTORY]))
            {
                Debug.Log("Inventory 기능 !!");

                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
            }
            // M 키를 눌렀을 때 맵
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map 기능 !!");
            }
            // SPACEBAR 눌렀을 때 상호작용
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
            {
                Debug.Log("Interaction 기능 !!");
            }
            // 아이템 1번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKONE]))
            {
                Debug.Log("Quick1 기능 !!");
            }
            // 아이템 2번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTWO]))
            {
                Debug.Log("Quick2 기능 !!");
            }
            // 아이템 3번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTHREE]))
            {
                Debug.Log("Quick3 기능 !!");
            }
            // 아이템 4번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFOUR]))
            {
                Debug.Log("Quick4 기능 !!");
            }
            // 아이템 5번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFIVE]))
            {
                Debug.Log("Quick5 기능 !!");
            }
            // esc
            if(Input.GetKeyDown(KeySetting.keys[KeyAction.ESC]))
            {
                Debug.Log("ESC 기능 !");

                // 잠깐 테스트용
                activeInventory = !activeInventory;
                escPanel.SetActive(activeInventory);


            }


        }
        else
        {
            
        }



    }

    // 게임오버인 경우 UI 활성화
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
