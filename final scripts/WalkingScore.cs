using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingScore : MonoBehaviour {

    public Text counterText;
    public float meters;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
        meters = (int)(Time.timeSinceLevelLoad * 6);
        counterText.text = meters.ToString("0") + " ";

    }
}
