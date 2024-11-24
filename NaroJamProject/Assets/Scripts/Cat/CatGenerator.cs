using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
    [SerializeField] float catGenerationTime = 5f;
    [SerializeField] float catFirstGenerationTime = 10f;
    [SerializeField] List<GameObject> catList = new List<GameObject>();
    [SerializeField] GameObject spawnPoint;
    public Action OnFirstCatSpawned;

    private void Start()
    {
        StartCoroutine(FirstStart());
    }

    IEnumerator FirstStart()
    {
        yield return new WaitForSeconds(catFirstGenerationTime);
        StartCoroutine(CatGeneratorCoroutine());
    }
    IEnumerator CatGeneratorCoroutine()
    {
        OnFirstCatSpawned?.Invoke();
        while(true)
        {
            yield return new WaitForSeconds(catGenerationTime);

            GenerateCat();
            catGenerationTime *= 0.95f;

            if (catGenerationTime < 0.5f) catGenerationTime = 0.2f;
        }
    }

    void GenerateCat()
    {
        int randomCat = UnityEngine.Random.Range(0, catList.Count);
        GameObject cat = catList[randomCat];
        GameObject newCat = Instantiate(cat, spawnPoint.transform.position, Quaternion.identity, transform);
    }
}
