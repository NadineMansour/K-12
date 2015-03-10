using UnityEngine;
using System.Collections;

public class ToLevels : MonoBehaviour {

	
	public GameObject upButton;
	// Use this for initialization
	void Start () {
	
	}

	public void OnMouseDown() {
		Application.LoadLevel("Scene2");
	}



	// Update is called once per frame
	void Update () {
	
	}
}
