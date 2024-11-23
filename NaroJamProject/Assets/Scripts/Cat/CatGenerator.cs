using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
    [SerializeField] float catGenerationTime = 5f;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject spawnPoint;

    private void Start()
    {
        StartCoroutine(CatGeneratorCoroutine());
    }

    IEnumerator CatGeneratorCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(catGenerationTime);

            GenerateCat();
        }
    }

    void GenerateCat()
    {
        GameObject newCat = Instantiate(cat, spawnPoint.transform.position, Quaternion.identity, transform);
    }
}
