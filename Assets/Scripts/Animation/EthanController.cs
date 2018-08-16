using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EthanController : MonoBehaviour {

    private const string ETHAN_SPEED_KEY = "EthanSpeed";
    private const string ETHAN_JUMP_KEY = "Jump";

    [SerializeField] private Animator ethanAnimator;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) {
            if(Input.GetKey(KeyCode.LeftShift)) {
                //run
                this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 5);
            }
            else {
                //walk
                this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 2);
                
            }
        }
        else {
            this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            this.ethanAnimator.SetTrigger(ETHAN_JUMP_KEY);
        }
	}
}
