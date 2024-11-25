using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] float minBounceStrenght, maxBounceStrenght;
    [SerializeField] float minAngle, maxAngle;

    [SerializeField] int hungry = 2;

    [SerializeField] GameObject explosionHitVFX;
    [SerializeField] AudioClip bounceToWallSFX;
    Rigidbody2D rb;

    Cannon cannon;

    bool canShoot;
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
    }

    private void Start()
    {
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        float bounceStrenght = Random.Range(minBounceStrenght, maxBounceStrenght);
        rb.AddForce(collision.contacts[0].normal * bounceStrenght);

        Instantiate(explosionHitVFX, collision.contacts[0].point, Quaternion.identity, null);

        if (collision.gameObject.layer != 6)
        {
            if (canShoot)
            {
                Cannon.Instance.Shoot();
                canShoot = false;
                StartCoroutine(DelayTimeForShoot());
                SFX_PlayerSingleton.Instance.playSFX(bounceToWallSFX, 0.2f);

            }
        }
    }

    IEnumerator DelayTimeForShoot()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
    public void KillHamster()
    {
        GameController.Instance.RemoveSeedConsumition(hungry);
        Destroy(gameObject);
    }
}
