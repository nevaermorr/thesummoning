using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BoardGenerator : MonoBehaviour {
	public GameObject Tile;
	public int SizeX = 20;
	public int SizeY = 20;
	public float TileRatio = 0.5f;
	// Use this for initialization
	void Start () {
		DestroyTiles ();
		Generate ();
	}

	void Generate() {
		for (int i = 0; i < SizeX; i++) {
			for (int j = 0; j < SizeY; j++) {
				Instantiate(Tile, new Vector3(i,j,0)*TileRatio, Quaternion.identity);
			}
		}
	}

	void DestroyTiles(){
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag ("Tile");
		foreach (GameObject Tile in Tiles) {
			DestroyImmediate (Tile);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
