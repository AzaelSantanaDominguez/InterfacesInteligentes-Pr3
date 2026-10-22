
using UnityEngine;

public class Ej1Cubo : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = new Vector3(x, 0f, z);

        transform.position += movimiento.normalized
            * velocidad * Time.deltaTime;
    }
}
