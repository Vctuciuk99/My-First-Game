using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private Transform player; //reference to player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(playerout());
        }
    }
   
    IEnumerator playerout()
    {
        //disable player mesh
        player.GetComponent<MeshRenderer>().enabled = false;

        //reference for player script
        PlayerControl playerControls = player.GetComponent<PlayerControl>();
        playerControls.shades.enabled = false;
        playerControls.bag.enabled = false;
        playerControls.enabled = false;

        //wait 2 sec before respawn
        yield return new WaitForSeconds(2f);
        //respawn player
        player.transform.position = new Vector3(0, 1.03f, 0);
        player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));//reset rotation
        //enable player mesh and control
        player.GetComponent<MeshRenderer>().enabled = true;
        playerControls.shades.enabled = true;
        playerControls.bag.enabled = true;
        playerControls.enabled = true;//enable playor controls again
    }
}

   
