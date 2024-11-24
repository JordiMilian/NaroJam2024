using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private bool timeRunning = false;
    private float timeFromStart = 0;
    [SerializeField] private int seedBank = 0;
    [SerializeField] int hamstersHungry;
    [SerializeField] float timeForSeedConsume = 5;
    [SerializeField] int initialSeeds = 25;

    [SerializeField] Transform resetTutorialRoot;
    public int numHamsters { get; private set; }

    public void AddHamster()
    {
        numHamsters++;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else Destroy(gameObject);

        seedBank = initialSeeds;
        hamstersHungry = 0;

        numHamsters = 1;
        if(resetTutorialRoot != null) { resetTutorialRoot.gameObject.SetActive(false); }
    }

    private void Start()
    {
        //StartCoroutine(ConsumeSeedRoutine());
    }

    public int GetHungry()
    {
        return hamstersHungry;
    }
    public float GetTime()
    {
        return timeFromStart;
    }
    public int GetSeedsNumber()
    {
        return seedBank;
    }

    public void RemoveSeedConsumition(int seedNum)
    {
        hamstersHungry -= seedNum;
        if (hamstersHungry < 0) hamstersHungry = 0;
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

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void showResetTutorial()
    {
        if(resetTutorialRoot != null)
        {
            seedBank = 0;
            MusicPlayer.Instance.PlayDeathMusic();
            resetTutorialRoot.gameObject.SetActive(true);
        }
    }
}
