using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollisionControl : MonoBehaviour
{
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        Renderer collidedObjectRenderer = collision.gameObject.GetComponent<Renderer>();

        if (collidedObjectRenderer != null)
        {
            if (playerRenderer.material.color != collidedObjectRenderer.material.color)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
