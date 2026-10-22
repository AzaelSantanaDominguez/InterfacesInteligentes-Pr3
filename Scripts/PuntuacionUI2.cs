
using UnityEngine;
using TMPro;

public class PuntuacionUI2 : MonoBehaviour
{
    public TMP_Text textoPuntuacion;
    public TMP_Text textoRecompensa;

    private int puntuacion = 0;
    private int siguienteRecompensa = 100;

    private void Start()
    {
        textoPuntuacion.text = "Puntuación: " + puntuacion;
        textoRecompensa.text = "";
    }

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

        if (puntuacion >= siguienteRecompensa)
        {
            textoRecompensa.text =
                "¡Recompensa desbloqueada! Has llegado a " + siguienteRecompensa + " puntos.";

            Debug.Log("¡Recompensa desbloqueada!");

            siguienteRecompensa += 100;
        }

        Destroy(objeto);
    }
}
