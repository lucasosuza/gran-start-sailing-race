using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject gb;

    // Start is called before the first frame update
    void Start()
    {
        gb = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("horizontal") != null) 
        {
            print("dsi");
        }
    }
}
