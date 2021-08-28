using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] string NextScene;

    private void OnTriggerEnter(Collider other)
    {   
        //check if name tag "Player" colided with Finishline object
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
