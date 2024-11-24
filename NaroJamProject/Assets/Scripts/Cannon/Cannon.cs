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

    bool isTakingDamage = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CatCollider")
        {
            TakeDamage();

        }
    }

    private void TakeDamage()
    {
        if (isTakingDamage) return;

        isTakingDamage = true;

        StartCoroutine(TakeDamageRoutine());
    }

    IEnumerator TakeDamageRoutine()
    {
        yield return null;
        // IMPLEMENTAR ANIMACION
        cannonAnimator.SetTrigger("hit");

        hitPoints -= 1;

        if(hitPoints == 0)
        {
            Die();
        }
        else isTakingDamage = false;
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
    private void Die()
    {
        cannonAnimator.SetTrigger("death");
        cannonAnimator.SetBool("hit",false);
        //Die
    }
}
