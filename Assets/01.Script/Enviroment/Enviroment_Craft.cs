using System.Collections.Generic;
using UnityEngine;

public class Enviroment_Craft : Enviroment
{
    [Header("Craft")]
    [SerializeField] private Transform craftElement;
    [SerializeField] private Transform virtualCraft;
    [SerializeField] private Color craftAbleColor = Color.white;
    [SerializeField] private Color craftDisableColor = Color.white;


    private Renderer[] virtualCraftRendere;

    private Enviroment craftEnviroment;


    public void Init(Enviroment craftTarget)
    {
        craftEnviroment = craftTarget;

        craftElement.gameObject.SetActive(false);

        GameObject obj = Instantiate(craftTarget, virtualCraft).gameObject;

        obj.transform.localPosition = Vector3.zero;

        virtualCraftRendere = obj.GetComponentsInChildren<Renderer>();

        foreach (var renderer in virtualCraftRendere)
        {
            renderer.material.color = craftAbleColor;
        }
    }
    
    public void Display()
    {
        craftElement.gameObject.SetActive(true);
        virtualCraft.gameObject.SetActive(false);
    }

    public void Craft()
    {
        Instantiate(craftEnviroment, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
