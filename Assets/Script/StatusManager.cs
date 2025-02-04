using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 구조체 , 리스트 설계방법이 더 좋을 것 같기는 하다 */
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

    // 스테이지가 가지고 있는 인덱스 정리
    public Dictionary<string, int> FatigueDict;
    public Dictionary<string, int> HungerDict;

    [Header("피로도 최대 수치 조절")]
    public float[] FatigueMaxData;
    [Header("피로도 현재 수치 조절")]
    public float[] FatigueData;

    private int FatigueIndex = 0;

    [Header("배고픔 최대 수치 조절")]
    public float[] HungerMaxData;
    [Header("배고픔 현재 수치 조절")]
    public float[] HungerData;


    private int HungerIndex = 0;

    void Start()
    {
        /* 컴포넌트에서 값 삽입 하지 않을 시 */
        //FatigueMaxData = new float[] {15,15,15,15,0,0,0,0,0,0,15,15,15,15,15,15,15,15,15,0};
        //FatigueData = new float[] { 15,15,15,15,0,0,0,0,0,0,15,15,15,15,15,15,15,15,15,0 };
        //HungerData = new float[] { 2, 2 };
        //HungerMaxData = new float[] { 2, 2 };

        FatigueDict = new Dictionary<string, int>();
        FatigueDict.Add("CameraPos1", 0); // 1-1
        FatigueDict.Add("CameraPos2", 1); // 1-2
        FatigueDict.Add("CameraPos3", 2); // 1-3
        FatigueDict.Add("CameraPos4", 3); // 1-4

        FatigueDict.Add("CameraPos2-1", 10); // 2-1
        FatigueDict.Add("CameraPos2-2", 11); // 2-2
        FatigueDict.Add("CameraPos2-3", 12); // 2-3
        FatigueDict.Add("CameraPos2-4", 13); // 2-4
        FatigueDict.Add("CameraPos2-5", 14); // 2-5
        FatigueDict.Add("CameraPos2-6", 15); // 2-6
        FatigueDict.Add("CameraPos2-7", 16); // 2-7
        FatigueDict.Add("CameraPos2-8", 17); // 2-8
        FatigueDict.Add("CameraPos2-9", 18); // 2-9


        HungerDict = new Dictionary<string, int>();
        HungerDict.Add("CameraPos1", 0); // 1 stage
        HungerDict.Add("CameraPos2", 0); // 1
        HungerDict.Add("CameraPos3", 0); // 1
        HungerDict.Add("CameraPos4", 0); // 1

        HungerDict.Add("CameraPos2-1", 1); // 2 stage
        HungerDict.Add("CameraPos2-2", 1); // 2
        HungerDict.Add("CameraPos2-3", 1); // 2
        HungerDict.Add("CameraPos2-4", 1); // 2
        HungerDict.Add("CameraPos2-5", 1); // 2
        HungerDict.Add("CameraPos2-6", 1); // 2
        HungerDict.Add("CameraPos2-7", 1); // 2
        HungerDict.Add("CameraPos2-8", 1); // 2
        HungerDict.Add("CameraPos2-9", 1); // 2

        // 현재 맵에 따른 피로도 인덱스 가져오기
        if (FatigueDict.ContainsKey(GameManager.instance.currentMapName))
            FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        else
            FatigueIndex = 0;

        // 현재 맵에 따른 배고픔 인덱스 가져오기
        if (HungerDict.ContainsKey(GameManager.instance.currentMapName))
            HungerIndex = HungerDict[GameManager.instance.currentMapName];
        else
            FatigueIndex = 0;

        // 현재 맵 정보에 따라서 배고픔 피로도 첫 초기화 
        if (!PlayerStatus.instance.InitStatus(HungerMaxData[HungerIndex],
            FatigueMaxData[FatigueIndex], HungerData[HungerIndex], FatigueData[FatigueIndex]))
        {
            Debug.Log("초기화 실패");
        }

    }

    //맵 바뀔 때 마다 피로도 셋팅
    public void FatigueSetting()
    { 
        if (!FatigueDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log("Fatigue Key 없음.");
            return;
        }

        FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitFatigueMax(FatigueMaxData[FatigueIndex]);
        PlayerStatus.instance.InitFatigue(FatigueData[FatigueIndex]);
    }
    
    public void Substitution()
    {
        //FatigueData = FatigueMaxData; // 이러면 주소값 참조된다.
        //HungerData = HungerMaxData; 

        for (int i=0; i<HungerMaxData.Length; ++i)
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
