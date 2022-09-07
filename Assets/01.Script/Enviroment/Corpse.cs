using UnityEngine;

public class Corpse : MonoBehaviour,IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //��ü: 20% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����
        //���� ��ü: 5% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����, �̵��ӵ� ����
        //�ϴ� ��ü�� ���Դٸ� 4/5 Ȯ���� �Ϲ� ��ü�� 1/5 Ȯ���� ���� ��ü
        //�� ���� ���� �޶�����?
        int rottedPercent = -5 + 10 * roomWidth;
        int notRottedPercent = 15 + 5 * roomWidth;

        int wholePercent = Random.Range(0, rottedPercent + notRottedPercent);

        int result = wholePercent < rottedPercent ? rottedPercent : notRottedPercent;
    }
}