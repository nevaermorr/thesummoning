using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Board : MonoBehaviour {
	public int SizeX = 20;
	public int SizeY = 20;
	public float TileToUnitRatio = 5;
	public GameObject TilePrefab;
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
		Vector3 scale = new Vector3 (TileToUnitRatio * SizeX, TileToUnitRatio * SizeY, 1);
		transform.localScale = scale;
	}

	void GenerateTiles() {
		for (int i = 0; i < SizeX; i++) {
			for (int j = 0; j < SizeY; j++) {
				GameObject Tile = Instantiate (TilePrefab, new Vector3 (i, j, 0) * (TileToUnitRatio/10f), Quaternion.identity) as GameObject;
//				GameObject Tile = Instantiate (TilePrefab) as GameObject;
//				Tile.transform.parent = gameObject.transform;
//				Tile.transform.transform
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
