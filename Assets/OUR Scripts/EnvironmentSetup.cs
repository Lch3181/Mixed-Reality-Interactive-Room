using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    public Text cornerPosition;
    public GameObject canvas;
    List<Vector3> corners;
    Vector3 rPosition;
    Quaternion rRotation;

    int clicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas.Enabled = true;
        corners = new List<Vector3>();
        cornerPosition.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch))
        {
            GetOVRControllerPosition();
            GetFourCorners();
        }
    }

    void GetOVRControllerPosition()
    {
        rPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        rRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
    }

    void GetFourCorners()
    {
        Vector3 position = new Vector3(rPosition.x, rPosition.y, rPosition.z);
        //Debug.Log(OVRInput.Get(OVRInput.Axis1D.Any));
        if (OVRInput.Get(OVRInput.Axis1D.Any) > 0.75f && clicks == 0)
        {
            clicks++;

            corners.Add(position);
            //cornerPosition.text += position.ToString() + "\n";
            cornerPosition.text += ("loolooloo");
            //Debug.Log(position.ToString());
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.1f)
        {
            clicks = 0;
        }
    }
}
