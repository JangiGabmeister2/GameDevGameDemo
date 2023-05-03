using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConfig : MonoBehaviour
{
    public float animationSpeed = 1;
    [Range(0,1)]
    public float animationStep;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.speed = animationSpeed;
        animator.playbackTime = animationStep;
    }

    public void Play()
    {
        animator.Play(0);
    }
}
