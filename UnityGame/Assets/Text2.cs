using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Text2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public void SetText(string text) {
		// you can try to get this component
		var myText = gameObject.GetComponent<Text>();
		// but it can be null, so you might want to add it
		if (myText == null) {
			myText = gameObject.AddComponent<Text>();
		}
		myText.text = text;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerScript.isGameOver ()) {
			SetText ("Congrats!! People of planet Saharawy thank you for enlightening their planet");
		} 

		
	}
}
