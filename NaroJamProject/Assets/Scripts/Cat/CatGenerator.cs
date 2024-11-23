using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
    [SerializeField] float catGenerationTime = 5f;
    [SerializeField] List<GameObject> catList = new List<GameObject>();
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
            catGenerationTime *= 0.85f;

            if (catGenerationTime < 0.2f) catGenerationTime = 0.2f;
        }
    }

    void GenerateCat()
    {
        int randomCat = Random.Range(0, catList.Count);
        GameObject cat = catList[randomCat];
        GameObject newCat = Instantiate(cat, spawnPoint.transform.position, Quaternion.identity, transform);
    }
}
