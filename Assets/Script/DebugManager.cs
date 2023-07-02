using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [Header("��� ���")]
    [SerializeField]
    private bool debugUse;

    [Header("���׹̳� ����")]
    [SerializeField]
    private bool statusBlock;

    public Transform myCamera;

    private void Awake()
    {
        //myCamera = GameObject.Find("Main Camera");
    }

    void Start()
    {
        if (!debugUse)
            return;

        //���׹̳� ���Ҽ�ġ üũ�Ǿ��ִٸ� StatusManager�� testMode ������ true�� �� ��
        if (statusBlock)
            PlayerStatus.instance.testMode = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!debugUse)
            return;

        // ���� �ε����� Tag ī�޶��� ��ġ �޾ƿͼ� ���� ī�޶��� ��ġ�� ������ �̵�
        if (other.CompareTag("MapBoxCollider"))
        {
            //myCamera.transform.position = other.transform.position;
            myCamera.position = other.transform.position;
        }
    }
    
}
