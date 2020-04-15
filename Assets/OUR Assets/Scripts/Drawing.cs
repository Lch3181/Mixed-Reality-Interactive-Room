using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Material color;
    public GameObject penSize;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "WhiteBoard")
        {
            Instantiate(penSize, new Vector3(other.transform.position.x, penSize.transform.position.y, penSize.transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "WhiteBoard")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "WhiteBoard")
        {
            
        }
    }
}
