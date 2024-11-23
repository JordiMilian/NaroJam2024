using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HamsterWheel : MonoBehaviour
{
    [SerializeField] GameObject hamsterPrefab;

    [SerializeField] int hamsterCost = 10;
    [SerializeField] float hamsterCostUpdaterFactor = 1.5f;

    [SerializeField] List<GameObject> hamsterList = new List<GameObject>();

    [SerializeField] TextMeshProUGUI hamsterCostCounter;
    private void Start()
    {
        CreateHamster();
        UpdateHamsterCostCounter();
    }

    public void AddHamster(int num = 1)
    {
        if (GameController.Instance.RemoveSeed(num * hamsterCost))
        {
            CreateHamster();
            UpdateHamsterCost();
        }
        else Debug.Log("Not enough seeds for the hamster");
    }
    void CreateHamster()
    {
        GameObject newHamster = Instantiate(hamsterPrefab, transform.position, Quaternion.identity, transform);
        hamsterList.Add(newHamster);
    }

    void UpdateHamsterCost()
    {
        hamsterCost = (int)(hamsterCost * hamsterCostUpdaterFactor);
        UpdateHamsterCostCounter();
    }

    void UpdateHamsterCostCounter()
    {
        hamsterCostCounter.text = "Cost: " + hamsterCost.ToString();
    }
}
