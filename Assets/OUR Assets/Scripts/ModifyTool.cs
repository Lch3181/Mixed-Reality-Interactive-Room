using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTool : MonoBehaviour
{
    ModifyMode mode;

    [SerializeField]
    GameObject moveTool;
    [SerializeField]
    GameObject styleTool;
    [SerializeField]
    GameObject measurementTool;

    Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        mode = FindObjectOfType<ModifyMode>();
        defaultSize = transform.localScale;
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
                mode.MovementMode();
                GameObject movementTool = Instantiate(moveTool, other.transform, false);
                movementTool.transform.localScale = Vector3.one * 4;
                //movementTool.transform.localPosition = new Vector3(-0.25f, -0.5f, -1);
            }
            else if (name.Contains("StyleTool"))
            {
                mode.StyleMode();
            }
            else if (name.Contains("MeasurementTool"))
            {
                mode.MeasurementMode();
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
