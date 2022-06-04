using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public static House Instance;
    private PlayerAnim playerAnim;

    [SerializeField] private int woodAmount;

    [SerializeField] private float buildingTime;
    [SerializeField] private bool isBuilding;
    [SerializeField] private GameObject houseCollider;
    private float buildingCount;

    [SerializeField]private SpriteRenderer houseSprite;
    [SerializeField]private bool playerInRange;
    [SerializeField]private Color normalColor;
    [SerializeField]private Color alphaColor;
    [SerializeField]private Transform buildingSpot;


    public bool PlayerInRange { get => playerInRange; set => playerInRange = value; }
    public SpriteRenderer HouseSprite { get => houseSprite; set => houseSprite = value; }
    public Color NormalColor { get => normalColor; set => normalColor = value; }
    public Color AlphaColor { get => alphaColor; set => alphaColor = value; }
    public bool IsBuilding { get => isBuilding; set => isBuilding = value; }
    public int WoodAmount { get => woodAmount; set => woodAmount = value; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = Player.Instance.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Player.Instance.Equip == 0 && PlayerItems.Instance.TotalWood >= WoodAmount && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnBuildingBegin();
            Player.Instance.transform.position = buildingSpot.position;
            Player.Instance.transform.rotation = new Quaternion(0, 0, 0,0);
            HouseSprite.color = AlphaColor;
            IsBuilding = true;
        }

        if (IsBuilding)
        {
            buildingCount += Time.deltaTime;
            if(buildingCount >= buildingTime)
            {
                playerAnim.OnBuildingEnd();
                HouseSprite.color = NormalColor;
                PlayerItems.Instance.TotalWood -= WoodAmount;
                IsBuilding = false;
                houseCollider.SetActive(true);
            }
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
