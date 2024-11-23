using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCounter : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    [SerializeField] private float seedCheckTimer = 1f;
    private void Awake()
    {
        if (textMeshPro == null) 
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
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
            yield return new WaitForSeconds(seedCheckTimer);

            int seeds = GameController.Instance.GetSeedsNumber();
            int hungry = GameController.Instance.GetHungry();
            textMeshPro.text = seeds.ToString();
        }
    }
}
