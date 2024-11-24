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

    private bool canHarvest = false;
    private void Awake()
    {
        harvestUI.SetActive(false);
    }
    private void Start()
    {
        canHarvest = false;
        StartCoroutine(WaitForHarvest());

        harvestTime = harvestTimeUpgrade0;
        seedsPerHarvest = seedsPerHarvestUpgrade0;
    }

    public void DoHarvest()
    {
        if (canHarvest == false) return;

        seedText.text = "+" + seedsPerHarvest.ToString();
        harvestUI.SetActive(true);
        animation.Play();
        GameController.Instance.AddSeed(seedsPerHarvest);
    }
    IEnumerator WaitForHarvest()
    {
        yield return new WaitForSeconds(harvestTime);
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
