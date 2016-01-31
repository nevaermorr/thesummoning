#pragma strict

function OnMouseDown() {
if (transform.position.z < 0)
	transform.position.z = transform.position.z * -1.0;
}