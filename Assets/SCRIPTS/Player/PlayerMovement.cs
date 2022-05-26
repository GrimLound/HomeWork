using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool IsGrounded;
    public float Speed = 60;
    public float BoostSpeed = 100;
    public float JumpSpeed = 60;
    public float JumpPower = 250;
    Rigidbody _RB;

    public void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        WalkSound();
        Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;       
    }

    void WalkSound()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OnPlayerSteps();
        }
        else if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OffPlayerSteps();
        }
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OnPlayerSteps();
        }
        else if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OffPlayerSteps();
        }
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OnPlayerSteps();
        }
        else if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<SoundsEffects>().OffPlayerSteps();
        }
        if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            GetComponent<SoundsEffects>().OnPlayerSteps();
        }
        else if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            GetComponent<SoundsEffects>().OffPlayerSteps();
        }
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
