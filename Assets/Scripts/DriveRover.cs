using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveRover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rover;
    [SerializeField] private float _speedRover = 1;
    [SerializeField] private float _forceMotor = 1;

    private HingeJoint _hJoint;
    private JointMotor _jointMotor;
    private JointSpring _breakSpring;
    private int _directionDrive = -1;
    private float _angleSpeed = 1;

    private void Start()
    {
        _hJoint = GetComponent<HingeJoint>();
        _jointMotor = _hJoint.motor;
        _breakSpring = _hJoint.spring;
    }

    private void Update()
    {
        KeyW_Down();
        KeyS_Down();
        KeyA_Down();
        KeyD_Down();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            _hJoint.useMotor = true;
        if (Input.GetKeyUp(KeyCode.W))
            _hJoint.useMotor = false;
        if (Input.GetKeyUp(KeyCode.S))
            _hJoint.useMotor = false;
        if (Input.GetKeyUp(KeyCode.A))
            _hJoint.useMotor = false;
        if (Input.GetKeyUp(KeyCode.D))
            _hJoint.useMotor = false;
    }

    private void KeyW_Down()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _directionDrive = -1;
            PowerMotor();
        }
    }

    private void KeyS_Down()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _directionDrive = 1;
            PowerMotor();
        }
        if (Input.GetKeyUp(KeyCode.A))
            _directionDrive = -1;
    }

    private void KeyA_Down()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gameObject.tag == "LeftWheels")
                _angleSpeed = 0.1f;
            PowerMotor();
            if (Input.GetKeyUp(KeyCode.A))
                _angleSpeed = 1f;
        }
    }

    private void KeyD_Down()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (gameObject.tag == "RightWheels")
                _angleSpeed = 0.1f;
            PowerMotor();
        }
        if (Input.GetKeyUp(KeyCode.D))
            _angleSpeed = 1f;
    }

    private void PowerMotor()
    {
        _jointMotor.targetVelocity = _speedRover * _rover.mass * _directionDrive * _angleSpeed;
        _jointMotor.force = _rover.mass * _forceMotor;
        _hJoint.motor = _jointMotor;
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //        KeyW_Down();

    //    if (Input.GetKeyUp(KeyCode.W))
    //        KeyUpWS();

    //    if (Input.GetKey(KeyCode.S))
    //        KeyS_Down();

    //    if (Input.GetKeyUp(KeyCode.S))
    //        KeyUpWS();

    //    if (Input.GetKeyDown(KeyCode.A))
    //        KeyA_Down();

    //    if (Input.GetKeyUp(KeyCode.A))
    //        KeyUpAD();

    //    if (Input.GetKeyDown(KeyCode.D))
    //        KeyD_Down();

    //    if (Input.GetKeyUp(KeyCode.D))
    //        KeyUpAD();        
    //}

    //private void KeyW_Down()
    //{
    //    _jointMotor.targetVelocity = _speedRover * _rover.mass * (-1);
    //    _jointMotor.force = _rover.mass * _forceMotor;
    //    _hJoint.motor = _jointMotor;
    //    _hJoint.useMotor = true;
    //}

    //private void KeyS_Down()
    //{
    //    _jointMotor.targetVelocity = _speedRover * _rover.mass;
    //    _jointMotor.force = _rover.mass * _forceMotor;
    //    _hJoint.motor = _jointMotor;
    //    _hJoint.useMotor = true;
    //}

    //private void KeyA_Down()
    //{
    //    if (gameObject.tag == "RightWheels")
    //        _angleSpeed = 1f;
    //    else
    //        _angleSpeed = 0.1f;

    //    _jointMotor.targetVelocity = _speedRover * _rover.mass * (-1) * _angleSpeed;
    //    _jointMotor.force = _rover.mass * _forceMotor;
    //    _hJoint.motor = _jointMotor;
    //    _hJoint.useMotor = true;
    //}

    //private void KeyD_Down()
    //{
    //    if (gameObject.tag == "LeftWheels")
    //        _angleSpeed = 1f;
    //    else
    //        _angleSpeed = 0.1f;

    //    _jointMotor.targetVelocity = _speedRover * _rover.mass * (-1) * _angleSpeed;
    //    _jointMotor.force = _rover.mass * _forceMotor;
    //    _hJoint.motor = _jointMotor;
    //    _hJoint.useMotor = true;
    //}

    //private void KeyUpWS()
    //{  
    //    _hJoint.useMotor = false;
    //}

    //private void KeyUpAD()
    //{
    //    _angleSpeed = 1f;
    //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
    //        _hJoint.useMotor = true;
    //    else
    //        _hJoint.useMotor = false;
    //}
}
