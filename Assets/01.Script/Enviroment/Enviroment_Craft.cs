using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enviroment_Craft : Enviroment
{
    [Header("Craft")]
    [SerializeField] private Transform craftElement;
    [SerializeField] private Transform virtualCraft;
    [SerializeField] private Color craftAbleColor = Color.white;
    [SerializeField] private Color craftDisableColor = Color.white;

    private LayerMask spriteButtonLayer;

    private Renderer[] virtualCraftRendere;

    private Enviroment craftEnviroment;

    private bool isDisplayAble = false;

    public void Init(Enviroment craftTarget)
    {
        spriteButtonLayer = 1 << LayerMask.NameToLayer("Button");

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

        JsonManager.Data.craftedEnviroments.Add(new CraftedEnviroment(gameObject));

        Destroy(gameObject);
    }

    public void Update()
    {
        Collider[] cols = Physics.OverlapBox(transform.position, Vector3.one * 4, Quaternion.identity, spriteButtonLayer);
        if (cols.Length > 1 && isDisplayAble)
        {
            foreach (var renderer in virtualCraftRendere)
            {
                renderer.material.color = craftDisableColor;
            }

            isDisplayAble = false;
        }
        else if (cols.Length == 1 && !isDisplayAble)
        {
            foreach (var renderer in virtualCraftRendere)
            {
                renderer.material.color = craftAbleColor;
            }
            isDisplayAble = true;
        }
        print(cols.Length);
    }
}
