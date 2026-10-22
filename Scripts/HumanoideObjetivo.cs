
using UnityEngine;

public class HumanoideObjetivo : MonoBehaviour
{
    [Header("Objetivos")]
    public Transform escudoObjetivo;
    public Transform objetoMirar;

    [Header("Orientacion")]
    public float velocidadGiro = 180f;

    private bool activado = false;

    private void OnEnable()
    {
        AproximacionCubo.AlAproximarse += Reaccionar;
    }

    private void OnDisable()
    {
        AproximacionCubo.AlAproximarse -= Reaccionar;
    }

    private void Reaccionar()
    {
        if (CompareTag("Tipo1"))
        {
            if (escudoObjetivo != null)
            {
                transform.position = escudoObjetivo.position;
            }
        }
        else if (CompareTag("Tipo2"))
        {
            activado = true;
        }
    }

    private void Update()
    {
        if (!activado || objetoMirar == null)
            return;

        Vector3 direccion =
            objetoMirar.position - transform.position;

        direccion.y = 0f;

        if (direccion.sqrMagnitude > 0.001f)
        {
            Quaternion rotacionObjetivo =
                Quaternion.LookRotation(direccion);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacionObjetivo,
                velocidadGiro * Time.deltaTime
            );
        }
    }
}
