using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 2f;

    private void LateUpdate()
    {
        transform.position += new Vector3(0, 0, cameraSpeed * Time.deltaTime);
    }
}
