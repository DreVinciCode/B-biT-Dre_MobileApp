using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour
{
    private Animator animator;
   
    void Awake()
    {
        animator = GetComponent<Animator>();   
    }
    
    public void Flying()
    {
        animator.SetFloat("speed", 1.0f);
    }

    public void Idle()
    {
        animator.SetFloat("speed", 0.0f);
    }

    public void Lean()
    {
        animator.SetFloat("speed", 0.5f);
    }
}
