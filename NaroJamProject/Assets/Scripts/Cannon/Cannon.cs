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
    [SerializeField] AudioClip hitCanonSFX, deathCanonSFX, shootSFX;
    [SerializeField] GameObject PipasVFXPrefab;
    [SerializeField] Transform VfxPosition;

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
        if (GameController.Instance.RemoveSeed(1)) 
        { 
            Instantiate(seed, shootPoint.transform.position, Quaternion.identity, transform);
            cannonAnimator.SetTrigger("shoot");
            SFX_PlayerSingleton.Instance.playSFX(shootSFX, 0.2f);
        }
    }

    public void TakeDamage() //called from Cat
    {
        hitPoints -= 1;

        if (hitPoints == 0)
        {
            cannonAnimator.SetTrigger("death");
            GameController.Instance.showResetTutorial();
            SFX_PlayerSingleton.Instance.playSFX(deathCanonSFX);
            Instantiate(PipasVFXPrefab, VfxPosition.position, Quaternion.identity);
        }
        else if(hitPoints > 0)
        {
            cannonAnimator.SetTrigger("hit");
            SFX_PlayerSingleton.Instance.playSFX(hitCanonSFX, 0.1f);
        }
        else if(hitPoints <= 0)
        {
            cannonAnimator.SetTrigger("redeath");
            SFX_PlayerSingleton.Instance.playSFX(hitCanonSFX, 0.1f);
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
