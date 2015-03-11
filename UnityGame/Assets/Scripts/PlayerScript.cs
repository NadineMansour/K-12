using UnityEngine;
using System;
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
	private float angle;
	private static bool gameOver;
	public GameObject targetHalo;
	public GameObject toLevelsButton;

	void SetLightBeam()
	{
		for (int i = 0; i < linePositions.Count; i++) {
			lightBeam.SetPosition(i, linePositions[i]);
		}
	}


	void Start () {
		linePositions = new List<Vector3> ();
		Vector3 start = transform.position;
		Vector3 end = start;
		end.x = 9;
		linePositions.Add (start);
		linePositions.Add (end);
		gameOver = false;
		targetHalo.SetActive(false);
		toLevelsButton.SetActive(false);
		SetLightBeam ();

	}

	void EndGame()
	{
		targetHalo.SetActive (true);
		toLevelsButton.SetActive(true);
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

		detector ();
		if (gameOver)
			EndGame ();

	}

	public static bool isGameOver()
	{
		return gameOver;
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
		if (transform.position.y+ renderer.bounds.size.y/2.0f< rail.transform.position.y+rail.renderer.bounds.size.y/2.0f && !gameOver) {
			transform.position = transform.position+new Vector3(0, 0.05f, 0);
			for (int i = 0; i < linePositions.Count; i++) {
				linePositions[i] += new Vector3(0, 0.05f, 0);
			}
			SetLightBeam();
		}
	}
	
	public void MoveDown(){
		if (transform.position.y- renderer.bounds.size.y/2.0f> rail.transform.position.y+rail.renderer.bounds.size.y/-2.0f && !gameOver) {
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
		if ((zz < 60 || zz >=300) && !gameOver) {
			transform.Rotate (new Vector3(0,0,0.5f));
			angle+= 0.5f;
			RotateLightBeam();
		}
		
	}
	
	public void RotateDown(){
		float zz = transform.eulerAngles.z;
		print (zz+" Down");
		if ((zz<=61 || zz > 301) && !gameOver) {
			transform.Rotate (new Vector3 (0, 0, -0.5f));
			angle-= 0.5f;
			RotateLightBeam();
		}
	}

	void PointRotator()
	{
		Vector3 pivotPoint = linePositions [0];
		Vector3 pointToRotate = new Vector3 (9, pivotPoint.y, 0);
		float Nx = (pointToRotate.x - pivotPoint.x);
		float Ny = (pointToRotate.y - pivotPoint.y);
		float angle1 = angle * Mathf.PI / 180.0f;
		linePositions[1] = new Vector3((float)(Mathf.Cos(angle1) * Nx - Mathf.Sin(angle1) * Ny + pivotPoint.x), (float)(Mathf.Sin(angle1) * Nx + Mathf.Cos(angle1) * Ny + pivotPoint.y), 0);
	}

	void PointChecker()
	{
		Vector3 endP = linePositions [1];
		if (endP.x < 9) {
			Vector3 startP = linePositions[0];
			float slope = (endP.y - startP.y)/(endP.x - startP.x);
			float yIntercept = startP.y - startP.x*slope;
			float newY = slope*9.0f + yIntercept;
			linePositions[1] = new Vector3(9.0f, newY, 0.0f);
		}
	}

	void RotateLightBeam()
	{
		PointRotator ();
		PointChecker ();
		SetLightBeam ();
	}

	void detector()
	{
		RaycastHit hit;
		if (Physics.Linecast (linePositions [0], linePositions [1], out hit)) {
			if (hit.collider.tag == "Target")
			{
				linePositions[1] = hit.point;
				SetLightBeam();
				gameOver = true;
			}
			if (hit.collider.tag == "Obstacle")
			{
				linePositions[1] = hit.point;
				SetLightBeam();
			}
		} else {
			PointChecker();
		}
		
	}

}
