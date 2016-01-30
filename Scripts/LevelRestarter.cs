using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour {

	void OnMouseDown() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
