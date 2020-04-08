using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyMode : MonoBehaviour
{
    public enum ModifyModes { None, Movement, Style, Measurement }
    public ModifyModes mode = ModifyModes.None;

    [SerializeField]
    GameObject LeftHand;
    [SerializeField]
    GameObject RightHand;

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
        OpenLeftHandTools();
        ApplyModeEffects();
    }

    private void OpenLeftHandTools()
    {
        if (FindObjectOfType<EnvironmentSetup>().modify)
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                if (LeftHandModifyTool == null)
                {
                    LeftHandModifyTool = Instantiate(LeftHandToolSelector,
                        new Vector3(LeftHand.transform.position.x - 0.1f,
                        LeftHand.transform.position.y + 0.15f,
                        LeftHand.transform.position.z),
                        new Quaternion(LeftHand.transform.rotation.x,
                        LeftHand.transform.rotation.y + .3f,
                        LeftHand.transform.rotation.z,
                        LeftHand.transform.rotation.w)); ;
                }
            }
            else if (LeftHandModifyTool != null)
            {
                Destroy(LeftHandModifyTool.gameObject);
            }
        }
        else if (LeftHandModifyTool != null)
        {
            Destroy(LeftHandModifyTool.gameObject);
        }
    }

    private void ApplyModeEffects()
    {
        
    }

    public void MovementMode()
    {
        mode = ModifyModes.Movement;
        PlayerPrefs.SetInt("mode", 1);
    }

    public void StyleMode()
    {
        mode = ModifyModes.Style;
        PlayerPrefs.SetInt("mode", 2);
    }

    public void MeasurementMode()
    {
        mode = ModifyModes.Measurement;
        PlayerPrefs.SetInt("mode", 3);
    }

    private void OpenRightHandTools()
    {

    }
}
