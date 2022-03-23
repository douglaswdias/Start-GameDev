using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    public PlayerItems playerItems;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite hole;
    [SerializeField]
    private Sprite carrot;
    [SerializeField]

    private int amount;
    [SerializeField]
    private bool waterInRange;
    [SerializeField]
    private float waterAmount;
    [SerializeField]
    private float currentWater;

    private int initialAmount;
    private bool dugHole;
    public bool playerInRange;

    public bool WaterInRange { get => waterInRange; set => waterInRange = value; }



    // Start is called before the first frame update
    void Start()
    {
        initialAmount = amount;
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dugHole)
        {
            if (WaterInRange)
            {
                currentWater += 0.05f;
            }

            if (currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E) && Player.Instance.Equip == 0 && playerInRange)
                {
                    spriteRenderer.sprite = hole;
                    playerItems.Carrots++;
                    currentWater = 0;
                }
            }
        }
    }

    void OnHit()
    {
        amount--;

        if(amount <= initialAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }
        if (collision.CompareTag("Water"))
        {
            waterInRange = true;
        }
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            waterInRange = false;
        }
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

