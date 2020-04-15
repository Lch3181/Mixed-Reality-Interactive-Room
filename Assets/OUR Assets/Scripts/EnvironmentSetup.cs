using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    public GameObject Environment;
    public bool modify;

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.Update();

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch))
        {
            if (modify)
            {
                InitRoom();
            }
        }
    }

    public void ChangeMode(bool modify)
    {
        this.modify = modify;
        Debug.Log("modify=" + modify);
    }

    void InitRoom()
    {
        if (OVRInput.Get(OVRInput.Button.One)) //Right Button A
        {
            Vector3 rPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            //set floor height
            Environment.transform.position = new Vector3(Environment.transform.position.x, rPosition.y - 0.1f, Environment.transform.position.z);
        }
        if(OVRInput.GetUp(OVRInput.Button.One))
        {
            modify = false;
        }
    }
}
