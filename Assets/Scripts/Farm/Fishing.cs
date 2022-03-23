using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private bool playerInRange;
    [SerializeField] private int fishChance;

    [SerializeField] private Fish fishPrefab;

    private PlayerItems playerItems;

    public bool PlayerInRange { get => playerInRange; set => playerInRange = value; }

    public static Fishing Instance;

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
        if (PlayerInRange && Player.Instance.Equip == 4 && (Input.GetMouseButtonDown(0)))
        {
            PlayerAnim.Instance.OnFishingBegin();
        }
    }

    public void OnFishing()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= fishChance)
        {
            Instantiate(fishPrefab, playerItems.transform.position + new Vector3(Random.Range(-2, 2), 1f, 0f), Quaternion.identity);
        }
        else
        {
            Debug.Log("You Didn`t Got it");
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
