using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayeData")]
public class CharacterData : ScriptableObject
{
    public Sprite profile;
    public string characterName;
    [TextArea(5,5)]
    public string desc;
    public float moveSpeed;
}
