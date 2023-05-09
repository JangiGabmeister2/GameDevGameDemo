using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConfig : MonoBehaviour
{
    public float animationSpeed = 1;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.speed = animationSpeed;
    }

    public void Play()
    {        
        animator.Play(0);
    }
}
