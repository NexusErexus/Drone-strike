using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem death_explosion;
    [SerializeField] MeshRenderer player_ship_mesh;
    [SerializeField] AudioSource death_sfx;
    private void Awake()
    {
        death_explosion.Stop();
        death_sfx.Stop();
        player_ship_mesh.enabled = true;
    }
    private void Start()
    {
        //playership_death_explosion.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{name} collided with {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log($"{name} triggered with {collision.gameObject.name}");
        StartCrushSequence();
        DisableMovement();
        
        Invoke(nameof(ReloadCurrentScene), 2f);
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

    private void StartCrushSequence()
    {
        death_explosion.Play();
        death_sfx.Play();
        player_ship_mesh.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
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