using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTool : MonoBehaviour
{
    [SerializeField]
    bool useInEnjoyMode;
    bool onHand = false;

    [SerializeField]
    GameObject objectTrigger;
    [SerializeField]
    GameObject shaft;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onHand)
        {
            transform.localPosition = new Vector3(-0.25f, -0.5f, -0.5f);
        }
        if (useInEnjoyMode && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            onHand = false;
            transform.parent = null;
            rb.isKinematic = false;
        }
        else if (!useInEnjoyMode && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!onHand)
        {
            if (other.CompareTag("PlayerRight"))
            {
                if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
                {
                    rb.isKinematic = true;
                    transform.SetParent(other.transform);
                    transform.localScale = Vector3.one * 4;
                }
            }
        }
    }
}
