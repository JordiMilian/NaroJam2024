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
        StartCoroutine(UpdateSeedCounter());
    }

    IEnumerator UpdateSeedCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(seedCheckTimer);

            textMeshPro.text = GameController.Instance.GetSeedsNumber().ToString();
        }
    }
}
