using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRActions
{
    public static OVRInput.Controller GetHandByButton(OVRInput.Button button)
    {
        if (OVRInput.Get(button, OVRInput.Controller.LTouch))
        {
            return OVRInput.Controller.LTouch;
        }
        else if (OVRInput.Get(button, OVRInput.Controller.RTouch))
        {
            return OVRInput.Controller.RTouch;
        }
        return OVRInput.Controller.None;
    }

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public static void GoToPrestonsRoom()
    {
        SceneManager.LoadScene("PrestonsRoom", LoadSceneMode.Single);
    }

    public static void GoToLobby()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }

    public static void ActivateMode(ModePanel modePanel)
    {
        modePanel.Activate();
    }

    public static void TVButton(TvRemote tvRemote, string button)
    {
        tvRemote.ButtonPressed(button);
    }

    public static void BoomboxButton(Boombox boombox)
    {
        boombox.RadioPower();
    }
}
