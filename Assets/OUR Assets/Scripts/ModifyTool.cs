using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTool : MonoBehaviour
{
    ModifyMode mode;

    GameObject objectInHand;

    [SerializeField]
    GameObject moveTool;
    [SerializeField]
    GameObject remoteTool;
    [SerializeField]
    GameObject measurementTool;

    Vector3 defaultSize;
    int tools;

    // Start is called before the first frame update
    void Start()
    {
        mode = FindObjectOfType<ModifyMode>();
        defaultSize = transform.localScale;
        tools = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToolHover()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, 1.5f * defaultSize, .5f);
    }

    private void ToolNormal()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, defaultSize, .5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerRight"))
        {
            ToolHover();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerRight") && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            if (name.Contains("MovementTool"))
            {
                if (tools == 0)
                {
                    mode.DropTool(other.gameObject);
                    mode.MovementMode(); 
                    objectInHand = Instantiate(moveTool, other.transform, false);
                }
                tools++;
            }
            else if (name.Contains("TVRemote"))
            {
                if (tools == 0)
                {
                    mode.DropTool(other.gameObject);
                    mode.RemoteMode();
                    objectInHand = Instantiate(remoteTool, other.transform, false);
                }
                tools++;
            }
            else if (name.Contains("MeasurementTool"))
            {
                if (tools == 0)
                {
                    mode.DropTool(other.gameObject);
                    mode.MeasurementMode();
                    objectInHand = Instantiate(measurementTool, other.transform, false);
                }
                tools++;
            }
            else if (name.Contains("PutAway"))
            {
                mode.DropTool(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerRight"))
        {
            ToolNormal();
        }
    }
}
