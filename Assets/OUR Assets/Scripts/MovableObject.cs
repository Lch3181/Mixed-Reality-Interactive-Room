using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
//    Rigidbody rb;
//    MovementTool claw;

//    bool grabbed;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (grabbed)
//        {
//            FollowClaw();
//        }
//        else
//        {
//            LetGo();
//        }
//    }

//    private void FollowClaw()
//    {
//        rb.isKinematic = true;
//        transform.position = claw.ObjectTrigger.transform.position;
//        transform.rotation = Quaternion.Lerp(transform.rotation, claw.ObjectTrigger.transform.rotation, .5f);
//    }

//    private void LetGo()
//    {
//        rb.isKinematic = false;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //bool takeAway = false;
//        //if (other.CompareTag("PlayerLeft") || other.CompareTag("PlayerRight"))
//        //{
//        //    if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger | OVRInput.Button.SecondaryHandTrigger))
//        //    {
//        //        takeAway = true;
//        //    }
//        //}

//        if (other.CompareTag("theClaw"))
//        {
//            claw = other.GetComponentInParent<MovementTool>();
//            if (claw.squeezing)
//            {
//                grabbed = true;
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("theClaw")) {
//            if (!claw.squeezing)
//            {
//                claw = null;
//                grabbed = false;
//            }
//        }
//    }
}
