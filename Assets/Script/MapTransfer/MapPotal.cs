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
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
        playerAction = player.GetComponent<Player_Action>();

    }

    // ���� �۾��� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���ӸŴ����� ����� ��ġ �� ����
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

                //PlayerStatus ����
                StatusManager.instance.FatigueSetting();
            }
            else
            {
                Debug.Log(" ��ϵ��� ���� ");
            }
        }
    }
}
