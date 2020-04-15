using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Material color;
    public GameObject penSize;
    public GameObject TargetBoard;

    private void OnTriggerStay(Collider other)
    {
        if(other.name == TargetBoard.name)
        {
            Instantiate(penSize, new Vector3(other.transform.position.x, penSize.transform.position.y, penSize.transform.position.z), Quaternion.identity);
        }
    }

}
