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
    void Update()
    {
        OVRInput.Update();

        if (Environment.GetComponent<ModifyMode>().mode == ModifyMode.ModifyModes.Measurement) //(modify)
        {
            SetFloorLevel();
            //SetRoomCorner();
            //SetRoomRotation();
        }
    }

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


        //if (OVRInput.Get(OVRInput.Button.One)) //Right Button A
        //{
        //    if (count == 0)
        //    {
        //        initPosit = transform.position.y;
        //        initHandPosit = rPosition.y;
        //        count++;
        //    }
        //    //set floor height
        //    Vector3 newPosition = Environment.transform.position;
        //    newPosition.y = initHandPosit + (rPosition.y - 0.1f);
        //    if (newPosition.y < initPosit - 2)
        //    {
        //        newPosition.y = initPosit - 2;
        //    }
        //    else if (newPosition.y > initPosit + 2)
        //    {
        //        newPosition.y = initPosit + 2;
        //    }
        //    transform.position = newPosition;

        //    spawn room on first time
        //    if (!RoomSpawned)
        //    {
        //        SpawnRoom(new Vector3(rPosition.x, Environment.transform.position.y, rPosition.z));
        //        RoomSpawned = true;
        //    }
        //}
        //else
        //{
        //}
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
