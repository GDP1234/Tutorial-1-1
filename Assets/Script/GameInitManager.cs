using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitManager : MonoBehaviour
{
    public string StartStage;
    public string StartPointName;
    public GameObject SpwanObject;

    FadeEffect fadeEffect;
    private GameObject player;
    private Player_Action playerAction;

    // Start is called before the first frame update
    void Start()
    {
        //ĳ���� ���� ��ġ
        player = GameObject.Find("Player");
        player.transform.position = SpwanObject.transform.position;
    }

    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
        // ... ���ε�ɶ����� ��� ����ȴ�. ������ �װ��� 
        // é��1�������� �ؾ��ϴµ� �������� ������ ������
        // �׸��� é��1�ٽ� �������� �ν����ͷ� �����Ѱ͵��� ���� Null �����̱� ������
        // �ڵ尡 ������ �ɼ��� ����. �̤�
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*GameManager.instance.StartGame();

        //fade ȿ��
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
        fadeEffect.OnFade(FadeState.FadeIn);

        //fade ȿ���� ĳ���� ����
        
        playerAction = player.GetComponent<Player_Action>();
        playerAction.OnStop(PlayerState.MoveOff);

        //ĳ���� ���� ��ġ
        player.transform.position = SpwanObject.transform.position;

        //����� �Ƿε� �ʱ�ȭ
        StatusManager.instance.Substitution();*/
    }

}
