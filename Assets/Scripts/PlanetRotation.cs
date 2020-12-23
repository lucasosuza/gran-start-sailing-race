using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationMin = 0f;
    public float rotationMax = 10f;

    void Update()
    {
        float rotationSpeed = Random.Range(rotationMin, rotationMax);

        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
