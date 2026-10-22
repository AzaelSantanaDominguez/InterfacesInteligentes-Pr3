
using System;
using UnityEngine;

public class ej1Cilindro : MonoBehaviour
{
    public static event Action AlChocarConCubo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            AlChocarConCubo?.Invoke();
        }
    }
}

