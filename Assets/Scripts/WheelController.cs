using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    private float dir = 0f;
    private HandIK handIK;
    Rigidbody rb;


    [SerializeField] private float motorForce, breakForce, maxSteerAngle;


    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;
    [SerializeField] private Transform wheel;
    [SerializeField] private float wheelSpeed;
    [SerializeField] private float smoothHand =8f;
    [SerializeField] private float smoothRotation;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handIK = GameObject.FindWithTag("Player").GetComponent<HandIK>();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState == State.NOTMOVE) return;
        GetInput();
        HandleMotor();
        HandleSteering();
        WheelRotation();
        HandMotion();
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;
        //Debug.Log(rb.velocity.magnitude);
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = Mathf.Lerp(currentSteerAngle,(maxSteerAngle * horizontalInput),Time.deltaTime * smoothRotation);
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void WheelRotation()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            return;
        }
        
        if (rearLeftWheelCollider.motorTorque > 0.0f)
        {
            dir = 1f;
        }
        else if(rearLeftWheelCollider.motorTorque < 0.0f)
        {
            dir = -1f;
        }
        wheel.Rotate(new Vector3(0,0,wheelSpeed * dir * Time.deltaTime));
        
    }

    private void HandMotion()
    {
        
        if (Mathf.Abs(verticalInput) <= Mathf.Epsilon && Mathf.Abs(horizontalInput) <= Mathf.Epsilon)
        {
            handIK.dampWeight = Mathf.Lerp(handIK.dampWeight, 0.0f, Time.deltaTime * smoothHand);
        }
        else
        {
            handIK.dampWeight = Mathf.Lerp(handIK.dampWeight, 1.0f,  Time.deltaTime * smoothHand);
        }
        
    }
}
