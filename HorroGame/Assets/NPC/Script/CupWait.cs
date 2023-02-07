using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupWait : MonoBehaviour
{
    // Start is called before the first frame update
    Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
        Debug.Log("Start of CupWait");
        
    }

    IEnumerator AnimStart()
    {
        Debug.Log("Enter AnimStart");
        yield return new WaitForSeconds(2.9f);
        Debug.Log("Return back to AnimStart");
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
