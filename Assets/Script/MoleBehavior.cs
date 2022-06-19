using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    private Animator anim;
    //private bool isPopout = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Whacked()
    {
        Debug.Log(this.gameObject.name + " was whacked");

        anim.SetTrigger("Popout");
    }

    public void Whacked2()
    {
        Debug.Log(this.gameObject.name + " was whacked2");

        anim.SetTrigger("Whack");
    }
}
