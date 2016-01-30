﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class Tile : MonoBehaviour {
	// possible states of tile
	public enum State
	{
		empty,
		evil,
		cultist
	};
	public Sprite spriteEmpty;
	public Sprite spriteEvil;
	public Sprite spriteCultist;
	public State state;
	public State nextState;

	// Number of neighbours for evil tile to remain evil
	public int[] ruleForEvil;
	// Number of neighbours for empty tile to become evil
	public int[] ruleForEmpty;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AdjustSprite ();
	}

	void AdjustSprite() {
		if (state == State.empty) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = spriteEmpty;
		} else if (state == State.evil) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = spriteEvil;
		} else if (state == State.cultist) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = spriteCultist;
		}
	}

	public void AssertNextState() {
		int evilNeighboursCount = GetNumberOfEvilNeighbours ();
		if ((state == State.empty
				&& ArrayUtility.Contains(ruleForEmpty, evilNeighboursCount)) 
			|| (state == State.evil
					&& ArrayUtility.Contains(ruleForEvil, evilNeighboursCount)
			)
		) {
			nextState = State.evil;
		} else {
			nextState = State.empty;
		}
	}

	public void ChangeToNextState() {
		state = nextState;
	}

	protected int GetNumberOfEvilNeighbours() {
		// Little trick for the tiles considering themselves as their own neighbours.
		int evilNeighboursCount = (state == State.evil)?  -1 : 0;

		// Get all neighbours and count the evil ones.
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1);
		foreach (Collider2D hit in hitColliders) {
			Tile neighbour = hit.GetComponent<Collider2D>().GetComponent<Tile>();
			if (neighbour.state == Tile.State.evil) {
				evilNeighboursCount++;
			}
		}
		return evilNeighboursCount;
	}
}
