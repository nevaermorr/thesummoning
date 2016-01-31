using UnityEngine;
using System.Collections;

public class EvilDispatcher : MonoBehaviour {

	public int maxEvilParticles = 10;
	public int evilParticlesLeft;

	// Use this for initialization
	void Start () {
		evilParticlesLeft = maxEvilParticles;
	}
	
	public void Reset() {
		evilParticlesLeft = maxEvilParticles;
	}
}
