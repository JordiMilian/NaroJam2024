using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmortalCats : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "CatCollider")
        {
            collision.transform.GetComponent<Cat>().inmortal = false;
        }
    }
}
