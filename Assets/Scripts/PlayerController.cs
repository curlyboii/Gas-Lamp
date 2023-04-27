using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;


    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);

        if(_joystick.Horizontal != 0 || _joystick.Vertical !=0)
        {

            transform.rotation= Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isWalking", true);
            float speed = _rigidbody.velocity.magnitude;

            if (speed > 3)
            {

                _animator.SetBool("isRunning", true);

            }
            else if (speed < 3)
            {
                _animator.SetBool("isRunning", false);
            }

        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        
        
    }


}
