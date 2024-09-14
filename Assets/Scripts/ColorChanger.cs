using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Transform newColorTransform;
    private Renderer newRenderer;
    private void Start()
    {
        newRenderer = newColorTransform.GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Renderer playerRenderer = other.gameObject.GetComponent<Renderer>();

        if (playerRenderer != null)
        {
            playerRenderer.material.color = newRenderer.material.color;
        }
    }
}
