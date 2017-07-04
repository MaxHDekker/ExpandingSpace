using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{

    public GameObject[] thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    void Start()
    {
        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x / 10;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, thePlatforms.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange <minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(generationPoint.position.x + platformWidths[platformSelector] + distanceBetween, heightChange, transform.position.z);

        
            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
        }
    }
}