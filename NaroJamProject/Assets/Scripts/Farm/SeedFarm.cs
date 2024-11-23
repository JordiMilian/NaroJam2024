using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedFarm : MonoBehaviour
{
    [SerializeField] int plantsCount = 0;
    [SerializeField] int plantCost = 10;
    [SerializeField] float plantCostUpdaterFactor = 1.5f;
    [SerializeField] TextMeshProUGUI plantCostCounter;
    [SerializeField] TextMeshProUGUI plantCountCounter;

    private void Start()
    {
        CreatePlant();
        UpdatePlantCounter();
        UpdateCostCounter();
    }

    public void AddPlant(int num = 1)
    {
        if (GameController.Instance.RemoveSeed(num * plantCost))
        {
            CreatePlant();
            UpdateCost();
        }
        else Debug.Log("Not enough seeds for the plant");
    }

    void CreatePlant()
    {
        GameObject newPlant = new GameObject();
        newPlant.name = "Plant";
        newPlant.transform.parent = transform;
        newPlant.AddComponent<Plant>();

        plantsCount++;
        UpdatePlantCounter();
    }
    void UpdateCost()
    {
        plantCost = (int)(plantCost * plantCostUpdaterFactor);
        UpdateCostCounter();
    }
    void UpdateCostCounter()
    {
        plantCostCounter.text = "Cost: " + plantCost.ToString();
    }
    void UpdatePlantCounter()
    {
        plantCountCounter.text = "Plant number: " + plantsCount.ToString();
    }
}
