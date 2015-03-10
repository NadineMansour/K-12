using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	public GameObject rail;
	public static bool up;
	public static bool down;
	public static bool RUp;
	public static bool RDown;
	public LineRenderer lightBeam;
	private List <Vector3> linePositions;
	int r1 = 0;

	void SetLightBeam()
	{
		for (int i = 0; i < linePositions.Count; i++) {
			lightBeam.SetPosition(i, linePositions[i]);
		}
	}


	void Start () {
		linePositions = new List<Vector3> ();
		Vector3 start = transform.position;
		Vector3 end = transform.position+new Vector3(13, 0, 0);
		print (start);
		linePositions.Add (start);
		linePositions.Add (end);


		SetLightBeam ();

	}

	
	void Update () {

		if (up) {
			MoveUp();
		}
		if (down) {
			MoveDown();
		}
		if (RUp) {
			RotateUp();
		}
		if (RDown) {
			RotateDown();
		}
	}
	
	
	public static void UpTrue(){
		up = true;
	}
	
	public static void UpFalse(){
		up = false;
	}
	
	public static void DownTrue(){
		down = true;
	}
	
	public static void DownFalse(){
		down = false;
	}
	
	public static void RUpTrue(){
		RUp = true;
	}
	
	public static void RUpFalse(){
		RUp = false;
	}
	
	public static void RDownTrue(){
		RDown = true;
	}
	
	public static void RDownFalse(){
		RDown = false;
	}
	
	public  void MoveUp(){
		if (transform.position.y+ renderer.bounds.size.y/2.0f< rail.renderer.bounds.size.y/2.0f ) {
			transform.position = transform.position+new Vector3(0, 0.05f, 0);
			for (int i = 0; i < linePositions.Count; i++) {
				linePositions[i] += new Vector3(0, 0.05f, 0);
			}
			SetLightBeam();
		}
	}
	
	public void MoveDown(){
		if (transform.position.y- renderer.bounds.size.y/2.0f> rail.renderer.bounds.size.y/-2.0f) {
			transform.position = transform.position-new Vector3(0, 0.05f, 0);
			for (int i = 0; i < linePositions.Count; i++) {
				linePositions[i] -= new Vector3(0, 0.05f, 0);
			}
			SetLightBeam();
		}
	}
	
	public void RotateUp(){
		
		float zz = transform.eulerAngles.z;
		print (zz+ " Up");
		if (zz < 60 || zz >=300) {
			transform.Rotate (new Vector3(0,0,0.5f));
		}
		
	}
	
	public void RotateDown(){
		float zz = transform.eulerAngles.z;
		print (zz+" Down");
		if (zz<=61 || zz > 301) {
			transform.Rotate (new Vector3 (0, 0, -0.5f));
		}
	}
}
