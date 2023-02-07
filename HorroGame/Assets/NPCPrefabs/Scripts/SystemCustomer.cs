using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
//using Oculus.Interaction.Samples;
using Unity.VisualScripting;
//using ReadyPlayerMe;
using UnityEngine.UI;

public class SystemCustomer : MonoBehaviour
{
    #region Field
    [Header("移動速度")] public float speed;
    [Header("NPC避開後預設位置")][SerializeField] private Collider[] hitTraget;
    [Header("NPC商品介紹位置")][SerializeField] private Collider[] PosTraget;
    //[Header("NPC被呼叫位置")][SerializeField]private Collider[] callPosTraget;
    public LayerMask hitTragetLayerMask;
    public LayerMask PosTragetLayerMask;
    //public LayerMask callNpcLayerMask;
    public GameObject calllight, wriningLight;
    public GameObject NPCTrageObj, NPCTragePos;
    public Transform TragePos;
    [SerializeField] int posID = 0;
    [SerializeField] float rangeDodge = 10f;
    [SerializeField] float rangeCommentary = 5f;
    [SerializeField] float dishWasherRange = 10f;
    [SerializeField] float ovenRange = 10f;
    [SerializeField] float refrigeratorRange = 10f;
    [SerializeField] float rangeStopNPC = 1.8f;

    //public Sprite ovenUI, refrigeratorUI, dishWasherUI;

    private Animator ani;
    private Rigidbody rig;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Transform dishWasher, oven, refrigerator;

    bool stopNPCMove;
    #endregion

