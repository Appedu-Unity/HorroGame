using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    //public Animation anim;
    public Transform a;

    private void Start()
    {
        agent.SetDestination(a.transform.position);
    }

    private void Update()
    {
        // 檢查 NPC 是否到達目標位置
        if (agent.remainingDistance < .5f)
        {
            // 如果到達目標位置，調用 NPC 的動作
            print("開始");
        }
    }
}
