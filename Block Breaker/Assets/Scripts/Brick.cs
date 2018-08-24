using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public AudioClip brickhit;
	public static int breakableCount = 0;

	private int timesHit;
	private bool isBreakable;
	
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag=="Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
			print(breakableCount);
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint(brickhit,transform.position);
		if(isBreakable){
			HandleHits();
		}
	}
	void HandleHits(){
		timesHit++;
		int maxHits=hitSprites.Length +1;

		if(timesHit>=maxHits){
			breakableCount--;
			print(breakableCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject);//aqui nao pode ser this pq this faria referencia ao script brick 
		
		}else{
			LoadSprites();
		}

	}
	void LoadSprites(){
		int spriteIndex = timesHit -1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite =hitSprites[spriteIndex];//estou pegandp  o componente spriterender e selecionando a opcao sprite e dps auterando 
		}
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin(){
		levelManager.LoadNextLevel();

	}
}
