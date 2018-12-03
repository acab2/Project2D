using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject explosion;
	public float speed;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		this.speed = 400;
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.AddForce(gameObject.transform.up * speed);
 		
	}

	void OnTriggerEnter2D(Collider2D other){

		
		if (other.name == "Player") {
			
		}else{
			Instantiate(explosion, other.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			Destroy (other.gameObject);
			Debug.Log("ouch");
		}
		
	}


	// Update is called once per frame
	void Update () {
		
	}
}
