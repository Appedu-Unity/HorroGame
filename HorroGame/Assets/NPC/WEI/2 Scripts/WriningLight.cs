using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriningLight : MonoBehaviour
{
    public void WriningLightOpen()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void WriningLightClose()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
