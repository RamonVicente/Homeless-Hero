using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperboard : MonoBehaviour {

	Collider2D collider;

	private void Awake(){
		collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision){
		
		Player player = collision.gameObject.GetComponent<Player>();
		if (!player) return;

		player.GetPaperboard();
		Destroy(gameObject);
	}
}
