using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPotal : MonoBehaviour
{
    public string transferMapName;

    [HideInInspector]
    public GameObject map;

    private GameManager gameManager;
    private GameObject player;
    private Player_Action playerAction;

    CameraMove CMove;

    FadeEffect fadeEffect;

    private void Start()
    {
        gameManager = GameManager.instance;
        

        map = GameObject.Find(transferMapName);
        if (map == null)
            Debug.Log("��ã��!!" + transferMapName);

        player = GameObject.Find("Player");
        if (player == null)
            Debug.Log("Player ��ã�� !!");

        CMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();

        //fade ȿ��
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
        fadeEffect.OnFade(FadeState.FadeIn);

        playerAction = player.GetComponent<Player_Action>();
        playerAction.OnStop(PlayerState.MoveOff);


    }

    // ���� �۾��� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���ӸŴ����� ����� ��ġ �ʱ�ȭ
            gameManager.playerStartingPt = transferMapName;
            // �÷��̾��� ��ġ�� ���� ��Ż�� �̵�
            player.transform.position = map.transform.position;

            // ���� ��ȯ�� �� 
            if (MapDictionary.instance.dict.ContainsKey(transferMapName))
            {
                gameManager.currentMapName = MapDictionary.instance.dict[transferMapName];
                CMove.CameraPosMove();

                //���̵� ȿ��
                fadeEffect.OnFade(FadeState.FadeIn);
                playerAction.OnStop(PlayerState.MoveOff);
            }
            else
            {
                Debug.Log(" ��ϵ��� ���� ");
            }
        }
    }
}
