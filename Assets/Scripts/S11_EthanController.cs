using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] //FSM counterpart
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class S11_EthanController : MonoBehaviour
{
    private const string ETHAN_SPEED_KEY = "EthanSpeed";
    private const string ETHAN_JUMP_KEY = "Jump";
    private const string ETHAN_FORWARD_KEY = "Forward";
    private const string ETHAN_TURN_KEY = "Turn";

    private const float TURN_AMOUNT_MAGNIFIER = 200.0f;
    private const float FORWARD_MULTIPLIER = 2.0f;
    private const float TURN_MULTIPLIER = 2.0f;

    private float forwardSpeed = 0.0f;
    private float turnSpeed = 0.0f;
    private KeyCode lastTurnPress;

    private Animator ethanAnimator;
    // Start is called before the first frame update
    void Start()
    {
        this.ethanAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //run
                if (this.forwardSpeed < 1.0f)
                {
                    this.forwardSpeed += Time.deltaTime * FORWARD_MULTIPLIER;
                }
                this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);
            }
            else
            {
                //walk
                if (this.forwardSpeed < 0.5f)
                {
                    this.forwardSpeed += Time.deltaTime * FORWARD_MULTIPLIER;
                    this.forwardSpeed = Mathf.Clamp(this.forwardSpeed, 0.0f, 0.5f);
                }
                else if (this.forwardSpeed > 0.5f)
                {
                    this.forwardSpeed -= Time.deltaTime * FORWARD_MULTIPLIER;
                }

                this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);
            }
        }
        else
        {
            if (this.forwardSpeed > 0.0f)
            {
                this.forwardSpeed -= Time.deltaTime * FORWARD_MULTIPLIER;
                this.forwardSpeed = Mathf.Clamp(this.forwardSpeed, 0.0f, 1.0f);
            }

            this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.turnSpeed > -1.0f)
            {
                this.turnSpeed -= Time.deltaTime * TURN_MULTIPLIER;
            }

            transform.Rotate(Vector3.up * Time.deltaTime * TURN_AMOUNT_MAGNIFIER, Space.World);
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);

            this.lastTurnPress = KeyCode.D;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (this.turnSpeed < 1.0f)
            {
                this.turnSpeed += Time.deltaTime * TURN_MULTIPLIER;
            }

            transform.Rotate(Vector3.down * Time.deltaTime * TURN_AMOUNT_MAGNIFIER, Space.World);
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);

            this.lastTurnPress = KeyCode.A;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.ethanAnimator.SetTrigger(ETHAN_JUMP_KEY);
        }

        //if user is not pressing any turn, reduce turn speed gradually.
        if (this.turnSpeed < 0.0f && !Input.GetKey(KeyCode.D) && this.lastTurnPress == KeyCode.D)
        {
            this.turnSpeed += Time.deltaTime * TURN_MULTIPLIER;
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);
        }
        else if (this.turnSpeed > 0.0f && !Input.GetKey(KeyCode.A) && this.lastTurnPress == KeyCode.A)
        {
            this.turnSpeed -= Time.deltaTime * TURN_MULTIPLIER;
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);
        }
    }
}
