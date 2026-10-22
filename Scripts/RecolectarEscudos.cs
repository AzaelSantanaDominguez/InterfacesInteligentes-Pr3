
using UnityEngine;

public class RecolectarEscudos : MonoBehaviour
{
    private int puntuacion = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscudoTipo1"))
        {
            puntuacion += 5;
            Destroy(other.gameObject);
            MostrarPuntuacion();
        }
        else if (other.CompareTag("EscudoTipo2"))
        {
            puntuacion += 10;
            Destroy(other.gameObject);
            MostrarPuntuacion();
        }
    }

    private void MostrarPuntuacion()
    {
        Debug.Log("Puntuación del jugador: " + puntuacion);
    }
}
