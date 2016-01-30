#pragma strict
import UnityEngine.SceneManagement;

function Awake () {
	Invoke ("NextLevel", 6);
}

function Update () {
	if(Input.anyKey) {
		NextLevel();
	}
}

function NextLevel() {
	SceneManager.LoadScene("main");
}