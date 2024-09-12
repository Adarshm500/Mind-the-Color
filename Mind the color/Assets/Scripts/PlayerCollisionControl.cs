using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    private Renderer playerRenderer;
    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Renderer collidedObjectRenderer = collision.gameObject.GetComponent<Renderer>();

        if (collidedObjectRenderer != null )
        {
            if (playerRenderer.material.color != collidedObjectRenderer.material.color)
            {
                Destroy(gameObject);
            }
        }
    }
}
