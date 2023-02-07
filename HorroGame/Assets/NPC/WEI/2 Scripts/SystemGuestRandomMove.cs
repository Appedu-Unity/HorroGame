using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGuestRandomMove : MonoBehaviour
{
    Transform posMine;

    public Vector3[] pos;

    private void Awake()
    {
        transform.Find("posA");
        posMine = GetComponent<Transform>();
        Component[] rdrs = this.GetComponentsInChildren(typeof(Renderer), true);
    }
    private void Update()
    {
        GuestMove();
    }
    void GuestMove()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(Random.Range(0,pos.Length+1));
        }
    }

}
