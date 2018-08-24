using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private bool hasStarted= false;
	private Paddle paddle;// para poder ter acesso ao paddle dentro do script
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//lock ball in the paddle
			this.transform.position= paddle.transform.position + paddleToBallVector;
			//wait for a mouse press
			if(Input.GetMouseButtonDown(0)){
				hasStarted=true;
				print("Mouse Clicked, lounch ball");
				GetComponent<Rigidbody2D>().velocity= new Vector2(2f,10f);
				GetComponent<AudioSource>().Play();	
			}
		}
		
	}
	void OnCollisionEnter2D(Collision col){
		Vector2 tweak = new Vector2 (Random.Range(0f,0.2f),Random.Range(0f,0.2f));
		GetComponent<Rigidbody2D>().velocity+=tweak; 	
	}
}
