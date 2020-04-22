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
    Boombox boombox;
    [SerializeField]
    ModePanel modePanel;

    public enum FunctionType { ResetScene, TvButton, BoomboxButton, PrestonsRoom, Lobby }
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

    private bool ButtonOneIsPushed(string tag)
    {
        if (tag == "PlayerLeft")
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                return true;
            }
        }
        else if (tag == "PlayerRight")
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                return true;
            }
        }
        else if (tag == "theClaw")
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLeft") || other.CompareTag("PlayerRight") || other.CompareTag("theClaw"))
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
                    if (ButtonOneIsPushed(other.tag))
                    {
                        VRActions.TVButton(tvRemote, name);
                    }
                    break;
                case FunctionType.BoomboxButton:
                    if (ButtonOneIsPushed(other.tag))
                    {
                        VRActions.BoomboxButton(boombox);
                    }
                    break;
                case FunctionType.PrestonsRoom:
                    if (LeverIsPulled(simLever))
                    {
                        VRActions.GoToPrestonsRoom();
                    }
                    break;
                case FunctionType.Lobby:
                    if (LeverIsPulled(simLever))
                    {
                        VRActions.GoToLobby();
                    }
                    break;
            }
        }
    }
}
