using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite hole;
    [SerializeField]
    private Sprite carrot;
    [SerializeField]
    private int amount;

    private int initialAmount;



    // Start is called before the first frame update
    void Start()
    {
        initialAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit()
    {
        amount--;

        if(amount <= initialAmount / 2)
        {
            spriteRenderer.sprite = hole;

        }

        //if(amount <= 0)
        //{
        //    spriteRenderer.sprite = carrot;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }
    }
}
