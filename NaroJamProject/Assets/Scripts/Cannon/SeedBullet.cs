using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBullet : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "CatHitBox")
        {
            collision.transform.GetComponent<Cat>().GetDamage(1);

            Destroy(gameObject);
        }

        if (collision.transform.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

}
