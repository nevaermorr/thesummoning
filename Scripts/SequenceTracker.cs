using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class SequenceTracker {

//	protected string[] sequences;
	protected string prevSequence;

	protected string SequenceToString(List<Tile> tiles) {
		SortedDictionary<string, string> tileDictionary = new SortedDictionary<string, string>();

		foreach (Tile tile in tiles) {
			string index = tile.transform.position.x
				+ "-"
				+ tile.transform.position.y;
			string value = tile.state.ToString ();
			tileDictionary.Add (index, value);
		}

		string sequence = "";
		foreach (KeyValuePair<string, string> pair in tileDictionary) {
			sequence += pair.Key + "-" + pair.Value + " ";
		}
		return sequence;
	}

	public bool isPrevSequence(List<Tile> tiles) {
		string sequence = SequenceToString (tiles);
		bool answer = (sequence == prevSequence);
		prevSequence = sequence;
		return answer;
	}
}
