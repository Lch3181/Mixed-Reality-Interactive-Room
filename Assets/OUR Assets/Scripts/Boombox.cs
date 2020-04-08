using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombox : MonoBehaviour
{
    public bool radioOn = false;

    [SerializeField]
    AudioSource radio;

    [SerializeField]
    MeshRenderer powerIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RadioPower()
    {
        Debug.Log(radioOn);
        if (radioOn)
        {
            radio.Pause();
            powerIndicator.material.color = Color.grey;
            radioOn = false;
        }
        else
        {
            radio.Play();
            powerIndicator.material.color = Color.red;
            radioOn = true;
        }
    }
}
