using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//public enum NpcState { Idle, Run, Talk }
public class SystemCustomertwo : MonoBehaviour
{
    [SerializeField]  public ＣommodityTransformPos commodityTransformPos;
    [Header("NPC移動速度")] public float speed;
    [Header("NPC避開後預設位置")][SerializeField] private Collider[] hitTraget;
    [Header("NPC商品介紹位置")] public Collider[] PosTraget;
    //[Header("NPC被呼叫位置")][SerializeField]private Collider[] callPosTraget;
    public LayerMask hitTragetLayerMask;
    public LayerMask PosTragetLayerMask;
    //public LayerMask callNpcLayerMask;
    public GameObject calllight, wriningLight;
    //public GameObject NPCTrageObj, NPCTragePos;
    public Transform TragePos;
    [SerializeField] int posID = 0;
    [SerializeField] float rangeDodge = 10f;
    [SerializeField] float rangeCommentary = 5f;
    [SerializeField] float dishWasherRange = 10f;
    [SerializeField] float ovenRange = 10f;
    [SerializeField] float refrigeratorRange = 10f;
    [SerializeField] float rangeStopNPC = 1.8f;
    [SerializeField] float posRange;
    [SerializeField] float minValue;



    private Animator ani;
    private Rigidbody rig;
    private NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    private Transform dishWasher, oven, refrigerator;

    bool stopNPCMove;

    public NpcState npcStateing;

    private void Awake()
    {
        //commodityTransformPos.ＣommodityPos = null;
        npcStateing = NpcState.Run;
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
    // Start is called before the first frame update
    void Start()
    {
        stopNPCMove = false;
        FollowTarget();
        navMeshAgent.destination = hitTraget[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (npcStateing)
        {
            case NpcState.Idle:
                ani.SetBool("Idle", true);
                break;
            case NpcState.Run:
                ani.SetBool("Idle", false);
                ani.SetBool("Talk", false);
                break;
            case NpcState.Talk:
                ani.SetBool("Talk", true);
                ani.SetBool("Idle", true);
                break;
        }
        GetPosRange();
        
            

    }

    void GetPosRange()
    {
        float stop = navMeshAgent.stoppingDistance + 1;
            posRange = Vector3.Distance(this.transform.position, navMeshAgent.destination);
        if (posRange <= stop)
        {

            navMeshAgent.enabled = false;
            npcStateing = NpcState.Idle;
        }

    }

    /// <summary>
    /// 尋找場景中需要的位置
    /// </summary>
    void FollowTarget()
    {
        hitTraget = Physics.OverlapSphere
            (transform.position, 100f, hitTragetLayerMask);
        PosTraget = Physics.OverlapSphere
            (transform.position, 100f, PosTragetLayerMask);
        //foreach (var item in PosTraget)
        //{
 

        //float commodityPosRange = Vector3.Distance(this.transform.position, commodityTransformPos.ＣommodityPos[0].transform.position);
        //float commodityPosRange1 = Vector3.Distance(this.transform.position, commodityTransformPos.ＣommodityPos[1].transform.position);
        //float commodityPosRange2 = Vector3.Distance(this.transform.position, commodityTransformPos.ＣommodityPos[2].transform.position);


        //commodityTransformPos.transform.position = GetClosestPoint();

        //commodityTransformPos.ＣommodityPos=PosTraget;

        //Debug.Log(hitTraget.Length);
    }

    public Vector3 GetClosestPoint()
    {
        float commodityPosRange = Vector3.Distance
            (this.transform.position, PosTraget[0].transform.position);
        float commodityPosRange1 = Vector3.Distance
            (this.transform.position, PosTraget[1].transform.position);
        float commodityPosRange2 = Vector3.Distance
            (this.transform.position, PosTraget[2].transform.position);

        if (commodityPosRange < commodityPosRange1
            && commodityPosRange < commodityPosRange2)
        {
            return PosTraget[0].transform.position;
        }
        else if (commodityPosRange1 < commodityPosRange
            && commodityPosRange1 < commodityPosRange2)
        {
            return PosTraget[1].transform.position;
        }
        else
        {
            return PosTraget[2].transform.position;
        }
    }
    void CallNPCPos()
    {
        navMeshAgent.destination = commodityTransformPos.transform;
    }
    public void CallNPC()
    {
        navMeshAgent.enabled = true;
        npcStateing = NpcState.Run;

        navMeshAgent.destination = player.transform.position;
    }
}

