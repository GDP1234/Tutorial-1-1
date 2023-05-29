using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro

/* �������� */
// UI Update������ ���� ���� �޼ҵ�� �����ų ��.
// �ʸ��� �Ƿε� �ο� �� ��
// �������� 1���� ����� �ο� �� ��
// �Ƿε� �� ���� ����� ��� ���� ��
// ����� �� ���� ���� ���� ��ų ��

public class HF_UI : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHunger;
    [SerializeField]
    private TextMeshProUGUI textHunger;
    [SerializeField]
    private Slider sliderFatigue;
    [SerializeField]
    private TextMeshProUGUI textFatigue;

    void Update()
    {
        if (sliderHunger != null)
        {
            sliderHunger.value = Utils.Percent(PlayerStatus.instance.Hunger, PlayerStatus.instance.HungerMax);
        }
        if (textHunger != null)
        {
            textHunger.text = PlayerStatus.instance.Hunger + "/" + PlayerStatus.instance.HungerMax;
        }

        if(sliderFatigue != null)
        {
            sliderFatigue.value = Utils.Percent(PlayerStatus.instance.Fatigue, PlayerStatus.instance.FatigueMax);
        }

        if(textFatigue != null)
        {
            textFatigue.text = PlayerStatus.instance.Fatigue + "/" + PlayerStatus.instance.FatigueMax;
        }

    }
}
