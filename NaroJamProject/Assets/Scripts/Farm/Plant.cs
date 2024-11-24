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
    public SpriteRenderer plantRenderer;
    [SerializeField] Animation harvestUIAnimation;
    [SerializeField] AudioClip appearSFX, harvestableSFX, harvestedSFX, upgradedSFX;
   // [SerializeField] GameObject harvestIndicator;

    public bool canHarvest = false;
    Animator plantAnimator;
    private void Awake()
    {
        harvestUI.SetActive(false);
        plantAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        canHarvest = false;

        harvestTime = harvestTimeUpgrade0;
        seedsPerHarvest = seedsPerHarvestUpgrade0;
        plantAnimator.SetTrigger("appear");
        SFX_PlayerSingleton.Instance.playSFX(appearSFX);
        StartCoroutine(WaitForHarvest());
    }

    public void DoHarvest()
    {
        if (canHarvest == false) return;

        canHarvest = false;
        plantAnimator.SetBool("harvestable", false);
        SFX_PlayerSingleton.Instance.playSFX(harvestedSFX,0.1f);
        Debug.Log("Harvesting plant");
        seedText.text = "+" + seedsPerHarvest.ToString();
        harvestUI.SetActive(true);
        harvestUIAnimation.Play();
        GameController.Instance.AddSeed(seedsPerHarvest);

        StartCoroutine(WaitForHarvest());
    }
    IEnumerator WaitForHarvest()
    {
        yield return new WaitForSeconds(harvestTime);
        plantAnimator.SetBool("harvestable", true);
        SFX_PlayerSingleton.Instance.playSFX(harvestableSFX,0.1f);
        canHarvest = true;
    }

    public void UpgradeHarvest1()
    {
        harvestTime = harvestTimeUpgrade1;
        seedsPerHarvest = seedsPerHarvestUpgrade1;
        plantAnimator.SetTrigger("upgraded");
        SFX_PlayerSingleton.Instance.playSFX(upgradedSFX);
    }

    public void UpgradeHarvest2()
    {
        harvestTime = harvestTimeUpgrade2;
        seedsPerHarvest = seedsPerHarvestUpgrade2;
        plantAnimator.SetTrigger("upgraded");
        SFX_PlayerSingleton.Instance.playSFX(upgradedSFX);
    }

}
