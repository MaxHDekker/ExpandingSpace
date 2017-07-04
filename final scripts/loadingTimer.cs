using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingTimer : MonoBehaviour {

    public float timeRemaining;

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining < 1)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
