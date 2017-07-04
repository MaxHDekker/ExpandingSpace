using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformDestroyer : MonoBehaviour {

    public GameObject platformDestoryPoint;

	void Start ()
    {
        platformDestoryPoint = GameObject.Find("PlatformDestroyPoint");
	}
	
	void Update ()
    {
        if (transform.position.x < platformDestoryPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
