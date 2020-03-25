﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLever : MonoBehaviour
{
    public bool leverPulled = false;
    bool onLever = false;
    bool pullingLever = false;

    [SerializeField]
    GameObject handle;
    Vector3 initLeverPos;
    Vector3 initHandPos;
    MeshRenderer handleMesh;

    // Start is called before the first frame update
    void Start()
    {
        initLeverPos = transform.position;
        handleMesh = handle.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onLever)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                if (!pullingLever)
                {
                    pullingLever = true;
                    initHandPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
                    handleMesh.material.color = Color.yellow;
                }

                if (leverPulled)
                {
                    handleMesh.material.color = Color.red;
                }
                else
                {
                    MoveLever();
                }
            }
            else if (pullingLever)
            {
                onLever = false;
            }
            else
            {
                handleMesh.material.color = Color.green;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initLeverPos, 0.5f);
            handleMesh.material.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onLever = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            handleMesh.material.color = Color.white;
            Vector3.Lerp(transform.position, initLeverPos, .5f);
            onLever = false;
            pullingLever = false;
            leverPulled = false;
        }
    }

    private void MoveLever()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = initLeverPos.y - (initHandPos.y - OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).y);
        if (newPosition.y <= initLeverPos.y - 0.2f)
        {
            newPosition.y = initLeverPos.y - 0.2f;
            leverPulled = true;
        }
        else if (newPosition.y > initLeverPos.y)
        {
            newPosition.y = initLeverPos.y;
        }
        transform.position = newPosition;
    }
}
