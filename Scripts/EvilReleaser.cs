using UnityEngine;
using System.Collections;

public class EvilReleaser : MonoBehaviour {

	// Stop the evil after this many steps.
	public int maxSteps = 10;
	// Time between the steps, when playing automatically.
	public float timeBetweenSteps = 1f;
	// Is the evil on the move?
	public bool progress = false;

	void OnMouseDown() {
		if (!progress) {
			StartCoroutine (StepSequence());
		}
	}

	protected IEnumerator StepSequence () {
		progress = true;
		for (int i = 0; i < maxSteps; i++) {
			MoveOneStep ();
			yield return new WaitForSeconds (timeBetweenSteps);
		}
		progress = false;
	}

	protected void MoveOneStep() {
		GameObject[] tileObjects = GameObject.FindGameObjectsWithTag("Tile");

		foreach (GameObject tileObject in tileObjects) {
			Tile tile = tileObject.GetComponent<Tile> ();
			if (tile) {
				tileObject.GetComponent<Tile> ().AssertNextState ();
			}
		}
		foreach (GameObject tileObject in tileObjects) {
			Tile tile = tileObject.GetComponent<Tile> ();
			if (tile) {
				tileObject.GetComponent<Tile> ().ChangeToNextState ();
			}
		}
	}
}
