using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    private Rigidbody2D rig;
    private Vector2 _direction;

    public float speed;
    public float runSpeed;
    private float initialSpeed;

    private PlayerItems playerItems;
    //private Player player;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _IsDigging;
    private bool _IsWatering;
    private bool _IsGettingWater;
    private bool _IsFishing;

    private int equip;


    public Vector2 direction{get => _direction; set => _direction = value; }
    public bool isRunning{get => _isRunning; set => _isRunning = value; }
    public bool isRolling{get => _isRolling; set => _isRolling = value; }
    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _IsDigging; set => _IsDigging = value; }
    public bool IsWatering { get => _IsWatering; set => _IsWatering = value; }
    public bool IsGettingWater { get => _IsGettingWater; set => _IsGettingWater = value; }
    public int Equip { get => equip; set => equip = value; }
    public bool IsFishing { get => _IsFishing; set => _IsFishing = value; }

    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
        playerItems = GetComponent<PlayerItems>();
        //player = GetComponent<Player>();
        Equip = 0;

        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Equip = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Equip = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Equip = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Equip = 3;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Equip = 4;
            }

            OnInput();

            OnRun();

            OnRoll();

            OnCutting();

            OnDigging();

            OnWatering();

            OnFishing();
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
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
        if (Equip == 1)
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
        if(Equip == 2)
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
        if (Equip == 3)
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

            if (Water.Instance.PlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                IsGettingWater = true;
            }

            if (Water.Instance.PlayerInRange && Input.GetKeyUp(KeyCode.E))
            {
                IsGettingWater = false;
            }
        }
    }

    void OnFishing()
    {
        if (Equip == 4 && Fishing.Instance.PlayerInRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsFishing = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsFishing = false;
                speed = initialSpeed;
            }
        }
    }

    #endregion
}
