using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroWaveOvenIN : MonoBehaviour
{
    public GameObject Microwaveoven;

    public Transform pointA;
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
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Microwaveoven, pointA.position, pointA.rotation);
        }
    }
}
