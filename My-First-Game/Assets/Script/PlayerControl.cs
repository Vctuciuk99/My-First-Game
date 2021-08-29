using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float speedRotation;
    [SerializeField] float jumpForce;
    
    
    public MeshRenderer shades, bag;

    private Rigidbody rb;
    private int jumpCount;

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

        //make player jump
        if (Input.GetButtonDown("Jump"))
        {
            jump(); 
        }
        
    }
    //set counter for double jump
    private void jump()
    {
        jumpCount += 1;
        if (jumpCount < 2)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        
    }
    //prevent player from infinite jumping
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
    }
  
}
