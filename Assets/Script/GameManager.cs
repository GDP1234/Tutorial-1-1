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


    //�κ�  & ������ 1,2,3,4,5
    Inventory inven;
    private GameObject quick1;
    private GameObject quick2;
    private GameObject quick3;
    private GameObject quick4;
    private GameObject quick5;

    void Start()
    {
        activeInventory = false;
        isGameover = false;
        activeEscPanel = false;
        SceneIndex = 1;
        quick1 = GameObject.Find("QuickSlot");
        if (quick1 == null)
            Debug.Log("quick crash .. ");

        quick2 = GameObject.Find("QuickSlot (1)");
        if (quick2 == null)
            Debug.Log("quick(1) crash .. ");

        quick3 = GameObject.Find("QuickSlot (2)");
        if (quick3 == null)
            Debug.Log("quick(2) crash .. ");

        quick4 = GameObject.Find("QuickSlot (3)");
        if (quick4 == null)
            Debug.Log("quick(3) crash .. ");

        quick5 = GameObject.Find("QuickSlot (4)");
        if (quick5 == null)
            Debug.Log("quick(4) crash .. ");

        inven = Inventory.instance;

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

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick1.transform.childCount > 0))
                    return;

                GameObject gameobject = quick1.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 2��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTWO]))
            {
                Debug.Log("Quick2 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick2.transform.childCount > 0))
                    return;

                GameObject gameobject = quick2.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 3��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTHREE]))
            {
                Debug.Log("Quick3 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick3.transform.childCount > 0))
                    return;

                GameObject gameobject = quick3.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 4��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFOUR]))
            {
                Debug.Log("Quick4 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick4.transform.childCount > 0))
                    return;

                GameObject gameobject = quick4.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 5��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFIVE]))
            {
                Debug.Log("Quick5 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick5.transform.childCount > 0))
                    return;

                GameObject gameobject = quick5.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
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
