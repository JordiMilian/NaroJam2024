using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int hitPoints = 1;
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
            Debug.Log("Cat near");
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
    }
    void Die()
    {
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
