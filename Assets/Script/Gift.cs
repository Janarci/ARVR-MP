using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gift", menuName = "ScriptableObjects/Gift", order = 1)]
public class Gift : ScriptableObject
{
    //This is a container of data
    public GameObject prefab; //3D Model
    public Sprite prefabImage; //Sprite
    public int Affection; //Value
}
