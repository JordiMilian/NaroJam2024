using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Sprite buttonClicked;
    public void Play()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        var image = GetComponent<Image>();
        GetComponent<AudioSource>().Play();
        image.sprite = buttonClicked;
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);
    }
}
