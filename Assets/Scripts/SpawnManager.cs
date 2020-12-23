using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject start;

    public GameObject end;

    public float limitX = 500f;
    public float limitY = 500f;
    public float limitZ = 500f;
    
    public float limitScale = 50f;

    public int numberOfObjects = 9;

    public float level = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlanets();
        SpawnStart();
        SpawnEnd();
    }

    private void SpawnEnd()
    {
        GameObject target = Instantiate(end);
        target.transform.position = start.transform.position * 2;
        // target.transform.position = start.transform.position * Random.Range(0, limitX * level);
    }

    private void SpawnStart()
    {
        GameObject target = Instantiate(start);
        target.transform.position = Vector3.zero;
    }

    private void SpawnPlanets()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            SpawnPlanet();
        }
    }

    private void SpawnPlanet()
    {
        int index = Random.Range(0, objects.Length);
        GameObject target = Instantiate(objects[index]);

        target.transform.position = new Vector3(
            Random.Range(-1 * limitX, limitX),
            Random.Range(-1 * limitY, limitY),
            Random.Range(-1 * limitZ, limitZ)
            );

        float randomScale = Random.Range(limitScale/5, limitScale);
        target.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }
}
