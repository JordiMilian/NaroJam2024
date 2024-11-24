using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int hitPoints = 1;

    public bool inmortal = true;

    private bool changingSpeed = false;

    private void Awake()
    {
        changingSpeed = false;
    }
    public void GetDamage(int hitDamage = 1)
    {
        if(changingSpeed == false) StartCoroutine(ChangeSpeed(0.1f, 0.1f));
        if (inmortal) return;
        hitPoints -= hitDamage;

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
            GetHamster();
        }
    }
    private void Update()
    {
        MoveCat();
    }
    void GetHamster()
    {
        Destroy(gameObject);
        //To be implemented -- Coge un hamster y se pira
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void MoveCat()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
