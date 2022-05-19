using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool IsGrounded;
    public float Speed = 60;
    public float BoostSpeed = 100;
    public float JumpSpeed = 60;
    public float JumpPower = 170;
    Rigidbody _RB;

    public void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;
    }

    void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float v = Input.GetAxis("Vertical") * BoostSpeed * Time.fixedDeltaTime;
            float h = Input.GetAxis("Horizontal") * BoostSpeed * Time.fixedDeltaTime;
            _RB.velocity = transform.TransformDirection(h, _RB.velocity.y, v);
        }
        else
        {
            float v = Input.GetAxis("Vertical") * Speed * Time.fixedDeltaTime;
            float h = Input.GetAxis("Horizontal") * Speed * Time.fixedDeltaTime;
            _RB.velocity = transform.TransformDirection(h, _RB.velocity.y, v);
        }
    }

    void Jump()
    {
        if (IsGrounded == true)
        {
            float j = Input.GetAxis("Jump") * JumpSpeed * Time.fixedDeltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _RB.velocity = new Vector3(0, j, 0) * JumpPower * Time.fixedDeltaTime;
                IsGrounded = false;
            }
        }
    }
}
