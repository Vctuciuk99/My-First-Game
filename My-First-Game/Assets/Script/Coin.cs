using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {   
        //rotate coins on y axis
        transform.Rotate(new Vector3 (0,0,1)*  Time.deltaTime * rotationSpeed);

    }
    private void OnTriggerEnter(Collider other)
    {
        // make coin disappear once collided to player
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
