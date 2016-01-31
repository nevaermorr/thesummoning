#pragma strict


public var menu: GameObject;

function Start () {
	menu = GameObject.FindWithTag("Menu");
}

function OnMouseDown() {
	menu.transform.position.z = 1;
}