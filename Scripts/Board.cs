﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Board : MonoBehaviour {
	public int sizeX = 20;
	public int sizeY = 20;
	public int cultistsNumber = 4;
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
		ResetEvil ();
	}

	void CreateBackground() {
//		Vector3 scale = new Vector3 (tileToUnitRatio * sizeX, tileToUnitRatio * sizeY, 1);
		Vector3 scale = new Vector3 (sizeX, sizeY, 1);
		transform.localScale = scale;
	}

	void GenerateTiles() {
//		Vector2[] cultistPositions = GenerateCultistsPositions (cultistsNumber);
		List<Vector2> cultistPositions = GenerateCultistsPositions (cultistsNumber);

		for (int i = 0; i < sizeX; i++) {
			for (int j = 0; j < sizeY; j++) {
				Vector3 startingPoint = new Vector3 ((tilePixelSize/100 - sizeX) / 2f, (tilePixelSize/100 - sizeY) / 2f, 0);
//				Vector3 startingPoint = Vector3.zero;

				GameObject tile = Instantiate (
					tilePrefab, 
					startingPoint + (new Vector3 (i, j, tilePrefab.transform.position.z)),
					Quaternion.identity
				) as GameObject;
				tile.name = "Tile [" + i + ":" + j + "]";
				tile.transform.parent = gameObject.transform;
//
				if (cultistPositions.Contains(new Vector2(i, j))) {
					tile.GetComponent<Tile> ().state = Tile.State.cultist;
				}
			}
		}
	}

	protected List<Vector2> GenerateCultistsPositions(int quantity) {
		List<Vector2> positions = new List<Vector2>();
		Vector2 position;
		Vector2 center = new Vector2 (sizeX / 2, sizeY / 2);
		for (int i = 0; i < quantity; i++) {
			do {
				position = new Vector2 (Random.Range (0, sizeX), Random.Range (0, sizeY));
			} while (
				positions.Contains(position)
				|| Vector2.Distance (position, center) < 7
			);
			positions.Add (position);
		}
		return positions;
	}

	void DestroyTiles(){
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag ("Tile");
		foreach (GameObject Tile in Tiles) {
			DestroyImmediate (Tile);
		}
	}

	void ResetEvil() {
		EvilDispatcher dispatcher = GameObject.FindGameObjectWithTag ("Dispatcher").GetComponent<EvilDispatcher>();
		dispatcher.Reset ();
	}
}
