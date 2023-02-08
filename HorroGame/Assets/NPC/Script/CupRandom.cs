using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRandom : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    Animation anim_n;
    Animation anim_mouth;
    float random_time = 0.4f;
    int now_anim = 0;
    public GameObject head;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim_n = GetComponent<Animation>();
        anim_mouth = head.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Now playing : " + anim.GetCurrentAnimatorStateInfo(0).IsName("part1"));
        //Debug.Log("Now anim parameter is : " + now_anim);
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("part1") && now_anim != 1){
            StopAnim();
            anim_n["Cup1"].speed = 1.04f;
            // Debug.Log("play cup1 or not?");
            anim_n.Play("Cup1");
            // anim_mouth.Play("DrinkMouth");
            now_anim = 1;
        }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("part2") && now_anim != 2){
            StopAnim();
            RandomTime();
            anim.SetFloat("drinkTime" , random_time);
            anim_n["Cup2"].speed = random_time;
            // anim.AnimatorStateTransition.exitTime = random_time;
            anim_n.Play("Cup2");
            now_anim = 2;
        }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("part3") && now_anim != 3){
            StopAnim();
            anim_n["Cup3"].speed = 1.415f;
            anim_n.Play("Cup3");
            now_anim = 3;
        }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("part4") && now_anim != 4){
            StopAnim();
            RandomTime();
            anim.SetFloat("idleTime" , random_time);
            anim_n["Cup4"].speed = random_time;
            // anim.AnimatorStateTransition.exitTime = random_time;
            anim_n.Play("Cup4");
            now_anim = 4;
        }
    }

    void RandomTime(){
        random_time = Random.Range(0.3f , 0.6f);
    }

    void StopAnim(){
        anim_n["Cup1"].speed = 0f;
        anim_n["Cup2"].speed = 0f;
        anim_n["Cup3"].speed = 0f;
        anim_n["Cup4"].speed = 0f;
    }
}
