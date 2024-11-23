using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliderGenerator : MonoBehaviour
{
    [SerializeField] int colliderResolution;
    [SerializeField] float radius;
    [SerializeField] Vector2 boxCollider2DSize = Vector2.one;
    void Start()
    {
        CreateColliders(radius, colliderResolution);
    }

    void CreateColliders(float rad, int resolution)
    {
        float TAU = 2 * Mathf.PI;

        for (int i = 0; i < resolution; i++)
        {
            float radian = ((float)i / resolution) * TAU;
            float x = Mathf.Cos(radian) * radius;
            float y = Mathf.Sin(radian) * radius;

            GameObject newCollider = new GameObject();
            newCollider.transform.position = transform.position;
            newCollider.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            newCollider.name = "Colliders";
            newCollider.transform.parent = transform;

            BoxCollider2D newBoxCollider2D = newCollider.AddComponent<BoxCollider2D>();
            newBoxCollider2D.size = boxCollider2DSize;

            newCollider.transform.eulerAngles = new Vector3(0, 0, radian * (180 / Mathf.PI));

        }
    }
}
