using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    [SerializeField]
    Television tv;
    [SerializeField]
    GameObject tvShade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerOn()
    {
        tvShade.SetActive(false);
    }

    public void PowerOff()
    {
        tvShade.SetActive(true);
    }
}
