using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private bool timeRunning = false;
    private float timeFromStart = 0;
    [SerializeField] private int seedBank = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else Destroy(gameObject);
    }

    public float GetTime()
    {
        return timeFromStart;
    }
    public int GetSeedsNumber()
    {
        return seedBank;
    }

    //Devuelve true si puede quitar las pipas del banco, si las pipas que intentas consumir
    //son más que las que quedan en el banco no las resta y devuelve false
    public bool RemoveSeed(int seedNumber)
    {
        if(seedBank == 0)
        {
            return false;
        }
        
        if((seedBank - seedNumber) < 0)
        {
            return false;
        }else
        {
            seedBank -= seedNumber;
            return true;
        }
    }

    public void AddSeed(int seedNumber)
    {
        seedBank += seedNumber;
    }

    private void Update()
    {
        if(timeRunning) timeFromStart += Time.deltaTime;
    }
}
