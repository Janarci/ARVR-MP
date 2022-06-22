using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlLookAt : MonoBehaviour
{
    public GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().LookAt(Target.transform);
        this.GetComponent<Transform>().Rotate(0f, 0f, -90f);
    }
}
