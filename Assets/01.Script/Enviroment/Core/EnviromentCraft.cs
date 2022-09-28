using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnviromentCraft : MonoBehaviour
{
    [SerializeField] private Enviroment_Craft craftPrefab;

    [Header("[µð¹ö±×]")]
    public Enviroment demoEnviroment;

    private Enviroment_Craft curSelectedEnviroment;

    private void Start()
    {
        StartCoroutine(CraftCycle());
    }

    private IEnumerator CraftCycle()
    {
        while (true)
        {
            yield return new WaitUntil(() => curSelectedEnviroment != null);
            while(curSelectedEnviroment != null)
            {
                yield return null;
                Vector3 pos = CameraController.Instance.GetGroudPos(CameraController.Instance.GetMousePos());
                pos.z = Mathf.Round(pos.z);
                curSelectedEnviroment.transform.position = pos;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    curSelectedEnviroment.Display();
                    curSelectedEnviroment = null;
                }
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && curSelectedEnviroment == null)
        {
            curSelectedEnviroment = Instantiate(craftPrefab);
            curSelectedEnviroment.Init(demoEnviroment);
        }
    }
}
