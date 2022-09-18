using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : SpriteButton
{
    private Character character;
    public Character Character { get { return character; } }
    public override void Start()
    {
        base.Start();
        character = GetComponentInParent<Character>();
    }
}
