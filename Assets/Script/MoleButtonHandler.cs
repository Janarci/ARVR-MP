using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MoleButtonHandler : MonoBehaviour
{
    [SerializeField] private List<VirtualButtonBehaviour> virtualButtons;
    public List<MoleBehavior> molesList;

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

        for (int i = 0; i < virtualButtons.Count; i++)
        {
            if (virtualButtons[i].VirtualButtonName == button.VirtualButtonName)
            {
                molesList[i].Whacked();
            }
        }
    }

    private void VirtualButtonReleased(VirtualButtonBehaviour button)
    {
        Debug.Log(button.VirtualButtonName + " is released");

        for (int i = 0; i < virtualButtons.Count; i++)
        {
            if (virtualButtons[i].VirtualButtonName == button.VirtualButtonName)
            {
                molesList[i].Whacked2();
            }
        }
    }
}
