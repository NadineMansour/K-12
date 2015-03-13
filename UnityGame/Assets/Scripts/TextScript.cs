using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

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

		if (!PlayerScript.isGameOver ()) {
			if (Time.realtimeSinceStartup < 5) {
				SetText ("You can use this button to move up.");
			} else {
				if (Time.realtimeSinceStartup < 10) {
					SetText ("You can use this button to move down.");
				} else {
					if (Time.realtimeSinceStartup < 15) {
						SetText ("You can use these 2 buttons to rotate the light source .");
					} else {
						SetText ("");
					}
				}

			}
		} else
			SetText ("Congrats!! People of planet Redo thank you for enlightening their planet");

	}
}
