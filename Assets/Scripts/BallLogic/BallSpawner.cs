using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	[SerializeField] private GameObjectPool objectPool;

	private const float SPAWN_DELAY = 0.25f;
	private float ticks = 0.0f;

	// Use this for initialization
	void Start () {
		this.objectPool.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		this.ticks += Time.deltaTime;

		if (this.ticks >= SPAWN_DELAY) {
			this.ticks = 0.0f;

			int numObjects = Random.Range (1, 5);
			this.objectPool.RequestPoolableBatch (numObjects);
		}
	}
}
