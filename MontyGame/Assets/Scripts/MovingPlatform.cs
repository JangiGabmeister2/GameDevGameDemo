using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] protected Vector3 _startPosition; //the start position of the moving platform
    [SerializeField] protected Vector3 _endPosition; //the end position
    [Range(0f, 1f)]
    [SerializeField] protected float _t; //point between the start and end positions
    [SerializeField] protected AnimationCurve _moveCurve;
    [SerializeField] protected float _speed = 1f; //speed at which the platform moves
    [SerializeField] protected float cooldown = 3f; //the platform pauses before moving to next point
    [SerializeField] protected bool _pingPong = true; //whether the platform would move back and forth, or just move and stop
    [SerializeField] protected bool _auto = true; //whether the platform moves automatically
    protected float _cooldown;

    protected bool _forward; //the bool if the platform is forward (start to end), then back (end to start)

    private void Update()
    {
        if (_auto)
        {
            MovePlatform();
        }
    }

    protected virtual Vector3 NextMove(float t)
    {
        return Vector3.Lerp(_startPosition, _endPosition, _moveCurve.Evaluate(t)); //moves the platform from start to end at an interpolated value
    }

    public void MovePlatform()
    {
        _cooldown -= Time.deltaTime; //cooldown goes down 1 every second
        if (_cooldown > 0) //if cooldown is greater than 0
        {
            return; //returns to if statement until false
        }

        if (_forward) //if moving forward
        {
            _t += _speed * Time.deltaTime; //increases point by speed per second
            _t = Mathf.Min(1, _t); //returns the smallest value between point and 1
            if (_t >= 1) //if point is not less than 1
            {
                if (_pingPong)
                {
                    _forward = false; //bool is set to false, therefore going backwards
                }
                _cooldown = cooldown; //cooldown resets
            }
        }
        else //if going backward
        {
            _t -= _speed * Time.deltaTime; //same as above
            _t = Mathf.Max(0, _t);
            if (_t <= 0)
            {
                _forward = true;
                _cooldown = cooldown;
            }
        }

        transform.position = NextMove(_t); //sets the next point to move towards
    }
}