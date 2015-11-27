using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public Transform target;
    public GameObject targett;
    public int moveSpeed = 5;
    public int rotationSpeed = 3;

    public Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = transform;
        target = GameObject.FindWithTag("Player").transform;
        //movementdirection = 0;
	}
	
	// Update is called once per frame
	void Update () {	
        //rotate towards player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        //move towards the player
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

	}

     //void OnCollisionEnter(Collision c)
     //{
     //    if (c.gameObject == targett)
     //    {
     //        c.transform.position = new Vector3(508f, 203f, 481f);
     //    }
     //}

}
