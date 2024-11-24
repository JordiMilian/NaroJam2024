using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject seed;
    [SerializeField] GameObject shootPoint;

    [SerializeField] int hitPoints = 3;
    public static Cannon Instance;

    [SerializeField] Color enabledColor, disabledColor;
    [SerializeField] SpriteRenderer OnOffButtonSprite;
    Animator cannonAnimator; 

    private bool cannonEnabled = true;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        cannonAnimator = GetComponent<Animator>();
        cannonEnabled = true;
        OnOffButtonSprite.color = enabledColor;
    }
    public void Shoot()
    {
        if (cannonEnabled == false) return;
        if(GameController.Instance.RemoveSeed(1)) Instantiate(seed, shootPoint.transform.position, Quaternion.identity, transform); cannonAnimator.SetTrigger("shoot");
    }

    public void TakeDamage() //called from Cat
    {
        hitPoints -= 1;

        if (hitPoints == 0)
        {
            cannonAnimator.SetTrigger("death");
            GameController.Instance.showResetTutorial();
        }
        else if(hitPoints > 0)
        {
            cannonAnimator.SetTrigger("hit");
        }
        else if(hitPoints <= 0)
        {
            cannonAnimator.SetTrigger("redeath");
        }
    }
    public void ChangeEnableEstate()
    {
        cannonEnabled = !cannonEnabled;

        if(cannonEnabled)
        {
            OnOffButtonSprite.color = enabledColor;
        }
        else
        {
            OnOffButtonSprite.color = disabledColor;
        }
    }
}
