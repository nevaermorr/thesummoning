using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour {

	void OnMouseDown() {
		GameObject board = GameObject.FindGameObjectWithTag ("Board");

//		board.GetComponent<Board> ().cultistsNumber = 

		board.GetComponent<Board> ().Regenerate();


//		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
