using UnityEngine;
using System.Collections;

public class DownMove : MonoBehaviour {


	void Update(){
		
		if (Time.realtimeSinceStartup > 5.0f && Time.realtimeSinceStartup < 10.0f) {
			Component halo = GetComponent ("Halo"); 
			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		} else {
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		}
	}

	public void OnMouseDown() {
		PlayerScript.DownTrue();
	}
	
	public void OnMouseUp()
	{
		PlayerScript.DownFalse ();
	}
}
