using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCounter : MonoBehaviour
{
    TextMeshPro textMeshPro;
    [SerializeField] private float seedCheckTimer = 1f;
    private void Awake()
    {
        if (textMeshPro == null) 
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }
    }

    private void Start()
    {
        textMeshPro.text = GameController.Instance.GetSeedsNumber().ToString();
        StartCoroutine(UpdateSeedCounter());
    }

    IEnumerator UpdateSeedCounter()
    {
        while (true)
        {
            yield return null;

            int seeds = GameController.Instance.GetSeedsNumber();
            int hungry = GameController.Instance.GetHungry();
            textMeshPro.text = seeds.ToString();
        }
    }
}
