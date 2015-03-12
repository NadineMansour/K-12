using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Text2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public void SetText(string text) {
		var myText = gameObject.GetComponent<Text>();
		if (myText == null) {
			myText = gameObject.AddComponent<Text>();
		}
		myText.text = text;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerScript.isGameOver ()) {
			SetText ("Congrats!! People of planet Saharawy thank you for enlightening their planet");
		} else {
			if (Time.realtimeSinceStartup < 5) 
			{
				SetText ("This is a blackhole that sucks light, therefore light can't pass through it to the planet.");
			}
			else
			{
				SetText ("");
			}
		}

		
	}
}
