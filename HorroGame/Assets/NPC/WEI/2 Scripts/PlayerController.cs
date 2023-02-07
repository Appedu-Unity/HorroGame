using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Field
    [SerializeField] GameObject cam;

    [SerializeField] float UDSensitivity, RLSensitivity;

    [SerializeField] float moveSpeed, deltatime, lookRotation;

    [SerializeField] int InteractiveLayer, StoryColliderLayer;

    [SerializeField] Vector3 zero, moveValue, movePos;

    [SerializeField] float rangeStopNPC;

    public GameObject UIC;

    bool isOpen;
    Rigidbody rig;
    CapsuleCollider coll;
    #endregion

    #region Base
    private void Awake()
    {
        coll = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera");
    }
    private void Start()
    {
        Init();
    }
    void FixedUpdate()
    {
        View();
        Move();
    }
    #endregion

    /// <summary>
    /// NPC動畫
    /// </summary>
    /// <param name="other"></param>
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "NPC")
    //    {
    //        NPCAni.Play("Wave");
    //    }
    //    if (other.gameObject.tag == "TalkArea")
    //    {
    //        refrigeratorAni.Play("Refrigerator");
    //        NPCAni.Play("Talk");
    //    }
    //    if (other.gameObject.tag == "NPC2")
    //    {
    //        NPCAni2.Play("Wave");
    //    }
    //    if (other.gameObject.tag == "TalkArea2")
    //    {
    //        refrigeratorAni.Play("DishwasherOpen");
    //        NPCAni2.Play("Talk");
    //    }
    //    if (other.gameObject.tag == "NPC3")
    //    {
    //        NPCAni3.Play("Wave");
    //    }
    //    if (other.gameObject.tag == "TalkArea3")
    //    {
    //        refrigeratorAni.Play("oven");
    //        NPCAni3.Play("Talk");
    //    }
    //}
    /// <summary>
    /// 初始化
    /// </summary>
    void Init()
    {
        moveSpeed = 1000;
        UDSensitivity = 120;
        RLSensitivity = 80;

        InteractiveLayer = 10;
        rangeStopNPC = 5;
        lookRotation = 7;

        deltatime = Time.deltaTime;
        zero = Vector3.zero;
    }
    /// <summary>
    /// 觀看視角
    /// </summary>
    void View()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * RLSensitivity * deltatime);

        lookRotation += Input.GetAxis("Mouse Y") * UDSensitivity * deltatime;

        lookRotation = Mathf.Clamp(lookRotation, -75, 75);

        cam.transform.localEulerAngles = -Vector3.right * lookRotation;
    }
    void Move()
    {
        moveValue = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        movePos.x = moveValue.x * deltatime * moveSpeed;
        movePos.z = moveValue.z * deltatime * moveSpeed;

        movePos = transform.right * movePos.x + transform.forward * movePos.z;

        if (movePos != zero)
            rig.velocity = movePos;
        else
            rig.velocity = zero;
    }
    void Open()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            UIC.SetActive(isOpen);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(0,1,0,.3f);
    //    Gizmos.DrawSphere(transform.position,rangeStopNPC);
    //}
}