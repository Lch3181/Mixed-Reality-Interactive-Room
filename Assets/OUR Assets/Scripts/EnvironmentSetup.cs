using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Floor;
    public GameObject Room;
    public Text cornerPosition;
    private bool RoomSpawned = false;

    private float initPosit;
    private float initHandPosit;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.Update();

        if (Environment.GetComponent<ModifyMode>().mode == ModifyMode.ModifyModes.Measurement)
        {
            if (modify)
            {
                InitRoom();
            }
        }
    }

    //When Button.One is pressed while in measurement mode, it will set the floor level
    void SetFloorLevel()
    {
        Vector3 rPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        if (count == 0)
        {
            initPosit = Floor.transform.position.y;
            initHandPosit = rPosition.y;
            count++;
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            Vector3 newPosition = Floor.transform.position;
            newPosition.y = initPosit - (initHandPosit - OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).y);
            if (newPosition.y <= initPosit - 0.5f)
            {
                newPosition.y = initPosit - 0.5f;
            }
            else if (newPosition.y > initPosit + 0.5f)
            {
                newPosition.y = initPosit + 0.5f;
            }
            Floor.transform.position = newPosition;
        }
        else
        {
            count = 0;
        }
    }

    void SetRoomRotation()
    {
        if(OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            Environment.transform.Rotate(0, Environment.transform.rotation.y - 0.5f, 0, Space.World);
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
