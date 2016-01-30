using UnityEngine;
using System.Collections;

public class ReleaseEvil : MonoBehaviour {

	void OnMouseDown() {
		GameObject[] tileObjects = GameObject.FindGameObjectsWithTag("Tile");

		foreach (GameObject tileObject in tileObjects) {
			tileObject.GetComponent<Tile>().AssertNextState ();
		}
		foreach (GameObject tileObject in tileObjects) {
			tileObject.GetComponent<Tile>().ChangeToNextState ();
		}
	}
}
