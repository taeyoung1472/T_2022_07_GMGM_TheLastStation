using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin : MonoBehaviour,IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //�ǹ� ����: 20% Ȯ���� ����, '��' ������ ��ȣ�ۿ��ؼ� ����
        //ö�� ����: 10% Ȯ���� ����, '����' ������ ��ȣ�ۿ��ؼ� ����
        int building = 20;
        int iron = 10;
        int wholePercent = Random.Range(0, 100);
        RuinState ruinState = wholePercent < iron ? RuinState.IRON : wholePercent < iron + building ? RuinState.BUILDING : RuinState.NONE; 

        switch(ruinState)
        {
            case RuinState.NONE:
                Debug.Log("���� ����");
                break;
            case RuinState.BUILDING:
                Debug.Log("�ǹ� ����");
                break;
            case RuinState.IRON:
                Debug.Log("ö�� ����");
                break;
        }
    }

    private void Start()
    {
        Effect();
    }
}