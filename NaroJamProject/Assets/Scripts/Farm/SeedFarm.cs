using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedFarm : MonoBehaviour
{
    public int plantsCount = 0;
    public int maxPlants { get; private set; } = 8;
    public int plantCost = 10;
    public int plantUpgrade1Cost = 20;
    public int plantUpgrade2Cost = 50;

    [SerializeField] float plantCostUpdaterFactor = 1.5f;
    [SerializeField] float plantCostTextOffset = -0.373f;

    [SerializeField] GameObject plantObject;

    [SerializeField] List<PlantSlot> plantSlots = new List<PlantSlot>();

    public static SeedFarm Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        StartCoroutine(UpdatePrices());
    }
    public void UpdateBuyPlantCost()
    {
        plantCost = (int)(plantCost * plantCostUpdaterFactor);
        StartCoroutine(UpdatePrices());
    }

    public void UpdateUpgrade1PlantCost()
    {
        plantUpgrade1Cost = (int)(plantUpgrade1Cost * plantCostUpdaterFactor);
        StartCoroutine(UpdatePrices());
    }

    public void UpdateUpgrade2PlantCost()
    {
        plantUpgrade2Cost = (int)(plantUpgrade2Cost * plantCostUpdaterFactor);
        StartCoroutine(UpdatePrices());
    }

    IEnumerator UpdatePrices()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < plantSlots.Count; i++)
        {
            plantSlots[i].CheckPrice();
        }
    }
}
