using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ����ü , ����Ʈ �������� �� ���� �� ����� �ϴ� */

public class StatusManager : MonoBehaviour
{
    #region Singleton
    public static StatusManager instance;

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

    public Dictionary<string, int> FatigueDict;
    public Dictionary<string, int> HungerDict;

    [Header("�Ƿε� �ִ� ��ġ ����")]
    public float[] FatigueMaxData = new float[] { 15, 15, 15, 15 };
    [Header("�Ƿε� ���� ��ġ ����")]
    public float[] FatigueData = new float[] { 15, 15, 15, 15 };

    private int FatigueIndex = 0;

    [Header("����� �ִ� ��ġ ����")]
    public float[] HungerMaxData = new float[] { 2 };
    [Header("����� ���� ��ġ ����")]
    public float[] HungerData = new float[] { 2 };


    private int HungerIndex = 0;

    void Start()
    {
        FatigueDict = new Dictionary<string, int>();
        FatigueDict.Add("CameraPos1", 0); // 1-1
        FatigueDict.Add("CameraPos2", 1); // 1-2
        FatigueDict.Add("CameraPos3", 2); // 1-3
        FatigueDict.Add("CameraPos4", 3); // 1-4

        HungerDict = new Dictionary<string, int>();
        HungerDict.Add("CameraPos1", 0); // 1
        HungerDict.Add("CameraPos2", 0); // 1
        HungerDict.Add("CameraPos3", 0); // 1
        HungerDict.Add("CameraPos4", 0); // 1


        if(FatigueDict.ContainsKey(GameManager.instance.currentMapName))
            FatigueIndex = FatigueDict[GameManager.instance.currentMapName];

        if(HungerDict.ContainsKey(GameManager.instance.currentMapName))
            HungerIndex = HungerDict[GameManager.instance.currentMapName];

        // ���� �� ������ ���� ����� �Ƿε� ù �ʱ�ȭ 
        // MAX���� ���� ���� �״�� �������� �ִ�.
        if(!PlayerStatus.instance.InitStatus(HungerMaxData[HungerIndex],
            FatigueMaxData[FatigueIndex], HungerMaxData[HungerIndex], FatigueMaxData[FatigueIndex]))
                Debug.Log("�ʱ�ȭ ����");

    }

    //�� �ٲ� �� ���� �Ƿε� ����
    public void FatigueSetting()
    {
        if (!FatigueDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log("Fatigue Key ����.");
            return;
        }

        FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitFatigueMax(FatigueMaxData[FatigueIndex]);
        PlayerStatus.instance.InitFatigue(FatigueData[FatigueIndex]);
    }
    
    public void Substitution()
    {
        //FatigueData = FatigueMaxData; // �̷��� �ּҰ� �����ȴ�.
        //HungerData = HungerMaxData; 
        for(int i=0; i<HungerMaxData.Length; ++i)
        {
            HungerData[i] = HungerMaxData[i];
        }

        for(int i=0; i<FatigueMaxData.Length; ++i)
        {
            FatigueData[i] = FatigueMaxData[i];
        }
    }

    public void FDChange(float value)
    {
        FatigueData[FatigueIndex] -= value;
    }

}
