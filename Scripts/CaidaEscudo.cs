
using UnityEngine;

public class CaidaEscudo : MonoBehaviour
{
    public float velocidadCaida = 3f;

    void Update()
    {
        transform.Translate(
            Vector3.down * velocidadCaida * Time.deltaTime,
            Space.World
        );
    }
}
