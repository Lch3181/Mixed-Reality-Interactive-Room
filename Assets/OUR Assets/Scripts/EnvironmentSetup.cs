using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    public GameObject Environment;
    public bool modify = false;
    public Text cornerPosition;
    List<Vector3> corners;

    // Start is called before the first frame update
    void Start()
    {
        corners = new List<Vector3>();
        cornerPosition.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch))
        {
            if (true) //(modify)
            {
                SetFloorLevel();
                SetRoomCorner();
                SetRoomRotation();
            }
        }
    }

    public void ChangeMode(bool modify)
    {
        this.modify = modify;
        Debug.Log("modify=" + modify);
    }

    void SetFloorLevel()
    {
        if (OVRInput.Get(OVRInput.Button.One)) //Right Button A
        {
            Vector3 rPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            //set floor height
            Environment.transform.position = new Vector3(Environment.transform.position.x, rPosition.y - 0.1f, Environment.transform.position.z);
        }
    }

    void SetRoomRotation()
    {
        if(OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            Environment.transform.Rotate(0, Environment.transform.rotation.y - 0.5f, 0, Space.World);
        }
        else if(OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            Environment.transform.Rotate(0, Environment.transform.rotation.y + 0.5f, 0, Space.World);
        }
    }

    void SetRoomCorner()
    {
        Vector3 lPosition = new Vector3(0, 0, 0);
        Vector3 rPosition = new Vector3(0, 0, 0);
        if (OVRInput.Get(OVRInput.Button.Four)) //Left Button B
        {
            lPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        }
        if (OVRInput.Get(OVRInput.Button.Two)) //Right Button B
        {
            rPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        }
        if (lPosition != new Vector3(0,0,0) && rPosition != new Vector3(0, 0, 0))
        {
            Vector3 intersect = Intersect(lPosition, new Vector3(0, 0, 0), rPosition, new Vector3(0, 0, 0));
            Debug.Log(intersect);
            //set corner
            Environment.transform.position = new Vector3(lPosition.x + 0.05f, Environment.transform.position.y, rPosition.z - 0.05f);
        }

    }

    public static Vector3 Intersect(Vector3 line1V1, Vector3 line1V2, Vector3 line2V1, Vector3 line2V2)
    {
        //Line1
        float A1 = line1V2.z - line1V1.z;
        float B1 = line1V2.x - line1V1.x;
        float C1 = A1 * line1V1.x + B1 * line1V1.z;

        //Line2
        float A2 = line2V2.z - line2V1.z;
        float B2 = line2V2.x - line2V1.x;
        float C2 = A2 * line2V1.x + B2 * line2V1.z;

        float det = A1 * B2 - A2 * B1;
        if (det == 0)
        {
            return new Vector3(0, 0, 0);//parallel lines
        }
        else
        {
            float x = (B2 * C1 - B1 * C2) / det;
            float y = (A1 * C2 - A2 * C1) / det;
            return new Vector3(x, y, 0);
        }
    }
}
