using UnityEngine;
using System.Collections;

public class R1Move : MonoBehaviour {


	void Update(){
		if (Time.realtimeSinceStartup > 10.0f && Time.realtimeSinceStartup < 15.0f) {
			Component halo = GetComponent ("Halo"); 
			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		} else {
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		}
	}

	public void OnMouseDown() {
		PlayerScript.RUpTrue();
	}
	
	public void OnMouseUp()
	{
		PlayerScript.RUpFalse();
	}
	
}