    #region Base fashion
    /// <summary>
    /// NPC避開點位
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        //if (other.gameObject.name == "CommodityPos1" ||
        //    other.gameObject.name == "CommodityPos2" ||
        //    other.gameObject.name == "CommodityPos3")
        //{
        //    wriningLight.GetComponent<MeshRenderer>().material.color = Color.white;
        //    calllight.GetComponent<MeshRenderer>().material.color = Color.white;
        //    ani.SetBool("Idle", true);
        //    InvokeRepeating("FaceWhere", .01f, .01f);
        //    StartCoroutine("TurnArround");
        //    //FaceWhere();
        //}
        //if (other.tag == "NpcTrage")
        //{
        //    wriningLight.GetComponent<MeshRenderer>().material.color = Color.white;
        //    calllight.GetComponent<MeshRenderer>().material.color = Color.white;
        //    ani.SetBool("Idle", true);
        //    InvokeRepeating("FaceWhere", .01f, .01f);
        //    StartCoroutine("TurnArround");
        //    //FaceWhere();
        //}
        if (other.gameObject.name == "Pos1")
        {
            //StartCoroutine(TurnArround());
            ani.SetBool("Idle", true);
            InvokeRepeating("FaceWhere", .01f, .01f);
            //print(posID);
            PlayerOnDrawGizmosIn();
            posID++;
        }
        if (other.gameObject.name == "Pos2")
        {
            //StartCoroutine(TurnArround());
            ani.SetBool("Idle", true);
            InvokeRepeating("FaceWhere", .01f, .01f);
            //print(posID);
            posID++;
            PlayerOnDrawGizmosIn();
        }
        if (other.gameObject.name == "Pos3")
        {
            //StartCoroutine(TurnArround());
            ani.SetBool("Idle", true);
            InvokeRepeating("FaceWhere", .01f, .01f);
            //print(posID);
            posID++;
            PlayerOnDrawGizmosIn();
        }
        if (posID > 2)
        {
            posID = 0;
        }
    }
    /// <summary>
    /// 規劃區域
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeDodge);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeCommentary);

        Gizmos.color = new Color(1, 2, 6, 0.3f);
        Gizmos.DrawSphere(player.transform.position, rangeStopNPC);

        Gizmos.color = new Color(0, 1, 0.7f, 0.3f);
        Gizmos.DrawSphere(dishWasher.position, dishWasherRange);

        Gizmos.color = new Color(1, 0, 0.7f, 0.3f);
        Gizmos.DrawSphere(oven.position, ovenRange);

        Gizmos.color = new Color(1, 1, 0, 0.3f);
        Gizmos.DrawSphere(refrigerator.position, refrigeratorRange);
    }
    /// <summary>
    /// NPC基本動作方法
    /// </summary>
    void PlayerOnDrawGizmosIn()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (!stopNPCMove)   //移動中的PNC
        {
            if (dis < rangeCommentary)
            {
                CancelInvoke();
                print("rangeCommentary");
            }
            else if (dis < rangeDodge || stopNPCMove)
            {
                CancelInvoke();
                print("rangeDodge");
                ani.SetBool("Idle", false);
                ani.SetBool("walk", true);
                navMeshAgent.destination = hitTraget[posID].transform.position;
                //FaceWhere();
                StartCoroutine("TurnArround", 5);
            }
        }
        else                //NPC停止中
        {
            if (dis == rangeStopNPC)
            {
                ani.SetBool("Idle", true);
            }
        }
    }
    /// <summary>
    /// 尋找場景中需要的位置
    /// </summary>
    void FollowTarget()
    {
        hitTraget = Physics.OverlapSphere(transform.position, 100f, hitTragetLayerMask);
        PosTraget = Physics.OverlapSphere(transform.position, 100f, PosTragetLayerMask);
        //Debug.Log(hitTraget.Length);
    }
    #endregion

    #region Base
    private void Awake()
    {
        rangeStopNPC = 1.67f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        dishWasher = GameObject.Find("dish_washer").transform;
        oven = GameObject.Find("oven").transform;
        TragePos = GameObject.Find("TragePos").transform;
        refrigerator = GameObject.Find("refrigerator").transform;
    }
    void Start()
    {
        stopNPCMove = false;
        FollowTarget();
        navMeshAgent.destination = hitTraget[0].transform.position;
        ani.SetBool("walk", true);
    }
    private void Update()
    {
        PlayerOnDrawGizmosIn();
    }
    #endregion

    #region Face orientation
    /// <summary>
    /// NPC面相
    /// </summary>
    void FaceWhere()
    {
        //Vector3 v = player.transform.position - transform.position;
        //v.x = v.z = 0.0f;
        //transform.LookAt(player.transform.position - v);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(new Vector3(player.transform.position.x -
            transform.position.x, 0, player.transform.position.z - transform.position.z)),
            5.0f * Time.deltaTime);
    }
    /// <summary>
    /// 協成NPC面向
    /// </summary>
    /// <returns></returns>
    IEnumerator TurnArround()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(new Vector3(player.transform.position.x -
            transform.position.x, 0, player.transform.position.z - transform.position.z)),
            5.0f * Time.deltaTime);
        //Vector3 v = player.transform.position - transform.position;
        //v.x = v.z = 0.0f;
        //transform.LookAt(player.transform.position - v);
        yield return null;
    }
    IEnumerator CallNPCStatus()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            wriningLight.GetComponent<MeshRenderer>().material.color = Color.white;
            calllight.GetComponent<MeshRenderer>().material.color = Color.white;
            ani.SetBool("Idle", true);
            InvokeRepeating("FaceWhere", .01f, .01f);
            StartCoroutine("TurnArround");
        }
        yield return null;
    }
    #endregion

    #region Player call NPC fashion
    /// <summary>
    /// 玩家呼叫NPC
    /// </summary>
    private void call()
    {
        CancelInvoke();
        stopNPCMove = true;
        ani.SetBool("Idle", false);
    }
    public void CallNPC()
    {
        call();
        calllight.GetComponent<MeshRenderer>().material.color = Color.red;
        navMeshAgent.destination = NPCTragePos.transform.position;
    }
    #endregion
    #region Button
    public void OvenCall()
    {
        FaceWhere();
        call();
        wriningLight.GetComponent<MeshRenderer>().material.color = Color.blue;
        navMeshAgent.destination = PosTraget[2].transform.position;
    }
    public void RefrigeratorCall()
    {
        FaceWhere();
        call();
        wriningLight.GetComponent<MeshRenderer>().material.color = Color.blue;
        navMeshAgent.destination = PosTraget[1].transform.position;
    }
    public void DishWasherCall()
    {
        FaceWhere();
        call();
        wriningLight.GetComponent<MeshRenderer>().material.color = Color.blue;
        navMeshAgent.destination = PosTraget[0].transform.position;
        if (navMeshAgent.remainingDistance < .5f)
        {
            print("哈囉哈囉哈囉");
        }
    }

    public void Illustrate()
    {
        FaceWhere();
        ani.SetBool("Idle", false);
        ani.SetBool("Talk", true);
    }
    public void StopIllustrate()
    {
        FaceWhere();
        InvokeRepeating("FaceWhere", .01f, .01f);
        ani.SetBool("Idle", true);
        ani.SetBool("Talk", false);
    }
    #endregion
}


