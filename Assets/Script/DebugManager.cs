using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    // �ۺ� ��ɻ�� bool ����
    // �ۺ� ī�޶� ����
    // �ۺ� ���׹̳� ���Ҽ�ġ�� ���� ���� bool ����

    
    void Start()
    {
        //��ɻ�� bool ������ üũ�Ǿ��ִٸ� ���� ������Ʈ destory �ϰų� ��ũ��Ʈ ���۵� �ڵ�
        //���׹̳� ���Ҽ�ġ üũ�Ǿ��ִٸ� StatusManager�� testMode ������ true�� �� ��
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���� �ε����� Tag ī�޶���
            //�� ��ġ �޾ƿͼ� ���� ī�޶��� ��ġ�� ������ �̵�
    }
    
}
