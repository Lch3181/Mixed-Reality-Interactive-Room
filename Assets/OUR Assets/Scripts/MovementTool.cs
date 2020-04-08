using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTool : MonoBehaviour
{
    [SerializeField]
    GameObject theClaw;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "PlayerLeft" && other.tag != "PlayerRight")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                other.transform.position = theClaw.transform.position;
                other.transform.rotation = theClaw.transform.rotation;
            }
        }
    }
}
