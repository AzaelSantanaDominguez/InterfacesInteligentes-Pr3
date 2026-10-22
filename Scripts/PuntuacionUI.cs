
using UnityEngine;
using TMPro;

public class PuntuacionUI : MonoBehaviour
{
    public TMP_Text textoPuntuacion;

    private int puntuacion = 0;

    private void OnTriggerEnter(Collider other)
    {
        ProcesarObjeto(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ProcesarObjeto(collision.gameObject);
    }

    private void ProcesarObjeto(GameObject objeto)
    {
        if (objeto.CompareTag("EscudoTipo1"))
        {
            puntuacion += 5;
        }
        else if (objeto.CompareTag("EscudoTipo2"))
        {
            puntuacion += 10;
        }
        else
        {
            return;
        }

        textoPuntuacion.text = "Puntuación: " + puntuacion;
        Debug.Log("Puntuación: " + puntuacion);

        Destroy(objeto);
    }
}
