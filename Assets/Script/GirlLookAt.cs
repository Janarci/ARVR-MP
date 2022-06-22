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
	    var lookatTarget = this.GetComponent<Transform>().position;

        //lookatTarget.y = Target.transform.position.z;
        this.GetComponent<Transform>().LookAt(Target.transform);
    }
}
