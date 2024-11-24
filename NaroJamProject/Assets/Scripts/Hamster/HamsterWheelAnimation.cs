using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterWheelAnimation : MonoBehaviour
{
    [SerializeField] float speedRotation;

    private void Update()
    {
        transform.Rotate(0, 0,  speedRotation * (GameController.Instance.numHamsters * 0.5f) * Time.deltaTime, Space.Self);
    }
}
