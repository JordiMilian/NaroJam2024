using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject seed;
    [SerializeField] GameObject shootPoint;

    public static Cannon Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void Shoot()
    {
        if(GameController.Instance.RemoveSeed(1)) Instantiate(seed, shootPoint.transform.position, Quaternion.identity, transform);
    }
}
