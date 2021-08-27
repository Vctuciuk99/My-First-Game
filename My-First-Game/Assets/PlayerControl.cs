using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float speedRotation;
    [SerializeField] float jumpForce;
    private Rigidbody rb;
    private bool onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move forward backward
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);

        //rotate player
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * Time.deltaTime * speedRotation);

        //Player jump
        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Player is on platform");
            onPlatform = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Player exited platform");
            onPlatform = false;
        }
    }

}
