using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI_Lives : MonoBehaviour {

	static public int lives;
	static public Text text;
	
	// Use this for initialization
	void Start () 
	{
		lives = 5;
		text = gameObject.GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lives >= 1) {
			text.text = lives.ToString ();
		} else if (lives <= 0) {
			text.text = "GAME OVER";
		}
		
	}
}
