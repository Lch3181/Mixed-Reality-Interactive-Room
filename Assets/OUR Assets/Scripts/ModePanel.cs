using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModePanel : MonoBehaviour
{
    [SerializeField]
    MeshRenderer modifyLed;
    [SerializeField]
    MeshRenderer enjoyLed;

    public bool modify { get; private set; }

    // Start is called before the first frame update
    void Start()
    {        modify = false;
        modifyLed.material.color = Color.black;
        enjoyLed.material.color = Color.green;
    }

    public void ChooseModify()
    {
        if (modifyLed.material.color == Color.green)
        {
            enjoyLed.material.color = Color.black;
        }
        else
        {
            modifyLed.material.color = Color.red;
        }
        modify = true;
    }

    public void ChooseEnjoy()
    {
        if (enjoyLed.material.color == Color.green)
        {
            modifyLed.material.color = Color.black;
        }
        else
        {
            enjoyLed.material.color = Color.red;
        }
        modify = false;
    }

    public void Activate()
    {
        if (modify)
        {
            modifyLed.material.color = Color.green;
            enjoyLed.material.color = Color.black;
        }
        else
        {
            enjoyLed.material.color = Color.green;
            modifyLed.material.color = Color.black;
        }
        FindObjectOfType<EnvironmentSetup>().ChangeMode(modify);
    }
}
