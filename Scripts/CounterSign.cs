using UnityEngine;
using System.Collections;

public class CounterSign : MonoBehaviour {
	public Sprite x;
	public Sprite gt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int evilLeft = GetComponentInParent<EvilDispatcher> ().evilParticlesLeft;
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		if (evilLeft <= 10) {
			spriteRenderer.sprite = x;
		} else {
			spriteRenderer.sprite = gt;
		}
	}
}
