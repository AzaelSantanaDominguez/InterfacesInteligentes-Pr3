
using UnityEngine;

public class MoverCubo : MonoBehaviour
{
    public float velocidad = 16f;
    public float limiteIzquierdo = -8f;
    public float limiteDerecho = 8f;

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");

        Vector3 posicion = transform.position;

        posicion.x += movimiento * velocidad * Time.deltaTime;

        posicion.x = Mathf.Clamp(
            posicion.x,
            limiteIzquierdo,
            limiteDerecho
        );

        transform.position = posicion;
    }
}
