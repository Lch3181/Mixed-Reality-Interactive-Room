using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTool : MonoBehaviour
{
    Vector3 initPosit;
    
    [SerializeField]
    GameObject objectTrigger;
    [SerializeField]
    GameObject shaft;

    Rigidbody rb;
    Vector3 startPos;
    ModifiableObject heldObject;

    int buttonPresses = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(-0.25f, -0.5f, -0.5f);

        if (!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            heldObject = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "PlayerLeft" && other.tag != "PlayerRight")
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                if (heldObject == null)
                {
                    heldObject = objectTrigger.GetComponent<OVRGrabber>().grabbedObject.GetComponent<ModifiableObject>();
                }
                if (buttonPresses == 0)
                {
                    heldObject.RotateObject();
                    buttonPresses++;
                }
            }
            else
            {
                buttonPresses = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            buttonPresses = 0;
        }
    }
}
