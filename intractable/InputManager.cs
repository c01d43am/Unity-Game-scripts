using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Playerinput Playerinput;
    public Playerinput.OnFootActions onFoot;

    private Playermotor motor;
    private PlayerLook look;
    void Awake()
    {
        Playerinput = new Playerinput();
        onFoot = Playerinput.OnFoot;

        motor = GetComponent<Playermotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();


    }
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    public void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    public void OnEnable()
    {
        onFoot.Enable();
    }
    public void OnDisable()
    {
        onFoot.Disable();
    }
}