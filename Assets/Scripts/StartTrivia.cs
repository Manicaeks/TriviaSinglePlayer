using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartTrivia : MonoBehaviour {
	public GameObject gameManager;

	IEnumerator OnClick () {
		yield return new WaitForSeconds(0.5f);		//on the pressing of Go, wait for half a second then turn on the game manager and get rid of go button
		gameManager.SetActive(true);
		Destroy(this.gameObject);
	}
}
