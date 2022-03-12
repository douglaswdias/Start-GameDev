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

    private PlayerItems playerItems;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _IsDigging;
    private bool _IsWatering;

    private int equip;


    public Vector2 direction{get { return _direction; }set { _direction = value; }}

    public bool isRunning{get { return _isRunning; }set { _isRunning = value; }}

    public bool isRolling{get { return _isRolling; }set { _isRolling = value; }}

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _IsDigging; set => _IsDigging = value; }
    public bool IsWatering { get => _IsWatering; set => _IsWatering = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
        playerItems = GetComponent<PlayerItems>();

        initialSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equip = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equip = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equip = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equip = 3;
        }

        OnInput();

        OnRun();

        OnRoll();

        OnCutting();

        OnDigging();

        OnWatering();
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
        if (equip == 1)
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
    }

    void OnDigging()
    {
        if(equip == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsDigging = false;
                speed = initialSpeed;
            }
        } 
    }

    void OnWatering()
    {
        if (equip == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsWatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsWatering= false;
                speed = initialSpeed;
            }

            if (IsWatering && playerItems.CurrentWater > 0)
            {
                playerItems.CurrentWater -= 0.05f;
            }

            if (playerItems.CurrentWater <= 0)
            {
                playerItems.CurrentWater = 0;
            }
        }
    }

    #endregion
}
