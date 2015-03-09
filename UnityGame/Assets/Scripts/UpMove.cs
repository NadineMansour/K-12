using UnityEngine;
using System.Collections;

public class UpMove : MonoBehaviour {

	bool pressed = false;
	bool s = false;
	int time = 0;


	/*void Update(){
		Component halo = GetComponent("Halo"); 
		if (pressed) {
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		}
		else{
			if(time==10){

				if(s){
					transform.localScale = new Vector3 (1.0f,1.0f,1.0f);
					s=false;
				}
				else{
					transform.localScale = new Vector3 (1.2f,1.2f,1.2f);
					s=true;
				}
				time = 0;

			}



		}

		time++;
	}*/


	void Update(){

		if (Time.realtimeSinceStartup > 5.0f) {
			Component halo = GetComponent ("Halo"); 
			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
		} else {
			Component halo = GetComponent ("Halo"); 
			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		}
	}

	public void OnMouseDown() {
		pressed = true;
		PlayerScript.UpTrue();
	}
	
	public void OnMouseUp()
	{
		PlayerScript.UpFalse ();
	}
}
