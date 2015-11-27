using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public AudioSource a;
    public AudioClip b;
    public AudioClip c;
    public AudioClip d;
    public GameObject hiddenLocation;
    public GameObject squareLocation;
    public GameObject playLocation;
    public GameObject soccerLocation;
	public GameObject[] aliveEnemies;
	public GameObject[] enemyList = new GameObject[4];
	public GameObject darkEnemy;
	public bool change = false;
	private int enemyType;
	public Transform temp;
	public GameObject enemySpawn1;
	public GameObject enemySpawn2;
	public GameObject enemySpawn3;
	public GameObject enemySpawn4;
    private int randomLocation;
    private float spawnCounter = 0;
    private float powerCounter = 0;
    private float powerOn = 0;
    private bool spawn = true;
    private bool powerAvailable = false;
    public static bool powerUp = false;


	// Use this for initialization
	void Start () {
        this.transform.position = hiddenLocation.transform.position;
        a.clip = b;
        a.Play(0);
	}
	
	// Update is called once per frame
	void Update () {
        //if the spawning is available and power is not available and powerup is not on
        if (spawn == true && powerAvailable == false && powerUp == false)
        {
            //start the spawn timer
            spawnCounter += Time.deltaTime;
            //if the timer reaches 10
            if (spawnCounter >= 14)
            {
                spawn = false;
                //get one of the locations
                //move the hand to it
                //change to the build up music
                //say power is available
                randomLocation = Random.Range(0, 3);
                if (randomLocation == 0)
                {
                    this.transform.position = squareLocation.transform.position;
                    a.clip = c;
                    a.Play(0);
                    powerCounter = 0;
                    spawnCounter = 0;
                    powerAvailable = true;
                }
                else if (randomLocation == 1)
                {
                    this.transform.position = playLocation.transform.position;
                    a.clip = c;
                    a.Play(0);
                    powerCounter = 0;
                    spawnCounter = 0;
                    powerAvailable = true;
                }
                else if (randomLocation == 2)
                {
                    this.transform.position = soccerLocation.transform.position;
                    a.clip = c;
                    a.Play(0);
                    powerCounter = 0;
                    spawnCounter = 0;
                    powerAvailable = true;
                }
            }
        }

        //if the spawning is true and the power is available and power up is not on
        else if (spawn == false && powerAvailable == true && powerUp == false)
        {
            //start the powerAvailable timer;
            powerCounter += Time.deltaTime;
            //if the timer reaches 20
            if (powerCounter >= 15)
            {
                //change the position back to the hidden location
                //set the spawn back to zero
                //set the availability to false
                this.transform.position = hiddenLocation.transform.position;
                spawnCounter = 0;
                a.clip = b;
                a.Play(0);
                powerAvailable = false;
                spawn = true;
				GameObject newEnemy = Instantiate(darkEnemy, enemySpawn1.transform.position, enemySpawn1.transform.rotation) as GameObject;
				GameObject newEnemy1 = Instantiate(darkEnemy, enemySpawn2.transform.position, enemySpawn2.transform.rotation) as GameObject;
				GameObject newEnemy2 = Instantiate(darkEnemy, enemySpawn3.transform.position, enemySpawn3.transform.rotation) as GameObject;
				GameObject newEnemy3 = Instantiate(darkEnemy, enemySpawn4.transform.position, enemySpawn4.transform.rotation) as GameObject;
            }
        }

        //if powerup is on
        else if (powerUp == true && powerAvailable == false && spawn == false)
        {
			if (change == false)
			{
				changeEnemyLight();
				change = true;
			}
			W03E04_ThrowingObjects.throwTimer = 0;
			EnemySpawn.spawnTime = 0;
            //start the power timer
            powerOn += Time.deltaTime;

            //if the power timer reaches 15
            if (powerOn >= 20)
            {
                //turn the power off
                //set the power time to zero
                //set the audio back to normal
                powerOn = 0;
                spawnCounter = 0;
                a.clip = b;
                a.Play(0);
                powerUp = false;
                spawn = true;
                powerAvailable = false;
				change = false;
				changeEnemyDark();
				GameObject newEnemy = Instantiate(darkEnemy, enemySpawn1.transform.position, enemySpawn1.transform.rotation) as GameObject;
				GameObject newEnemy1 = Instantiate(darkEnemy, enemySpawn2.transform.position, enemySpawn2.transform.rotation) as GameObject;
				GameObject newEnemy2 = Instantiate(darkEnemy, enemySpawn3.transform.position, enemySpawn3.transform.rotation) as GameObject;
				GameObject newEnemy3 = Instantiate(darkEnemy, enemySpawn4.transform.position, enemySpawn4.transform.rotation) as GameObject;
            }
        }

	}

    void OnCollisionEnter (Collision p)
    {
        if (p.gameObject.tag == "Player")
        {
            this.transform.position = hiddenLocation.transform.position;
            a.clip = d;
            a.Play(0);
			powerUp = true;
			powerAvailable = false;
			spawn = false;
			powerOn = 0;
        }
    }

	void changeEnemyLight()
	{
		aliveEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < aliveEnemies.Length; i++) 
		{
			temp = aliveEnemies[i].gameObject.transform;
			Destroy (aliveEnemies[i]);
			enemyType = Random.Range (0,4);
			GameObject newEnemy = Instantiate(enemyList[enemyType], temp.transform.position, temp.transform.rotation) as GameObject;
		}
	}

	void changeEnemyDark()
	{
		aliveEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < aliveEnemies.Length; i++) 
		{
			temp = aliveEnemies[i].gameObject.transform;
			Destroy (aliveEnemies[i]);
			enemyType = Random.Range (0,4);
			GameObject newEnemy = Instantiate(darkEnemy, temp.transform.position, temp.transform.rotation) as GameObject;
		}
	}
	
}
