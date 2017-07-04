using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickupDestroyer : MonoBehaviour
{

    public GameObject pickupDestoryPoint;

    void Start()
    {
        pickupDestoryPoint = GameObject.Find("pickupDestroyPoint");
    }

    void Update()
    {
        if (transform.position.x < pickupDestoryPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
