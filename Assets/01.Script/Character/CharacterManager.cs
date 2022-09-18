using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleTon<CharacterManager>
{
    private Character controllingCharacter;
    public Character ControllingCharacter { get { return controllingCharacter; } }

    [SerializeField] private Character startControllCharacter;
    [SerializeField] private GameObject focusRing;
    public void Start()
    {
        ControllCharacter(startControllCharacter);
    }

    public void ControllCharacter(Character character)
    {
        focusRing.transform.SetParent(character.transform);
        focusRing.transform.localPosition = Vector3.zero;
        if(controllingCharacter != null)
        {
            //
        }
        controllingCharacter = character;

        UIManager.Instance.SetCharacterCardInfo(controllingCharacter.Data);
    }

    public void Controll(ControllType type, bool isLeftClick, Vector3 orderPos = default(Vector3), SpriteButton button = null)
    {
        if (controllingCharacter == null) return;
        orderPos = new Vector3(0, orderPos.y, orderPos.z);
        switch (type)
        {
            case ControllType.Act:
                controllingCharacter.Move(orderPos, !isLeftClick);
                controllingCharacter.Act(button.UseStart, button);
                break;
            case ControllType.Move:
                controllingCharacter.Move(orderPos, !isLeftClick);
                controllingCharacter.UsingButton?.UseCancel();
                controllingCharacter.CancelAct();
                break;
            case ControllType.Attack:
                controllingCharacter.Attack(orderPos, button);
                break;
            default:
                break;
        }
    }
}
public enum ControllType
{
    Act,
    Move,
    Attack,
}
