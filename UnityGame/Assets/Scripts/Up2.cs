using UnityEngine;
using System.Collections;

public class Up2 : MonoBehaviour {
	
	bool pressed = false;
	bool s = false;
	int time = 0;

	void Update(){
		
		
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
