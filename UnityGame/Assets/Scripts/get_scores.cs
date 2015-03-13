using UnityEngine;
using System.Collections;
using SimpleJSON;

public class get_scores : MonoBehaviour {
	//3Dtext
	public bool score1;
	public bool score2;
	public bool score3;
	public bool score4;
	public bool score5;
	public bool level1;
	public bool level2;
	public bool level3;
	public bool level4;
	public bool level5;
	
	// Use this for initialization
	public ArrayList levels = new ArrayList();
	public ArrayList clicks = new ArrayList();
	public ArrayList times = new ArrayList();
	public ArrayList scores = new ArrayList();
	void Start () 
	{
		StartCoroutine (get_records_by_email());
	}
	
	IEnumerator get_records_by_email() 
	{

		levels.Clear();
		clicks.Clear ();
		times.Clear ();
		scores.Clear ();
		string urlMessage = "https://k12-mariammohamed.c9.io/api/records/get_records_by_email";
		WWWForm form = new WWWForm();
		form.AddField("email", "mariam@gmail.com");
		WWW w = new WWW(urlMessage, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			Debug.Log(w.error);
		}
		else {
			Debug.Log (w.text);
			var N = JSON.Parse(w.text);
			int i = 0;
			while (true) {
				if (N[i] == null) {
					break;
				}
				levels.Add ( N[i]["record"]["level"].AsInt);
				times.Add ( N[i]["record"]["time"].AsInt);
				scores.Add ( N[i]["record"]["score"].AsInt);
				clicks.Add ( N[i]["record"]["clicks"].AsInt);

				if(i < scores.Count){
					if (score1 == true)
					{
						//change the String in the 3Dtext componant
					GetComponent<TextMesh>().text =(string) (N[0]["record"]["score"]);
					}
					else if (level1 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[0]["record"]["level"]);
					}
					else if(score2 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[1]["record"]["score"]);
					}
					else if (level2 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[1]["record"]["level"]);
					}
					else if (score3 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[2]["record"]["score"]);
					}
					else if (level3 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[2]["record"]["level"]);
					}
					else if (score4 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[3]["record"]["score"]);
					}
					else if (level4 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[3]["record"]["level"]);
					}
					else if (score5 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[4]["record"]["score"]);
					}
					else if (level5 == true)
					{
						GetComponent<TextMesh>().text =(string) (N[5]["record"]["level"]);
					}
				}

				i = i +1;

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}