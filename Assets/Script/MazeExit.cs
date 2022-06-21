using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MazeExit : MonoBehaviour
{
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
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        GameResult.instance.currentDate = 1;
        GameResult.instance.DDResult = 0;
        GameResult.instance.DSResult = 3;
        GameResult.instance.isSceneLoaded = true;
    }
}
