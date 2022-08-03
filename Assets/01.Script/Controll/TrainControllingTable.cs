using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControllingTable : Enviroment
{
    [SerializeField] private RectTransform speedBar;
    [SerializeField] private RectTransform prograssBar;
    [SerializeField] private SpeedMatch[] speedMatches;

    private int index = 0;
    private float angle;
    private float speed;
    private float prograssGoal;

    public void Act()
    {
        UIManager.Instance.ActiveControllPanel();
    }

    void Update()
    {
        angle = Mathf.Lerp(angle, speedMatches[index].rot, Time.deltaTime * 5);
        speed = Mathf.Lerp(speed, speedMatches[index].speed, Time.deltaTime * 5);
        prograssGoal = speed / 100;
        prograssBar.sizeDelta = new Vector2(Mathf.Lerp(prograssBar.sizeDelta.x, prograssGoal * 790, Time.deltaTime * 5), prograssBar.sizeDelta.y);
        speedBar.eulerAngles = new Vector3 (0, 0, angle);
        BackgroundManager.Instance.Speed = speed;
    }
    
    public void SpeedControll(bool isUp)
    {
        index += isUp ? 1 : -1;
        print(index);
        index = Mathf.Clamp(index, 0, speedMatches.Length - 1);
    }

    [System.Serializable]
    class SpeedMatch
    {
        public float rot;
        public float speed;
    }
}