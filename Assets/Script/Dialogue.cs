using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : ScriptableObject
{
    public enum character { PLAYER = 0, GIRL = 1, NONE = 2};

    public string statement;
    public character who;
    public bool isNextDecision;
    public string[] decisions;
}
