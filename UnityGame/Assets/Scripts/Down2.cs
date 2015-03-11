using UnityEngine;
using System.Collections;

public class Down2 : MonoBehaviour {
	
	
	void Update(){

	}
	
	public void OnMouseDown() {
		PlayerScript.DownTrue();
	}
	
	public void OnMouseUp()
	{
		PlayerScript.DownFalse ();
	}
}
