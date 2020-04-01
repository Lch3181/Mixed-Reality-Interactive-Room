using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyMode : MonoBehaviour
{
    [SerializeField]
    GameObject LeftHandToolSelector;
    [SerializeField]
    GameObject RightHandToolSelector;

    GameObject LeftHandModifyTool;
    GameObject RightHandModifyTool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<EnvironmentSetup>().modify)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.25f)
            {
                if (LeftHandModifyTool == null)
                {
                    LeftHandModifyTool = Instantiate(LeftHandToolSelector, OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch)); ;
                }
                OpenLeftHandTools();
            }
            else
            {
                Destroy(LeftHandModifyTool.gameObject);
            }
        }
        else
        {
            LeftHandToolSelector.transform.localScale = Vector3.zero;
        }
    }

    private void OpenLeftHandTools()
    {
        LeftHandModifyTool.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        LeftHandModifyTool.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        LeftHandModifyTool.transform.localScale = Vector3.one * OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
    }

    private void OpenRightHandTools()
    {

    }
}
