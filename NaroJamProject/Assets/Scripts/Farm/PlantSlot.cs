using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlantSlot : MonoBehaviour
{
    [SerializeField] GameObject plantObject;


    [SerializeField] Plant plant;

    [SerializeField] Sprite plantUpgrade1, plantUpgrade2;

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject buyButton;

    [SerializeField] int plantState = 0;

    [SerializeField] bool enableOnStart = false;
    [SerializeField] PlantSlot nextSlot = null;

    private void Start()
    {
        if(enableOnStart)
        {
            plantState = 1;
            CreatePlant();
            CheckPrice();
            if (nextSlot != null) nextSlot.EnableSlot();
        }
    }
    private void Awake()
    {
        plantState = 0;

        if (enableOnStart == false)
        {
            buyButton.SetActive(false);
        }
    }

    private void OnEnable()
    {
        plantState = 0;
    }
    public void EnableSlot()
    {
        plantState = 0;
        buyButton.SetActive(true);
    }
    public void AddPlant(int num = 1)
    {

        if (plantState == 0)
        {
            if (SeedFarm.Instance.plantsCount == SeedFarm.Instance.maxPlants) return;

            if (GameController.Instance.RemoveSeed(num * SeedFarm.Instance.plantCost))
            {
                SeedFarm.Instance.UpdateBuyPlantCost();
                CreatePlant();

                if (nextSlot != null) nextSlot.EnableSlot();
            }
            else Debug.Log("Not enough seeds for the plant");
        }
        else if(plantState == 1)
        {
            if (GameController.Instance.RemoveSeed(num * SeedFarm.Instance.plantUpgrade1Cost))
            {
                UpgradePlant1();
            }
        }
        else if(plantState == 2)
        {
            if (GameController.Instance.RemoveSeed(num * SeedFarm.Instance.plantUpgrade1Cost))
            {
                UpgradePlant2();
            }
        }
    }

    void CreatePlant()
    {
        plantState = 1;

        GameObject newPlant = Instantiate(plantObject, transform.position, Quaternion.identity, transform);
        plant = newPlant.GetComponent<Plant>();
        newPlant.name = "Plant";

        SeedFarm.Instance.plantsCount++;
    }

    public void CheckPrice()
    {
        if(plantState == 0) priceText.text = SeedFarm.Instance.plantCost.ToString();
        if(plantState == 1) priceText.text = SeedFarm.Instance.plantUpgrade1Cost.ToString();
        if(plantState == 2) priceText.text = SeedFarm.Instance.plantUpgrade2Cost.ToString();
    }

    void UpgradePlant1()
    {
        plantState = 2;

        SeedFarm.Instance.UpdateUpgrade1PlantCost();

        plant.plantRenderer.sprite = plantUpgrade1;
        plant.UpgradeHarvest1();
    }

    void UpgradePlant2()
    {
        plantState = 3;

        SeedFarm.Instance.UpdateUpgrade2PlantCost();

        plant.plantRenderer.sprite = plantUpgrade2;

        buyButton.SetActive(false);
        plant.UpgradeHarvest2();
    }

    public void HarvestPlant()
    {
        if (plant != null) plant.DoHarvest();
    }
}
