using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolePatternHandler : MonoBehaviour
{
    public List<MoleBehavior> molesList;
    [SerializeField] private float popoutInterval = 3.0f;
    private float popoutTimer;

    // Start is called before the first frame update
    void Start()
    {
        popoutTimer = popoutInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (popoutTimer > 0)
        {
            popoutTimer -= Time.deltaTime;
        }
        else
        {
            MolePopout();
            popoutTimer = popoutInterval;
        }
    }

    private void MolePopout()
    {
        int i = Random.Range(0, 4);
        int j;

        if (!molesList[i].hasPoppedout) 
        {
            molesList[i].Popout();
        }
        else
        {
            if (i == 0)
            {
                j = Random.Range(1, 4);
                i = j;
            }
            else if (i == 4)
            {
                j = Random.Range(0, 3);
                i = j;
            }
            else
            {
                i += 1;
            }

            molesList[i].Popout();
        }
    }
}
