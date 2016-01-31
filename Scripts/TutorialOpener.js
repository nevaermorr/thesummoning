#pragma strict

public var tutorial: GameObject;

function Start () {
	tutorial = GameObject.FindWithTag("Tutorial");
}

function OnMouseDown() {
	tutorial.transform.position.z = tutorial.transform.position.z * -1.0;
}