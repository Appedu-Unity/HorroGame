using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SystemCustomertwo : MonoBehaviour
{
    [Header("���ʳt��")] public float speed;
    [Header("NPC�׶}��w�]��m")][SerializeField] private Collider[] hitTraget;
    [Header("NPC�ӫ~���Ц�m")][SerializeField] private Collider[] PosTraget;
    //[Header("NPC�Q�I�s��m")][SerializeField]private Collider[] callPosTraget;
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

    private Animator ani;
    private Rigidbody rig;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Transform dishWasher, oven, refrigerator;

    bool stopNPCMove;
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
    // Start is called before the first frame update
    void Start()
    {
        FollowTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// �M��������ݭn����m
    /// </summary>
    void FollowTarget()
    {
        hitTraget = Physics.OverlapSphere(transform.position, 100f, hitTragetLayerMask);
        PosTraget = Physics.OverlapSphere(transform.position, 100f, PosTragetLayerMask);
        //Debug.Log(hitTraget.Length);
    }
}
