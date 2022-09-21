using UnityEngine;

public class Corpse : MonoBehaviour,IObjects
{

    public static bool isCorpse = false;

    public void Effect(int roomWidth = 1)
    {
        //��ü: 20% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����
        //���� ��ü: 5% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����, �̵��ӵ� ����
        //�ϴ� ��ü�� ���Դٸ� 4/5 Ȯ���� �Ϲ� ��ü�� 1/5 Ȯ���� ���� ��ü
        int rotted = -5 + 10 * roomWidth;
        int basic = 15 + 5 * roomWidth;

        int wholePercent = Random.Range(0, 100);

        CorpseState result = wholePercent < rotted ? CorpseState.ROTTEN : wholePercent < basic + rotted? CorpseState.BASIC : CorpseState.NONE;
        
        switch(result)
        {
            case CorpseState.NONE:
                Debug.Log("��ü ����");
                gameObject.SetActive(false);
                break;
            case CorpseState.BASIC:
                //��ü: 20% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����
                Debug.Log("�Ϲݽ�ü");
                break;
            case CorpseState.ROTTEN:
                if (!isCorpse)
                {
                    //���� ��ü: 5% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����, �̵��ӵ� ����
                    isCorpse = true;
                    Debug.Log("������ü");
                }
                break;

        }
    }

    private void Start()
    {
        Effect(gameObject.GetComponentInParent<RoomObjCreate>().roomWidth);
    }
}