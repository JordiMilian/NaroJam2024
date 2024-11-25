using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioUtility : MonoBehaviour
{
    [SerializeField] float width = 16.0f, height = 9.0f;

    void Start()
    {
        Adjust();
    }


    public void Adjust()
    {
        float targetSpace = width / height;

        float windowaAspect = (float)Screen.width / Screen.height;

        float scaleHeight = windowaAspect / targetSpace;

        Camera camera = GetComponent<Camera>();

        if(scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0.0f;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) * 0.5f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}