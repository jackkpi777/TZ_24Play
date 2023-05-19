using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Rigidbody[] hips;
    bool died;
    public static PlayerAnimController instance;
    public static UnityEvent DeathEventForward = new UnityEvent();
    public static UnityEvent DeathEventBackward = new UnityEvent();


    void Start()
    {
        StackContainer.SuccessEvent.AddListener(MakeJump);
        StackContainer.FailedEvent.AddListener(MakeStartFall);
        DeathEventForward.AddListener(()=>MakeIsKinematic(false));
        DeathEventForward.AddListener(()=> Dead(true));

        DeathEventBackward.AddListener(() => MakeIsKinematic(false));
        DeathEventBackward.AddListener(() => Dead(false));
        MakeIsKinematic(true);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeIsKinematic(bool _swicth)
    {
        for (int i = 0; i < hips.Length; i++)
        {
            hips[i].isKinematic = _swicth;
        }
    }
    public void MakeState(int _index) 
    {
        anim.SetInteger("state", _index);
    }
    public void MakeJump()
    {
        anim.SetTrigger("jump");
    }
    public void MakeStartFall()
    {
        anim.SetTrigger("fall");

    }
    void AnimatorOff() 
    {
        anim.enabled = false;
        for (int i = 0; i < hips.Length; i++)
        {
            hips[i].AddForce(new Vector3(0, 200, -600));
        }
    }
    void Dead(bool backForward)
    {
        if (died ==false) 
        {
            Debug.Log("deadEvent");
            if (backForward)
            {
                anim.SetTrigger("deathForward");
                Invoke("AnimatorOff", 2);
            }
            else
            {
                anim.SetTrigger("deathBack");
                Invoke("AnimatorOff", .45f);
            }
            StackContainer.stat = 0;
            died = true;
        }
       
    }
}
