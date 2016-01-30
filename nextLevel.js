#pragma strict

function Awake () {
	Invoke ("nextLevel", 6);
}

function Update () {
	if(Input.anyKey){
		Application.LoadLevel (1);
	}
}

function nextLevel() {
	Application.LoadLevel (1);
}