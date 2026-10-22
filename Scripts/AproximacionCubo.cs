using System;
using UnityEngine;

public class AproximacionCubo : MonoBehaviour
{
    public Transform objetoReferencia;
    public float distanciaActivacion = 2f;

    public static event Action AlAproximarse;

    private bool activado = false;

    void Update()
    {
        if (activado || objetoReferencia == null)
            return;

        float distancia = Vector3.Distance(
            transform.position,
            objetoReferencia.position
        );

        if (distancia <= distanciaActivacion)
        {
            activado = true;
            AlAproximarse?.Invoke();
            Debug.Log("¡El cubo se ha aproximado al objeto!");
        }
    }
}