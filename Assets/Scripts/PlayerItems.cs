using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField]
    private int totalWood;
    [SerializeField]
    private float currentWater;
    private float waterLimite = 50;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float TotalWater { get => CurrentWater; set => CurrentWater = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }

    public void WaterLimit(int water)
    {
        if (CurrentWater < waterLimite)
        {
            CurrentWater += water;
        }
    }

    public void WoodLimit()
    {

    }
}
