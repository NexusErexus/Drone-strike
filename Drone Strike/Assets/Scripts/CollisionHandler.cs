using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{name} collided with {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log($"{name} triggered with {collision.gameObject.name}");
        DisableMovement();
        Invoke(nameof(ReloadCurrentScene), 1f);
    }

    private bool DestroyPlayer()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
    private void DisableMovement()
    {
        GetComponent<PlayerController>().enabled = false;
    }


    private void ReloadCurrentScene()
    {
        int indexOfCurrentScene = GetIndexScene();
        SceneManager.LoadScene(indexOfCurrentScene);
    }

    private int GetIndexScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}