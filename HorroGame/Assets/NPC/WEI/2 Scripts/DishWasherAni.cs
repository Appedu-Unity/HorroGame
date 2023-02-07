using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWasherAni : MonoBehaviour
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

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ani.SetTrigger("¬~¸J¾÷¶}Ãö");
            //print("11111");
        }
    }
}
