using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTime_girl : MonoBehaviour
{
    public GameObject face_object;
    float random_sec;
    Animator animator;
    Animator mouth_control;
    bool _set = false;
    bool _istalk = false;
    int talk_anim = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mouth_control = face_object.GetComponent<Animator>();
        Debug.Log(mouth_control);
        Set_Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("talk") || animator.GetCurrentAnimatorStateInfo(0).IsName("talk2") && !_set){
            Set_Random();
            _istalk = true;
            mouth_control.SetBool("isTalk" , _istalk);
            // mouth_control.Play("MouthOpen_girl");
            _set = true;
        }else if(!(animator.GetCurrentAnimatorStateInfo(0).IsName("talk") || animator.GetCurrentAnimatorStateInfo(0).IsName("talk2"))){
            _set = false;
            _istalk = false;
            mouth_control.SetBool("isTalk" , _istalk);
        }
    }

    void Set_Random(){
        random_sec = Random.Range(1.2f , 1.4f);
        talk_anim = Random.Range(0 , 2);
        animator.SetFloat("IdleTime" , random_sec);
        animator.SetInteger("talk_anim" , talk_anim);
    }
}
