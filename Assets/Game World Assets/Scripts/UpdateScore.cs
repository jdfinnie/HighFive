using UnityEngine;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	public ParticleSystem particle;
	public GameObject g;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision p)
	{		
		if (p.gameObject.tag == "Enemy" && NewBehaviourScript.powerUp == true) 
		{
			ParticleSystem tempParticle = Instantiate(particle, g.transform.position, g.transform.rotation) as ParticleSystem;
			GUI_Score.score += 5;
			Destroy(p.gameObject);
			Debug.Log("High Five!");
		}
	}
}
