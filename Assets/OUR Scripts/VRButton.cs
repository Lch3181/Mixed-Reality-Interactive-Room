using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{
    [SerializeField]
    GameObject FunctionObject;

    [SerializeField]
    VRLever simLever;
    [SerializeField]
    TvRemote tvRemote;
    [SerializeField]
    ModePanel modePanel;

    public enum FunctionType { ResetScene, TvButton, ModePanel }
    public FunctionType functionType = FunctionType.ResetScene;

    //check if lever is pulled if one exists
    private bool LeverIsPulled(VRLever lever)
    {
        if (simLever != null)
        {
            if (simLever.leverPulled)
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(functionType)
            {
                case FunctionType.ResetScene:
                    if (LeverIsPulled(simLever))
                    {
                        VRActions.ResetScene();
                    }
                    break;
                case FunctionType.TvButton:
                    VRActions.TVButton(tvRemote, name);
                    break;
                case FunctionType.ModePanel:
                    VRActions.ChangeMode(modePanel, name);
                    break;
            }
        }
    }
}
