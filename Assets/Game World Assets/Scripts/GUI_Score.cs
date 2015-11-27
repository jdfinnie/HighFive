using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI_Score : MonoBehaviour {
	
	static public int score;
	Text text;
	
	// Use this for initialization
	void Start () 
	{
		score = 0;
		text = gameObject.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GUI_Lives.lives >= 1) {
			text.text = score.ToString ();
		}

	}
}
