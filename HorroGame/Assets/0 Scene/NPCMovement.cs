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
        // �ˬd NPC �O�_��F�ؼЦ�m
        if (agent.remainingDistance < .5f)
        {
            // �p�G��F�ؼЦ�m�A�ե� NPC ���ʧ@
            print("�}�l");
        }
    }
}
