using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSliderValue : MonoBehaviour {

    private TextMeshProUGUI valueText;

	// Use this for initialization
	void Start () {
        valueText = GetComponent<TextMeshProUGUI> ();
    }
	
	// Update is called once per frame
	public void textUpdate (float value) {
        valueText.text = value.ToString();
        
	}
}
