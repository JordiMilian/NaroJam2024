using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] float minBounceStrenght, maxBounceStrenght;
    [SerializeField] float minAngle, maxAngle;

    [SerializeField] int hungry = 2;

    Rigidbody2D rb;

    Cannon cannon;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(minAngle, maxAngle);

        float rad = randomAngle * Mathf.PI / 180;

        float newX = Mathf.Cos(rad);
        float newY = Mathf.Sin(rad);

        Vector2 newVector = new Vector2(newX, newY).normalized;
        float bounceStrenght = Random.Range(minBounceStrenght, maxBounceStrenght);
        rb.AddForce(newVector * bounceStrenght);

        GameController.Instance.AddSeedConsumition(hungry);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float bounceStrenght = Random.Range(minBounceStrenght, maxBounceStrenght);
        rb.AddForce(collision.contacts[0].normal * bounceStrenght);

        Cannon.Instance.Shoot();
    }

    public void KillHamster()
    {
        GameController.Instance.RemoveSeedConsumition(hungry);
        Destroy(gameObject);
    }
}