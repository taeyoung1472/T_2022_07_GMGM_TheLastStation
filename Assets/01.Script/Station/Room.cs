using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Vector2Int unitSize;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    public Vector2Int UnitSize  { get { return unitSize;  } }
    public GameObject RightWall { get { return rightWall; } }
    public GameObject LeftWall  { get { return leftWall;  } }
}
