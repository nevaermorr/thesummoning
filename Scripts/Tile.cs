using UnityEngine;
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
		if (evilNeighboursCount == 2
		    || evilNeighboursCount == 3) {
			nextState = State.evil;
		} else {
			nextState = State.empty;
		}
	}

	public void ChangeToNextState() {
		state = nextState;
	}

	protected int GetNumberOfEvilNeighbours() {
		int evilNeighboursCount = 0;

		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1);
//		Debug.Log (hitColliders.GetLength(0));
		foreach (Collider2D hit in hitColliders) {
			Tile neighbour = hit.GetComponent<Collider2D>().GetComponent<Tile>();
			if (neighbour.state == Tile.State.evil) {
				evilNeighboursCount++;
			}
		}
//		Debug.Log (evilNeighboursCount);
		return evilNeighboursCount;
	}



}
