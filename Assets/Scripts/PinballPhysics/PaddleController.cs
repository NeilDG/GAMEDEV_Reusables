using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    [SerializeField] private PaddleForce leftPaddleForce;
    [SerializeField] private PaddleForce rightPaddleForce;

    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;

    private float ticks = 0.0f;
    private const float INPUT_DELAY = 0.25f;

    private bool readInput = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.ticks > INPUT_DELAY) {
            this.ticks = 0.0f;
            this.readInput = false;
        }
        else {
            this.ticks += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A) && !this.readInput) {
            this.readInput = true;
            this.leftPaddle.Rotate(0.0f, 0.0f, 80.0f);
            this.leftPaddleForce.SetInputToggle(true);
        }
        else if(Input.GetKeyUp(KeyCode.A)) {
            this.leftPaddle.localRotation = Quaternion.identity;
            this.leftPaddleForce.SetInputToggle(false);
        }

        if(Input.GetKeyDown(KeyCode.D) && !this.readInput) {
            this.readInput = true;
            this.rightPaddle.Rotate(0.0f, 0.0f, -80.0f);
            this.rightPaddleForce.SetInputToggle(true);
        }

        else if (Input.GetKeyUp(KeyCode.D)) {
            this.rightPaddle.localRotation = Quaternion.identity;
            this.rightPaddleForce.SetInputToggle(false);
        }

       
    }
}
