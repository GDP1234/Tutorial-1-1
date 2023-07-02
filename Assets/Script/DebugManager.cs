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

    public Transform camera;

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
            camera.position = other.transform.position;
        }
    }
    
}
