using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	public Sprite winScreen;
	public Sprite lossScreen;

	public void Win() {
		GetComponent<SpriteRenderer> ().sprite = winScreen;
		Invoke ("ShowScreen", 2);
	}
	public void Loss() {
		GetComponent<SpriteRenderer> ().sprite = lossScreen;
		Invoke ("ShowScreen", 2);
	}

	protected void ShowScreen (){
		Vector3 position = transform.position;
		position.z = position.z * -1.0f;
		transform.position = position;
	}

	void OnMouseDown() {
		Vector3 position = transform.position;
		position.z = 50.0f;
		transform.position = position;
		GameObject menu = GameObject.FindGameObjectWithTag ("Menu");
		Vector3 menuPosition = menu.transform.position;
		menuPosition.z = 1;
		menu.transform.position = menuPosition;
	}
}
