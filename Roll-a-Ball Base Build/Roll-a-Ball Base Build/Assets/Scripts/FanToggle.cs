using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanToggle : MonoBehaviour
{
    Animator _fanAnimator;
    public bool toggle;
    public bool reverse;

    private void Awake()
    {
        _fanAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _fanAnimator.SetBool("isOn", toggle);

        _fanAnimator.SetBool("isReversed", reverse);
    }

    public void ToggleMotion(bool toggle)
    {
        this.toggle = toggle;
    }

    public void ToggleDirection(bool toggle)
    {
        reverse = toggle;
    }
}
