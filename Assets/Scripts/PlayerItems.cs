using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems Instance;

    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int carrots;
    [SerializeField] private int fishes;

    private float waterLimite = 50;
    private float woodLimite = 20;
    private float carrotLimite = 10;
    private float fishLimite = 5;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float TotalWater { get => CurrentWater; set => CurrentWater = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }
    public int Carrots { get => carrots; set => carrots = value; }
    public int Fishes { get => fishes; set => fishes = value; }
    public float WoodLimite { get => woodLimite; set => woodLimite = value; }
    public float CarrotLimite { get => carrotLimite; set => carrotLimite = value; }
    public float WaterLimite { get => waterLimite; set => waterLimite = value; }
    public float FishLimite { get => fishLimite; set => fishLimite = value; }


    private void Awake()
    {
        Instance = this;
    }

    public void WaterLimit(int water)
    {
        if (CurrentWater < WaterLimite)
        {
            CurrentWater += water;
        }
    }

    public void WoodLimit()
    {

    }
}
