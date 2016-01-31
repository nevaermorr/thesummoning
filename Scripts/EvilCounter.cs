﻿using UnityEngine;
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
		if (evilLeft >= counts.Length) {
			spriteRenderer.sprite = counts [counts.Length - 1];
		} else {
			spriteRenderer.sprite = counts [evilLeft];
		}
	}
}
