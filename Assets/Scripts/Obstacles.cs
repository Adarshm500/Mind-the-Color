using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
