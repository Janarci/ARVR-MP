using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAgentController : MonoBehaviour
{
    private static MazeAgentController instance;
    public static MazeAgentController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MazeAgentController>();
            }
            return instance;
        }
    }

    [SerializeField] private MazeAgent[] agents;

    // Start is called before the first frame update
    void Start()
    {
        agents = GetComponentsInChildren<MazeAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnTap(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    public void OnTap(Vector2 touchPosition)
    {
        Ray r = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Target");
            
        if (Physics.Raycast(r, out hit, 100, layerMask))
        {
            Debug.Log("yeet");

            Vector3 hitPoint = hit.point;
            MoveAgentsToPosition(hitPoint);
        }
    }

    public void MoveAgentsToPosition(Vector3 position)
    {
        foreach(var agent in agents)
        {
            agent.MoveToDestination(position);
        }
    }

    public void StopAgents(bool isStopped)
    {
        foreach (var agent in agents)
        {
            agent.StopAgent(isStopped);
        }
    }

    public void SetAgentsActive(bool isActive)
    {
        foreach (var agent in agents)
        {
            agent.StopAgent(!isActive);
            agent.gameObject.SetActive(isActive);
        }
    }
}
