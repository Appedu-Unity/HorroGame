using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject cam;

    float moveSpeed;
    float f_deltatime;
    float UDSensitivity;
    float RLSensitivity;
    float lookRotation;

    Vector3 v3_zero;
    Vector3 v3_moveValue;
    Vector3 v3_movePos;

    private Rigidbody rig;
    private Collision coll;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        coll = GetComponent<Collision>();
        cam = GameObject.Find("Camera");
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        moveSpeed = 180;
        UDSensitivity = 120;
        RLSensitivity = 120;

        f_deltatime = Time.deltaTime;
        v3_zero = Vector3.zero;
    }

    private void Update()
    {
        //  左右轉
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * RLSensitivity * f_deltatime);

        lookRotation += Input.GetAxis("Mouse Y") * UDSensitivity * f_deltatime;
        lookRotation = Mathf.Clamp(lookRotation, -75, 75);

        //  上下轉
        cam.transform.localEulerAngles = -Vector3.right * lookRotation;

        v3_moveValue = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        v3_movePos.x = v3_moveValue.x * f_deltatime * moveSpeed;
        v3_movePos.z = v3_moveValue.z * f_deltatime * moveSpeed;

        v3_movePos = transform.right * v3_movePos.x + transform.forward * v3_movePos.z;

        if (v3_movePos != v3_zero)
            rig.velocity = v3_movePos;
        else
            rig.velocity = v3_zero;
    }

}
