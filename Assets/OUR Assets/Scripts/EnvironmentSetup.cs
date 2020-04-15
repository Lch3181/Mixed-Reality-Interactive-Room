using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSetup : MonoBehaviour
{
    private GameObject Environment;
    public GameObject Room;
    public GameObject Cornor;
    public bool modify;
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
            //spawn room on first time
            if (!RoomSpawned)
            {
                Environment = new GameObject("Room");
                SpawnRoom(new Vector3(rPosition.x - Cornor.transform.position.x, Environment.transform.position.y, rPosition.z - Cornor.transform.position.z));
                RoomSpawned = true;
            }
            //set floor height
            Environment.transform.position = new Vector3(Environment.transform.position.x, rPosition.y - 0.1f, Environment.transform.position.z);
            Environment.SetActive(true);
        }
        if(OVRInput.GetUp(OVRInput.Button.One))
        {
            modify = false;
            return;
        }
    }

    void SpawnRoom(Vector3 pos)
    {
        Environment = Instantiate(Room, pos, Quaternion.identity) as GameObject;
    }
}
