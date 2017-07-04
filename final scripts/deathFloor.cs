using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathFloor : MonoBehaviour
{
    [SerializeField]
    private string Main;

    private bool IsTiming = false;
    public float seconds;

    void beginTimer()
    {
        seconds = 2;
        IsTiming = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Main);
        }
    }

}
