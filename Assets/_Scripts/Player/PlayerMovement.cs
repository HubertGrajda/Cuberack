using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float slowingDownValue = 0.1f;
    [SerializeField] private float boundarySlowingDownValue = 0.2f;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    private Animator anim;
    private const string rotateAnim = "Rotate";

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        CameraBoundariesSlow();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            rb.AddForce(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            rb.AddForce(speed, 0, 0);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), slowingDownValue);

        }
    }
    void CameraBoundariesSlow()
    {

        if (transform.position.x < minX)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), boundarySlowingDownValue);
            anim.SetInteger(rotateAnim, 1);
        }
        else if (transform.position.x > maxX)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), boundarySlowingDownValue);
            anim.SetInteger(rotateAnim, -1);
        }
        else
        {
            anim.SetInteger(rotateAnim, 0);
        }

    }
    public void SpeedBoostInit(float additionalSpeed, float boostTime)  //cannot start coroutine in SO
    {
        StartCoroutine(SpeedBoost(additionalSpeed, boostTime));
    }

    private IEnumerator SpeedBoost(float additionalSpeed, float boostTime)
    {
        speed += additionalSpeed;
        yield return new WaitForSeconds(boostTime);
        Debug.Log("End of speed boost :(");
        speed -= additionalSpeed;
    }
}
