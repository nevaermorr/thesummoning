using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Board : MonoBehaviour {
	public int sizeX = 20;
	public int sizeY = 20;
	public float tileToUnitRatio = 5;
	public float tilePixelSize = 100;
	public GameObject tilePrefab;
	// Use this for initialization
	void Start () {
		Regenerate();
	}

	public void Regenerate() {
		CreateBackground ();
		DestroyTiles ();
		GenerateTiles ();
	}

	void CreateBackground() {
//		Vector3 scale = new Vector3 (tileToUnitRatio * sizeX, tileToUnitRatio * sizeY, 1);
		Vector3 scale = new Vector3 (sizeX, sizeY, 1);
		transform.localScale = scale;
	}

	void GenerateTiles() {
		for (int i = 0; i < sizeX; i++) {
			for (int j = 0; j < sizeY; j++) {
				Vector3 startingPoint = new Vector3 ((tilePixelSize/100 - sizeX) / 2f, (tilePixelSize/100 - sizeY) / 2f, 0);
//				Vector3 startingPoint = Vector3.zero;

				GameObject tile = Instantiate (
					tilePrefab, 
					startingPoint + (new Vector3 (i, j, 0)),
					Quaternion.identity
				) as GameObject;
				tile.name = "Tile [" + i + ":" + j + "]";
				tile.transform.parent = gameObject.transform;

//				if (
//					(i == 9 && j == 11)
//					|| (i == 10 && j == 11)
//					|| (i == 11 && j == 11)
//					|| (i == 11 && j == 12)
//					|| (i == 10 && j == 13)
//				) {
//					tile.GetComponent<Tile> ().state = Tile.State.evil;
//				}
			}
		}
	}

	void DestroyTiles(){
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag ("Tile");
		foreach (GameObject Tile in Tiles) {
			DestroyImmediate (Tile);
		}
	}
}
