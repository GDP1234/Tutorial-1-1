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
    CameraMove CMove;

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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D()");
        if (collision.gameObject.name == "Player")
        {
            gameManager.playerStartingPt = transferMapName;
            player.transform.position = map.transform.position;

            if(MapDictionary.instance.dict == null)
            {
                Debug.Log("�� NULL �ΰ�?");
            }


            if (MapDictionary.instance.dict.ContainsKey(transferMapName))
            {
                gameManager.currentMapName = MapDictionary.instance.dict[transferMapName];
                CMove.CameraPosMove();
            }
            else
            {
                Debug.Log(" ��ϵ��� ���� ");
            }
        }
    }
}
