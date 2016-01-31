using UnityEngine;
using System.Collections;

public class MenuHover : MonoBehaviour {

	public SpriteRenderer rend;
	public int level;
	public Board board;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<SpriteRenderer> ();
		rend.enabled = false;
		board = GameObject.FindWithTag ("Board").GetComponent<Board>();
		menu = GameObject.FindWithTag ("Menu");

	}

	void OnMouseEnter() {
		rend.enabled = true;
	}

	void OnMouseExit() {
		rend.enabled = false;
	}

	void OnMouseDown() {
		board.cultistsNumber = level;
		board.Regenerate ();
		Vector3 pos = menu.transform.position;
		pos.z = 500;
		menu.transform.position = pos;
	}

}

