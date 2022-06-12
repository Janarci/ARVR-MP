using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gift", menuName = "ScriptableObjects/Gift", order = 1)]
public class Gift : ScriptableObject
{
    public GameObject prefab;
    public Sprite prefabImage;
    public int Affection;
}
