using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int hitPoints = 1;

    public void GetDamage(int hitDamage = 1)
    {
        hitPoints -= hitDamage;

        if(hitPoints <= 0 )
        {
            Die();
        }
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
