using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverUIExit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        //System.Diagnostics.Process.GetCurrentProcess().Kill(); �ƴ� ����Ƽ�� ������ ��ī�İ� ����
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
