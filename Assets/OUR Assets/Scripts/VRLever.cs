using System.Collections;
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
    
    [SerializeField]
    ModePanel modePanel;

    public enum FunctionType { ButtonReliant, ActivateMode }
    public FunctionType functionType = FunctionType.ButtonReliant;

    // Start is called before the first frame update
    void Start()
    {
        initLeverPos = transform.localPosition;
        handleMesh = handle.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandLogic();
    }

    public void LeverIsDown()
    {
        switch(functionType)
        {
            case FunctionType.ButtonReliant:
                break;
            case FunctionType.ActivateMode:
                VRActions.ActivateMode(modePanel);
                break;
        }
    }

    private void HandLogic()
    {
        if (onLever)
        {
            OVRInput.Controller hand = VRActions.GetHandByButton(OVRInput.Button.PrimaryHandTrigger);
            if (hand != OVRInput.Controller.None)
            {
                if (!pullingLever)
                {
                    pullingLever = true;
                    initHandPos = OVRInput.GetLocalControllerPosition(hand);
                    handleMesh.material.color = Color.yellow;
                }

                if (leverPulled)
                {
                    handleMesh.material.color = Color.red;
                }
                else
                {
                    MoveLever(hand);
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
            transform.localPosition = Vector3.Lerp(transform.localPosition, initLeverPos, 0.5f);
            handleMesh.material.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLeft") || other.CompareTag("PlayerRight") || other.CompareTag("theClaw"))
        {
            onLever = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerLeft") || other.CompareTag("PlayerRight") || other.CompareTag("theClaw"))
        {
            handleMesh.material.color = Color.white;
            Vector3.Lerp(transform.localPosition, initLeverPos, .5f);
            onLever = false;
            pullingLever = false;
            leverPulled = false;
        }
    }

    private void MoveLever(OVRInput.Controller hand)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = initLeverPos.y - (initHandPos.y - OVRInput.GetLocalControllerPosition(hand).y);
        if (newPosition.y <= initLeverPos.y - 0.2f)
        {
            newPosition.y = initLeverPos.y - 0.2f;
            LeverIsDown();
            leverPulled = true;
        }
        else if (newPosition.y > initLeverPos.y)
        {
            newPosition.y = initLeverPos.y;
        }
        transform.localPosition = newPosition;
    }
}
