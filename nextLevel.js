#pragma strict
import UnityEngine.SceneManagement;

function Awake () {
	Invoke ("nextLevel", 6);
}

function Update () {
	if(Input.anyKey){
		SceneManager.LoadScene ("main");
	}
}

function nextLevel() {
	SceneManager.LoadScene ("main");
}