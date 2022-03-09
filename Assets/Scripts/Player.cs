using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 _direction;

    public float speed;
    public float runSpeed;
    private float initialSpeed;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;


    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting 
    { 
        get => _isCutting; 
        set => _isCutting = value; 
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();

        OnRun();

        OnRoll();

        OnCutting();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Moviment

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
            speed = runSpeed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
            speed = initialSpeed;
        }
    }

    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsCutting = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsCutting = false;
            speed = initialSpeed;
        }
    }

    #endregion
}
