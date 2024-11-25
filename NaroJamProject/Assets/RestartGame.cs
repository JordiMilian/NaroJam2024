using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class RestartGame : MonoBehaviour
{

    [SerializeField] int minTextSize, maxTextSize;
    [SerializeField] float speed;

    // The text object we're trying to manipulate
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] Button button;
    private bool growing = false;
    private void Awake()
    {
        tmp.fontSize = minTextSize;
        growing = true;
        button.interactable = false;
    }

    
    public void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void Update()
    {
        if (growing)
        {
            tmp.fontSize += speed * Time.deltaTime;

            if (tmp.fontSize >= maxTextSize)
            {
                growing = false;

                tmp.fontSize = maxTextSize;

                button.interactable = true;
            }
        }
        else
        {
            tmp.fontSize -= speed * Time.deltaTime;

            if (tmp.fontSize <= minTextSize)
            {
                growing = true;

                tmp.fontSize = minTextSize;
            }
        }
    }
}
