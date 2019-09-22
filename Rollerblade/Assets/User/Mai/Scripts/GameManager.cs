using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Sphere;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Sphere.SetActive(false);

        }

        if (Input.GetKey(KeyCode.Space))
        {

            Sphere.SetActive(true);

        }

    }
}
