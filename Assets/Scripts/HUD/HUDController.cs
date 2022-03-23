using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    //[SerializeField]
    //private Image handUIBar;
    //[SerializeField]
    //private Image axeUIBar;
    //[SerializeField]
    //private Image shovelUIBar;
    //[SerializeField]
    //private Image waterToolUIBar;

    public List<Image> uiTools = new List<Image>();

    [SerializeField] private Color normalColor; 
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;


    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.CurrentWater / playerItems.WaterLimite;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.WoodLimite;
        carrotUIBar.fillAmount = playerItems.Carrots / playerItems.CarrotLimite;
        fishUIBar.fillAmount = playerItems.Fishes / playerItems.FishLimite;

        //uiTools[Player.Instance.Equip].color = normalColor;

        for (int i = 0; i < uiTools.Count; i++)
        {
            if(i == Player.Instance.Equip)
            {
                uiTools[i].color = normalColor;
            }
            else
            {
                uiTools[i].color = alphaColor;
            }
        }
    }
}
