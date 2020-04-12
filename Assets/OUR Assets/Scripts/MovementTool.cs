using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTool : MonoBehaviour
{
    [SerializeField]
    GameObject theClaw;

    Vector3 initPosit;
    
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
                Debug.Log("Got it");
                Rigidbody otherRb = other.GetComponent<Rigidbody>();
                if (otherRb != null)
                {
                    otherRb.isKinematic = true;
                }
                other.transform.position = new Vector3(initPosit.x + (initPosit.x - theClaw.transform.position.x), theClaw.transform.position.y, theClaw.transform.position.z);
            }
        }
    }
}
