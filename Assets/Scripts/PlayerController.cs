using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
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

        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }


}
