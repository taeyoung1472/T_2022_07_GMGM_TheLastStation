using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControllingTable : Enviroment
{
    [SerializeField] private RectTransform speedBar;
    [SerializeField] private SpeedMatch[] speedMatches;

    int index = 0;
    float angle;
    float speed;

    public void Act()
    {
        UIManager.Instance.ActiveControllPanel();
    }

    void Update()
    {
        angle = Mathf.Lerp(angle, speedMatches[index].rot, Time.deltaTime * 5);
        speed = Mathf.Lerp(speed, speedMatches[index].speed, Time.deltaTime * 5);
        speedBar.eulerAngles = new Vector3 (0, 0, angle);
        BackgroundManager.Instance.Speed = speed;
    }
    
    public void SpeedControll(bool isUp)
    {
        index += isUp ? 1 : 0;
        index = Mathf.Clamp(index, 0, speedMatches.Length);
    }

    [System.Serializable]
    class SpeedMatch
    {
        public float rot;
        public float speed;
    }
}