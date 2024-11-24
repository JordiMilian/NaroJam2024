using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plant : MonoBehaviour
{
    float harvestTime = 10;
    int seedsPerHarvest = 10;

    [SerializeField] float harvestTimeUpgrade0 = 10;
    [SerializeField] int seedsPerHarvestUpgrade0 = 10;

    [SerializeField] float harvestTimeUpgrade1 = 5;
    [SerializeField] int seedsPerHarvestUpgrade1 = 20;

    [SerializeField] float harvestTimeUpgrade2 = 5;
    [SerializeField] int seedsPerHarvestUpgrade2 = 30;

    [SerializeField] GameObject harvestUI;
    [SerializeField] TextMeshPro seedText;
    [SerializeField] Animation animation;
    public SpriteRenderer plantRenderer;
    [SerializeField] GameObject harvestIndicator;

    public bool canHarvest = false;
    private void Awake()
    {
        harvestUI.SetActive(false);
        harvestIndicator.SetActive(false);
    }
    private void Start()
    {
        canHarvest = false;

        harvestTime = harvestTimeUpgrade0;
        seedsPerHarvest = seedsPerHarvestUpgrade0;

        StartCoroutine(WaitForHarvest());
    }

    public void DoHarvest()
    {
        if (canHarvest == false) return;

        harvestIndicator.SetActive(false);
        Debug.Log("Harvesting plant");
        seedText.text = "+" + seedsPerHarvest.ToString();
        harvestUI.SetActive(true);
        animation.Play();
        GameController.Instance.AddSeed(seedsPerHarvest);

        StartCoroutine(WaitForHarvest());
    }
    IEnumerator WaitForHarvest()
    {
        yield return new WaitForSeconds(harvestTime);
        harvestIndicator.SetActive(true);
        canHarvest = true;
    }

    public void UpgradeHarvest1()
    {
        harvestTime = harvestTimeUpgrade1;
        seedsPerHarvest = seedsPerHarvestUpgrade1;
    }

    public void UpgradeHarvest2()
    {
        harvestTime = harvestTimeUpgrade2;
        seedsPerHarvest = seedsPerHarvestUpgrade2;
    }

}
