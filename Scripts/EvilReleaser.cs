using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EvilReleaser : MonoBehaviour {

	// Stop the evil after this many steps.
	public int maxSteps = 10;
	// Time between the steps, when playing automatically.
	public float timeBetweenSteps = 1f;
	// Is the evil on the move?
	public bool progress = false;
	public enum EndState
	{
		none,
		win,
		loss
	};

	public EndState endState;

	void Update() {
		AdjustButtonAlpha ();
	}

	void OnMouseDown() {
		if (!progress) {
			StartCoroutine (BreedSequence());
		}
	}

	protected IEnumerator BreedSequence () {
		progress = true;
		List<Tile> tiles = GetTiles ();
		SequenceTracker sequenceTracker = new SequenceTracker ();

		for (int i = 0; i < maxSteps; i++) {
			MoveOneStep (tiles);

			if (isEndOfGame (tiles)) {
				ResolveGame ();
				break;
			} else if(sequenceTracker.isPrevSequence(tiles)) {
				break;
			}

			yield return new WaitForSeconds (timeBetweenSteps);
		}
		progress = false;
	}

	protected void ResolveGame () {
		EndScreen endScreen = GameObject.FindGameObjectWithTag ("EndScreen").GetComponent<EndScreen> ();
		if (endState == EndState.win) {
			endScreen.Win ();
		} else if (endState == EndState.loss) {
			endScreen.Loss ();
		}
	}

	protected void MoveOneStep(List<Tile> tiles) {

		foreach (Tile tile in tiles) {
			tile.AssertNextState ();
		}
		foreach (Tile tile in tiles) {
			tile.ChangeToNextState ();
		}
	}

	protected List<Tile> GetTiles() {
		GameObject[] tileObjects = GameObject.FindGameObjectsWithTag("Tile");

		List<Tile> tiles = new List<Tile>();
		foreach (GameObject tileObject in tileObjects) {
			Tile tile = tileObject.GetComponent<Tile> ();
			if (tile) {
				tiles.Add (tileObject.GetComponent<Tile> ());
//				ArrayUtility.Add (ref tiles, tileObject.GetComponent<Tile> ());
			}
		}
		return tiles;
	}

	protected bool isEndOfGame(List<Tile> tiles) {
		int cultistCount = 0;
		int evilCount = 0;

		foreach (Tile tile in tiles) {
			if (tile.state == Tile.State.cultist) {
				cultistCount++;
			} else if (tile.state == Tile.State.evil) {
				evilCount++;
			}
		}

		if (cultistCount == 0) {
			endState = EndState.win;
			return true;
		} else if (evilCount == 0) {
			endState = EndState.loss;
			return true;
		} else {
			endState = EndState.none;
		}

		return false;
	}

	protected void AdjustButtonAlpha() {
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		Color color = renderer.color;
		if (progress) {
			color.a = .2f;
		} else {
			color.a = 1f;
		}
		renderer.color = color;
	}
}
