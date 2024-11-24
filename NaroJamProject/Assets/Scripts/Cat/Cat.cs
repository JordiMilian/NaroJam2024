using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int hitPoints = 1;
    [SerializeField] List<AudioClip> startCatAttackSFX = new List<AudioClip>();
    [SerializeField] AudioClip damagedCatSFX, deathCatSFX;
    Animator catAnimtor;
    public bool inmortal = true;
    bool readyToAttack;

    private bool changingSpeed = false;

    private void Awake()
    {
        changingSpeed = false;
        catAnimtor = GetComponent<Animator>();
    }
    public void GetDamage(int hitDamage = 1)
    {
        if(changingSpeed == false) StartCoroutine(ChangeSpeed(0.1f, 0.1f));
        if (inmortal) return;
        hitPoints -= hitDamage;
        catAnimtor.SetTrigger("hit");
        if(hitPoints <= 0 )
        {
            Die();
            SFX_PlayerSingleton.Instance.playSFX(deathCatSFX);
        }
        else
        {
            SFX_PlayerSingleton.Instance.playSFX(damagedCatSFX,0.1f);
        }
    }

    IEnumerator ChangeSpeed(float newSpeed, float time)
    {
        changingSpeed = true;
        float orgSpeed = speed;
        speed = newSpeed;
        yield return new WaitForSeconds(time);

        speed = orgSpeed;
        changingSpeed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CatCollider")
        {
            InRangeToAttackEntered();
        }
    }
    private void Update()
    {
        MoveCat();
    }
    void InRangeToAttackEntered()
    {
        readyToAttack = true;
        catAnimtor.SetBool("inRangeToAttack",true);

        AudioClip randomSound = startCatAttackSFX[Random.RandomRange(0, startCatAttackSFX.Count)];
        SFX_PlayerSingleton.Instance.playSFX(randomSound, 0.1f);
    }
    void Die()
    {
        SFX_PlayerSingleton.Instance.playSFX(deathCatSFX);
        Destroy(gameObject);
    }

    void MoveCat()
    {
        if (readyToAttack) return;
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
    public void EV_CatAttackedFrame()
    {
        Cannon.Instance.TakeDamage();
    }
}
