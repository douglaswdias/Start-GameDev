using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private bool playerInRange;
    [SerializeField]
    private int waterValue;

    private PlayerItems playerItems;

    public bool PlayerInRange { get => playerInRange; set => playerInRange = value; }

    public static Water Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Player.Instance.Equip == 3 && Input.GetKeyDown(KeyCode.E))
        {
            playerItems.WaterLimit(waterValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInRange = false;
    }
}
