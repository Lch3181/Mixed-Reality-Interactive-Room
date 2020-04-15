using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiableObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateObject()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += 45;
        transform.eulerAngles = newRotation;
    }
}
