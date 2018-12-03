using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

	public float speed = 40;
	Animator anim;
	public Bullet bullet;
	Transform bulletPos;
	//The interval you want your player to be able to fire.
 	public float AttackRate = 1;
 
	//The actual time the player will be able to fire.
 	private float NextAttack;

	private string weapon = "sword";
	

	void FixedUpdate(){
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> (); 
		rigidbody2D.angularVelocity = 0;

		float input = Input.GetAxis("Vertical");

		rigidbody2D.AddForce(gameObject.transform.up * speed * input);
		
	}


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(weapon == "sword" && Input.GetMouseButtonDown(0) && Time.time > NextAttack){
		//	anim.SetTrigger("Sword");
			NextAttack = Time.time + AttackRate;
		
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        	float anguloMouseJogador = Vector2.Angle(new Vector2(0,0), (mousePosition - GetComponent<Transform>().position));
			Vector3 bulletPos = new Vector2(GetComponent<Transform>().position.x,GetComponent<Transform>().position.y);
			
			//GameObject bulletFired = Instantiate(bullet, bulletPos,Quaternion.identity);
			//var firedBullet = Instantiate(bullet, bulletPos,Quaternion.identity);
        	
			Destroy(Instantiate(bullet, bulletPos,Quaternion.identity).GetComponent<Transform> ().gameObject,3.5f);
			

		}
	}
}
