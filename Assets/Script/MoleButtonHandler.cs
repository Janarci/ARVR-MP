using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MoleButtonHandler : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour[] virtualButtons;
    public List<MoleBehavior> moles;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var vButton in virtualButtons)
        {
            vButton.RegisterOnButtonPressed(VirtualButtonPressed);
            vButton.RegisterOnButtonReleased(VirtualButtonReleased);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VirtualButtonPressed(VirtualButtonBehaviour button)
    {
        Debug.Log(button.VirtualButtonName + " is pressed");
    }

    private void VirtualButtonReleased(VirtualButtonBehaviour button)
    {
        Debug.Log(button.VirtualButtonName + " is released");
    }
}
