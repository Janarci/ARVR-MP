using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float popoutDuration = 3.0f;
    private float popoutDurationTimer;
    public bool hasPoppedout = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        popoutDurationTimer = popoutDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPoppedout)
        {
            if (popoutDurationTimer > 0)
            {
                popoutDurationTimer -= Time.deltaTime;
            }
            else
            {
                Popin();
                popoutDurationTimer = popoutDuration;
            }
        }
    }

    public void Popout()
    {
        if (!hasPoppedout)
        {
            anim.SetTrigger("Popout");
            hasPoppedout = true;
        }
    }

    public void Popin()
    {
        if (hasPoppedout)
        {
            anim.SetTrigger("Popin");
            hasPoppedout = false;
        }
    }

    public void Whacked()
    {
        if (hasPoppedout)
        {
            Debug.Log(this.gameObject.name + " was whacked");
            anim.SetTrigger("Popin");
            popoutDurationTimer = popoutDuration;
            hasPoppedout = false;
        }
    }

}
