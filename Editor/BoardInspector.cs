
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Board))]
public class BoardInspector : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		// Add button for re-genarating map
		if (GUILayout.Button("Generate board")) {
			Board board = (Board)target;
			board.Regenerate();
		}
	}
}