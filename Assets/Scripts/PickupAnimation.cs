using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
    public float rotationSpeed = 0f;
    public bool rotationAnimation = false;
    public float hoverSpeed = 0f;
    public bool hoverAnimation = false;
    public float scaleSpeed = 0f;
    public bool scaleAnimation = false;
    public float yStart = 0f;
    public float yRange = 1f;
    public int dir = 1;
    public float scaleRangeMax = 1f;
    public float scaleRangeMin = 0f;
    public int scaleDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        yStart = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > yRange || transform.position.y<yStart)
        {
            dir = -dir;
        }

        if (scaleAnimation)
        {
            ScalePicup();
        }

        if (rotationAnimation)
        {
            rotatePickup();
        }

        if (hoverAnimation)
        {
            hoverPickup();
        }
    }

    void ScalePicup()
    {
        if (transform.localScale.y < scaleRangeMin || transform.localScale.y > scaleRangeMax)
        {
            scaleDir = -scaleDir;
        }

        float scaleFactor = scaleSpeed * Time.deltaTime * scaleDir;
        transform.localScale = transform.localScale + new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    void hoverPickup()
    {
        transform.Translate(0f, hoverSpeed * Time.deltaTime * dir, 0f);
    }

    void rotatePickup()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
