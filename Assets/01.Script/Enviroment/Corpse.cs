using UnityEngine;

public class Corpse : MonoBehaviour,IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //시체: 20% 확률로 등장, 캐릭터 정신력 초당 1 감소
        //썩은 시체: 5% 확률로 등장, 캐릭터 정신력 초당 1 감소, 이동속도 감소
        //일단 시체가 나왔다면 4/5 확률로 일반 시체고 1/5 확률로 썩은 시체
        //방 길이 따라 달라지네?
        int rottedPercent = -5 + 10 * roomWidth;
        int notRottedPercent = 15 + 5 * roomWidth;

        int wholePercent = Random.Range(0, rottedPercent + notRottedPercent);

        int result = wholePercent < rottedPercent ? rottedPercent : notRottedPercent;
    }
}