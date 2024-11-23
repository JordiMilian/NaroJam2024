using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] float harvestTime = 5;
    [SerializeField] int seedsPerHarvest = 10;

    [SerializeField] GameObject harvestUI;
    [SerializeField] TextMeshPro seedText;
    [SerializeField] Animation animation;

    private void Awake()
    {
        harvestUI.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(Harvest());
    }

    IEnumerator Harvest()
    {
        while(true)
        {
            yield return new WaitForSeconds(harvestTime);
            seedText.text = "+" + seedsPerHarvest.ToString();
            harvestUI.SetActive(true);
            animation.Play();
            GameController.Instance.AddSeed(seedsPerHarvest);
        }
    }

}
