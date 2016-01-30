using UnityEngine;
using System.Collections;

public class ReleaseEvil : MonoBehaviour {

	void OnMouseDown() {
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
