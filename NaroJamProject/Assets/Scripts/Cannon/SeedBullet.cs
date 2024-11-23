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
}
