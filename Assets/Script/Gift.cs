using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Gift", menuName = "ScriptableObjects/Gift", order = 1)]
public class Gift : ScriptableObject
{
    public GameObject prefab;
    public Image prefabImage;
    public int Affection;
}
