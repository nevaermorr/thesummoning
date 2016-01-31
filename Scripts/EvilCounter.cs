using UnityEngine;
using System.Collections;

public class EvilCounter : MonoBehaviour {
	public Sprite[] counts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int evilLeft = GetComponentInParent<EvilDispatcher> ().evilParticlesLeft;
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = counts [evilLeft];
	}
}
