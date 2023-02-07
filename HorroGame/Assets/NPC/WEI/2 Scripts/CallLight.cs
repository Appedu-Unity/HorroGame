using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLight : MonoBehaviour
{
    public void CallLightOpen()
    { 
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void CallLightClose()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
