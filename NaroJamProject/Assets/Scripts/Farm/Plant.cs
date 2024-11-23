using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] float harvestTime = 5;
    [SerializeField] int seedsPerHarvest = 10;

    private void Start()
    {
        StartCoroutine(Harvest());
    }

    IEnumerator Harvest()
    {
        while(true)
        {
            yield return new WaitForSeconds(harvestTime);

            GameController.Instance.AddSeed(seedsPerHarvest);
        }
    }
}
