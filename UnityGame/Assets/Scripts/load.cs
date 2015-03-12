using UnityEngine;
using System.Collections;
using SimpleJSON;

public class load : MonoBehaviour {

	public string email;
	public ArrayList levels = new ArrayList();
	public ArrayList clicks = new ArrayList();
	public ArrayList times = new ArrayList();
	public ArrayList scores = new ArrayList();
	

	public bool level2 = false;
	public bool level3 = false;

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh>().text = "LOCKED";
		 StartCoroutine (get_records_by_email("mariam@gmail.com"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator get_records_by_email(string user_email) {
		levels.Clear();
		clicks.Clear ();
		times.Clear ();
		scores.Clear ();
		string urlMessage = "https://k12-mariammohamed.c9.io/api/records/get_records_by_email";
		WWWForm form = new WWWForm();
		form.AddField("email", user_email);
		WWW w = new WWW(urlMessage, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			Debug.Log(w.error);
		}
		else {
			//Debug.Log (w.text);
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
				i = i + 1;


			}
			if (level2 == true && levels.Contains(2)==false){
				GetComponent<TextMesh>().text = "LOCKED";
			}
			 if (level3 == true && levels.Contains(3)==false)
			{
				GetComponent<TextMesh>().text = "LOCKED";
			}
		}
	}
}
