using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButton : MonoBehaviour
{
    [SerializeField]
    VRLever simLever;
    [SerializeField]
    TvRemote tvRemote;

    public enum FunctionType { ResetScene, TvButton }
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

    private void ResetScene()
    {
        if (LeverIsPulled(simLever))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    private void TVButton(Collider other)
    {
        if (tvRemote != null)
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                tvRemote.ButtonPressed(this.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(functionType)
            {
                case FunctionType.ResetScene:
                    ResetScene();
                    break;
                case FunctionType.TvButton:
                    TVButton(other);
                    break;
            }
        }
    }
}
