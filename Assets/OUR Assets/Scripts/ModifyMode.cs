using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyMode : MonoBehaviour
{
    public enum ModifyModes { None, Movement, Style, Measurement }
    public ModifyModes mode = ModifyModes.None;

    public GameObject toolInHand;
    int tools;

    [SerializeField]
    GameObject LeftHand;

    [SerializeField]
    GameObject LeftHandToolSelector;

    GameObject LeftHandModifyTool;

    // Start is called before the first frame update
    void Start()
    {
        tools = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OpenLeftHandTools();
    }

    public void PutAway()
    {

    }

    public void DropTool(GameObject hand)
    {
        try
        {
            hand.transform.GetChild(0);
            Destroy(hand.transform.GetChild(0).gameObject);
        }
        catch (Exception e) { }
    }

    private void OpenLeftHandTools()
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
                    LeftHand.transform.rotation.y,
                    LeftHand.transform.rotation.z,
                    LeftHand.transform.rotation.w)); ;
            }
        }
        else if (LeftHandModifyTool != null)
        {
            Destroy(LeftHandModifyTool.gameObject);
        }
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
}
