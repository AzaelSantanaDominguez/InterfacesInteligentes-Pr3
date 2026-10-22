
using UnityEngine;

public class Ej1Esferas : MonoBehaviour
{
    public Transform objetivoTipo2;
    public Transform cilindro;
    public float velocidad = 3f;

    private bool activada = false;

    private void OnEnable()
    {
        ej1Cilindro.AlChocarConCubo += Reaccionar;
    }

    private void OnDisable()
    {
        ej1Cilindro.AlChocarConCubo -= Reaccionar;
    }

    private void Reaccionar()
    {
        activada = true;
    }

    private void Update()
    {
        if (!activada)
            return;

        Transform objetivo = null;

        if (CompareTag("Tipo1"))
        {
            objetivo = objetivoTipo2;
        }
        else if (CompareTag("Tipo2"))
        {
            objetivo = cilindro;
        }

        if (objetivo != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                objetivo.position,
                velocidad * Time.deltaTime
            );
        }
    }
}
