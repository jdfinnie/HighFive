using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	
	public GameObject darkEnemy;

	static public float spawnTime = 0;

	// Use this for initialization
	void Start () {
		GameObject newEnemy = Instantiate(darkEnemy, this.transform.position, this.transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (NewBehaviourScript.powerUp == false) {
			spawnTime += Time.deltaTime;
		}

		if (spawnTime >= 5) 
		{
			GameObject newEnemy2 = Instantiate(darkEnemy, this.transform.position, this.transform.rotation) as GameObject;
			spawnTime = 0;
		}
	}
}
