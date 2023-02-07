using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrigeratorAni : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            ani.SetTrigger("¦B½c¶}Ãö");
        }
    }
}
