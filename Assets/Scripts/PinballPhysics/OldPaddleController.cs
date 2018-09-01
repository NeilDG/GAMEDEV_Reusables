using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPaddleController : MonoBehaviour {

    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            this.leftPaddle.transform.Rotate(new Vector3(0.0f, 0.0f, 80.0f));
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            this.leftPaddle.transform.localRotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            this.rightPaddle.transform.Rotate(new Vector3(0.0f, 0.0f, -80.0f));
        }

        else if (Input.GetKeyUp(KeyCode.D)) {
            this.rightPaddle.transform.localRotation = Quaternion.identity;
        }
    }
}
