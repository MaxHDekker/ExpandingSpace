using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickupSpawner : MonoBehaviour
{

    public GameObject randomPickup;
    public Transform generationPoint;
    private float distanceBetween;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(randomPickup, transform.position, transform.rotation);
        }
    }
}