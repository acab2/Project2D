using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

	public GameObject explosion;
 	public GameObject sword;
	Vector2 posicaoJogador;

	void OnTriggerEnter2D(Collider2D other){

		Instantiate(explosion, other.transform.position, Quaternion.identity);
		Destroy (other.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	void FixedUpdate () {
		
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
