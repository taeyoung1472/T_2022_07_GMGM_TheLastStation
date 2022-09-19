using UnityEngine;

public class Corpse : MonoBehaviour,IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //시체: 20% 확률로 등장, 캐릭터 정신력 초당 1 감소
        //썩은 시체: 5% 확률로 등장, 캐릭터 정신력 초당 1 감소, 이동속도 감소
        //일단 시체가 나왔다면 4/5 확률로 일반 시체고 1/5 확률로 썩은 시체
        int rottedPercent = -5 + 10 * roomWidth;
        int notRottedPercent = 15 + 5 * roomWidth;

        int wholePercent = Random.Range(0, 100);

        CorpseState result = wholePercent < rottedPercent ? CorpseState.ROTTEN : wholePercent < notRottedPercent + rottedPercent? CorpseState.BASIC : CorpseState.NONE;
        
        switch(result)
        {
            case CorpseState.NONE:
                Debug.Log("시체 없음");
                gameObject.SetActive(false);
                break;
            case CorpseState.BASIC:
                //시체: 20% 확률로 등장, 캐릭터 정신력 초당 1 감소
                Debug.Log("일반시체");
                break;
            case CorpseState.ROTTEN:
                //썩은 시체: 5% 확률로 등장, 캐릭터 정신력 초당 1 감소, 이동속도 감소
                Debug.Log("썩은시체");
                break;
        }
    }

    private void Start()
    {
        Effect();
    }
}