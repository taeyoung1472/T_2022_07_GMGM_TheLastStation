using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleTon<CharacterManager>
{
    private Character controllingCharacter;
    public Character ControllingCharacter { get { return controllingCharacter; } }

    public void ControllCharacter(Character character)
    {
        if(controllingCharacter != null)
        {
            //
        }
        controllingCharacter = character;

        UIManager.Instance.SetCharacterCardInfo(controllingCharacter.Data);
    }

    public void Controll(ControllType type, Vector3 orderPos = default(Vector3), SpriteButton button = null)
    {
        if (controllingCharacter == null) return;
        orderPos = new Vector3(0, orderPos.y, orderPos.z);
        switch (type)
        {
            case ControllType.Act:
                controllingCharacter.Move(orderPos);
                controllingCharacter.Act(button.UseStart, button);
                break;
            case ControllType.Move:
                controllingCharacter.Move(orderPos);
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
