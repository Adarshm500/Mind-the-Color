using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayInView : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float playerMinZThreshold = 2f; // player does not go past this threshold

    private void Update()
    {
        if (transform.position.z < cameraTransform.position.z + playerMinZThreshold)
        {
            transform.position = new Vector3
            (
                transform.position.x, 
                transform.position.y,
                cameraTransform.position.z + playerMinZThreshold
            );
        }
    }
}
