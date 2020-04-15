using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("furniture"))
        {
            other.GetComponent<ModifiableObject>().ChangeObjectColor(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("furniture"))
        {
            other.gameObject.GetComponent<ModifiableObject>().ChangeObjectColor(other.gameObject);
        }
    }
}
