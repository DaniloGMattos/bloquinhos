using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public bool autoplay = false;
	private Ball ball;
	void Start(){
		ball= GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoplay){

			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,0f);//o f é para sinalizar que é float, e esse this ele manda manter a coordenada y que eu já deixei o objeto no inicio no editor
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x,0.5f,15.5f);
		this.transform.position= paddlePos;// This é a instancia do script atual



	}
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,0f);//o f é para sinalizar que é float, e esse this ele manda manter a coordenada y que eu já deixei o objeto no inicio no editor
		float mouseInBlocks = ((Input.mousePosition.x/Screen.width)*16);//posicao em x do mouse relativa a largura da tela (porcentagem da largura da tela ocupada pelo mouse), multiplico por 16 e tenho o numero de game unities 
		paddlePos.x = Mathf.Clamp(mouseInBlocks,0.5f,15.5f);
		this.transform.position= paddlePos;// This é a instancia do script atual


	}
}
