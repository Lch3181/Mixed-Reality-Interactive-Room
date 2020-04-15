using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiableObject : MonoBehaviour
{
    System.Random rand = new System.Random();

    [SerializeField]
    List<GameObject> styles = new List<GameObject>();

    int color = 0;

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

    public void ChangeObjectColor(GameObject obj)
    {
        if (color == styles.Count - 1)
        {
            color = 0;
        }
        else
        {
            color++;
        }
        GameObject stylizedObj = Instantiate(styles[color], transform.position, transform.rotation);
        stylizedObj.transform.SetParent(FindObjectOfType<ModifyMode>().transform);
        Destroy(this.gameObject);
    }
}
