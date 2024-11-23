using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedFarm : MonoBehaviour
{
    [SerializeField] int plantsCount = 0;
    [SerializeField] int maxPlants = 8;
    [SerializeField] int plantCost = 10;
    [SerializeField] float plantCostUpdaterFactor = 1.5f;
    [SerializeField] float plantCostTextOffset = -0.373f;
    [SerializeField] GameObject plantCostObject;
    [SerializeField] TextMeshPro plantCostText;

    [SerializeField] GameObject plantObject;

    [SerializeField] List<GameObject> plantSlots = new List<GameObject>();

    private void Awake()
    {
        CreatePlant();
        plantCostText.text = plantCost.ToString();
    }

    public void AddPlant(int num = 1)
    {
        if (plantsCount == maxPlants) return;

        if (GameController.Instance.RemoveSeed(num * plantCost))
        {
            CreatePlant();
            UpdateCost();
        }
        else Debug.Log("Not enough seeds for the plant");
    }

    void CreatePlant()
    {
        GameObject newPlant = Instantiate(plantObject, plantSlots[plantsCount].transform.position, Quaternion.identity, plantSlots[plantsCount].transform);
        newPlant.name = "Plant";
        plantsCount++;

        if (plantsCount < maxPlants)
        {
            plantCostObject.transform.position = plantSlots[plantsCount].transform.position;
            plantCostObject.transform.position += Vector3.up * plantCostTextOffset;
        }
        else Destroy(plantCostObject);
    }
    void UpdateCost()
    {
        plantCost = (int)(plantCost * plantCostUpdaterFactor);
        plantCostText.text = plantCost.ToString();
    }
}
