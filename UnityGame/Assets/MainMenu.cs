using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	int res;
	
	void FinishedLevels(){//sets res to the the last unlocked level
		res = 2;
	}
	//note any previous unlocked level
	private void OnGUI () {
		
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			// no restrictions on level 1
			Application.LoadLevel("Level1");
		}
		
		
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			//checks if the last unlocked level is greater or equal than the level I want to play
			if(res.CompareTo(2).Equals(1) || res.CompareTo(2).Equals(0))
				Application.LoadLevel("Level2");
			else
				print("This level is locked") ;
			
		}
		
	}
}