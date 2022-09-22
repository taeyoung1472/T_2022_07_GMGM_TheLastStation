using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Vector2Int unitSize;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    public Vector2Int UnitSize  { get { return unitSize;  } }
    public GameObject RightWall { get { return rightWall; } }
    public GameObject LeftWall  { get { return leftWall;  } }

    public void Init(ZoneType type)
    {
        TextMeshPro tmp = new GameObject().AddComponent<TextMeshPro>();
        tmp.transform.SetParent(transform);
        tmp.text = $"{type}({unitSize.x},{unitSize.y})";
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.black;
        tmp.transform.localPosition = new Vector3(unitSize.x * 0.5f, unitSize.y * 0.5f, 0);
        tmp.fontSize = 1f;
    }
}
