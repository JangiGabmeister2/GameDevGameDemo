using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanToggle : MonoBehaviour
{
    Animator _fanAnimator;
    public bool toggle = true;
    public bool reverse = false;
    [Range(1, 5)]
    public int speed = 1;

    private void Awake()
    {
        _fanAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _fanAnimator.SetBool("isOn", toggle);

        _fanAnimator.SetBool("isReversed", reverse);

        _fanAnimator.speed = speed;
    }

    public void ToggleMotion(bool toggle)
    {
        this.toggle = toggle;
    }

    public void ToggleDirection(bool toggle)
    {
        reverse = toggle;
    }

    public void ChangeSpeed(int speed)
    {
        this.speed = speed;
    }
}
