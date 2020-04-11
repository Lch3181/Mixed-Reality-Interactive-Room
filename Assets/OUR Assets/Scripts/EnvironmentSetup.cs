using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Room;
    public bool modify = false;
    public Text cornerPosition;
    private bool RoomSpawned = false;


    // Start is called before the first frame update
    void Start()
    {

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
                //SetRoomRotation();
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
            //spawn room on first time
            if (!RoomSpawned)
            {
                SpawnRoom(new Vector3(rPosition.x, Environment.transform.position.y, rPosition.z));
                RoomSpawned = true;
            }
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
            //set corner
            //Environment.transform.position = new Vector3(lPosition.x + 0.05f, Environment.transform.position.y, rPosition.z - 0.05f);
        }

    }

    void SpawnRoom(Vector3 pos)
    {
        Environment = Instantiate(Room, pos, Quaternion.identity) as GameObject;
    }
}
