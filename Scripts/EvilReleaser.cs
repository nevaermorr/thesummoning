using UnityEngine;
using UnityEditor;
using System.Collections;

public class EvilReleaser : MonoBehaviour {

	// Stop the evil after this many steps.
	public int maxSteps = 10;
	// Time between the steps, when playing automatically.
	public float timeBetweenSteps = 1f;
	// Is the evil on the move?
	public bool progress = false;

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
		Tile[] tiles = GetTiles ();
		SequenceTracker sequenceTracker = new SequenceTracker ();

		for (int i = 0; i < maxSteps; i++) {
			MoveOneStep (tiles);

			if (isEndOfGame (tiles)) {
				break;
			} else if(sequenceTracker.isPrevSequence(tiles)) {
				break;
			}

			yield return new WaitForSeconds (timeBetweenSteps);
		}
		progress = false;
	}

	protected void MoveOneStep(Tile[] tiles) {

		foreach (Tile tile in tiles) {
			tile.AssertNextState ();
		}
		foreach (Tile tile in tiles) {
			tile.ChangeToNextState ();
		}
	}

	protected Tile[] GetTiles() {
		GameObject[] tileObjects = GameObject.FindGameObjectsWithTag("Tile");

		Tile[] tiles = new Tile[0];
		foreach (GameObject tileObject in tileObjects) {
			Tile tile = tileObject.GetComponent<Tile> ();
			if (tile) {
				ArrayUtility.Add (ref tiles, tileObject.GetComponent<Tile> ());
			}
		}
		return tiles;
	}

	protected bool isEndOfGame(Tile[] tiles) {
		int cultistCount = 0;
		int evilCount = 0;

		foreach (Tile tile in tiles) {
			if (tile.state == Tile.State.cultist) {
				cultistCount++;
			} else if (tile.state == Tile.State.evil) {
				evilCount++;
			}
		}

		if (cultistCount == 0
			|| evilCount == 0
		) {
			return true;
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
