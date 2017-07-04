using UnityEngine;
using System.Collections;

public class bonusPickup : MonoBehaviour
{
    public float moveSpeed;
    public float speedBonus;
    public float healthBonus;
    public float jumpBonus;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            moveSpeed += 10;
        }

    }
    void Start()
    {
        speedBonus = 10f;
        moveSpeed = 5f;
    }

    void Update()
    {

    }
}