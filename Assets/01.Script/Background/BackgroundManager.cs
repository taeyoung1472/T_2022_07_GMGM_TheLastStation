using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private List<Transform> backgrounds;
    [SerializeField] private float speed;
    private void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i].Translate(Vector3.back * speed * Time.deltaTime);
            if (backgrounds[i].position.z < -165)
            {
                backgrounds[i].position = backgrounds[i == 0 ? 1 : 0].position + new Vector3(0, 0, 165);
            }
        }
    }
}
