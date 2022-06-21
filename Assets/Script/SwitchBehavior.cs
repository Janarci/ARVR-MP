using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> movableWallsList;
    public bool isFirstWallOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFirstWallOpen)
        {
            movableWallsList[0].SetActive(false);
            movableWallsList[1].SetActive(true);
            isFirstWallOpen = true;
        }
        else
        {
            movableWallsList[0].SetActive(true);
            movableWallsList[1].SetActive(false);
            isFirstWallOpen = false;
        }
    }
}
