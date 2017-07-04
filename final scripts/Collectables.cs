using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour
{

    public float moveSpeed;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            moveSpeed += 300;
            
   

        }

    }
}