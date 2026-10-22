
using System;
using UnityEngine;

public class GestorEventos : MonoBehaviour
{
    public static event Action CuboTocaTipo1;
    public static event Action CuboTocaTipo2;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("¡CHOQUE! Objeto: " +
            collision.gameObject.name +
            " | Tag: " + collision.gameObject.tag);

        Transform objeto = collision.transform;

        if (objeto.CompareTag("Tipo1") ||
            objeto.root.CompareTag("Tipo1"))
        {
            Debug.Log("¡Humanoide tipo 1 detectado!");
            CuboTocaTipo1?.Invoke();
        }
        else if (objeto.CompareTag("Tipo2") ||
                 objeto.root.CompareTag("Tipo2"))
        {
            Debug.Log("¡Humanoide tipo 2 detectado!");
            CuboTocaTipo2?.Invoke();
        }
    }
}
