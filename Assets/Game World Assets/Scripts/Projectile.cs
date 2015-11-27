using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	private float lifeTime = 0;
	public ParticleSystem particle;

	// Use this for initialization
	void Start () 
	{
		//Destroy(gameObject, 1);
	
	}

	// Update is called once per frame
	void Update () 
	{
		lifeTime += Time.deltaTime;

		if (lifeTime >= 5) {
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter(Collision c)
	{	
		//if (c.gameObject.tag == "Enemy") {
		//	Physics.IgnoreCollision(c.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
		//}

		if(c.gameObject.tag == "Player")
		{
			Debug.Log("Collided!");
			ParticleSystem tempParticle = Instantiate(particle, c.transform.position, c.transform.rotation) as ParticleSystem;
			if (GUI_Lives.lives >= 1)
			{
				GUI_Lives.lives -= 1;
			}
			Destroy(gameObject);
		}
	}
}
