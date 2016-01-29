using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Board : MonoBehaviour {
	public int sizeX = 20;
	public int sizeY = 20;
	public float tileToUnitRatio = 5;
	public GameObject tilePrefab;
	// Use this for initialization
	void Start () {
		Regenerate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Regenerate() {
		CreateBackground ();
		DestroyTiles ();
		GenerateTiles ();
	}

	void CreateBackground() {
		Vector3 scale = new Vector3 (tileToUnitRatio * sizeX, tileToUnitRatio * sizeY, 1);
		transform.localScale = scale;
	}

	void GenerateTiles() {
		for (int i = 0; i < sizeX; i++) {
			for (int j = 0; j < sizeY; j++) {
				Vector3 startingPoint = new Vector3 (-sizeX / 2f, -sizeY / 2f, 0) * (tileToUnitRatio/10f);
//				Vector3 startingPoint =Vector3.zero;
				GameObject tile = Instantiate (
					tilePrefab, 
					startingPoint + (new Vector3 (i, j, 0) * (tileToUnitRatio/10f)),
					Quaternion.identity
				) as GameObject;

//				GameObject Tile = Instantiate (TilePrefab) as GameObject;
				tile.transform.parent = gameObject.transform;
//				tile.transform.localScale = Vector3.one;
//				tile.transform.localPosition = new Vector3 (i, j, 0) * (TileToUnitRatio / 10f);
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
