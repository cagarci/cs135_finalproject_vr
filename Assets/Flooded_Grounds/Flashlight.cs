using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn; 
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            isOn = !isOn;
            if(isOn){
                GetComponent<Light>().enabled = true;
            }
            else{
                GetComponent<Light>().enabled = false;
            }
        }
    }
}
