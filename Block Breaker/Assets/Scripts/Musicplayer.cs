using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicplayer : MonoBehaviour {
	static Musicplayer instance = null;

	void Awake(){//É chamado assim que a tela carrega, antes mesmo do start
		Debug.Log("Music player Awake"+ GetInstanceID());
		if(instance!=null){
			Destroy(gameObject);
			print("Duplicate music player self_destructing!");
		}else{
			instance= this;//estou dizendo q a instance é a primeira q aparece
			GameObject.DontDestroyOnLoad(gameObject);//Faz a musica tocar entre as senas
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Music player Start"+ GetInstanceID());
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
