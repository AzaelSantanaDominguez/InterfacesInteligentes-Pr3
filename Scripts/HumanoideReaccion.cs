
using UnityEngine;

public class HumanoideReaccion : MonoBehaviour
{
    [Header("Escudos")]
    public Transform escudoTipo1;
    public Transform[] escudosTipo2;

    [Header("Movimiento")]
    public float velocidad = 3f;

    private Transform objetivo;
    private Renderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnEnable()
    {
        GestorEventos.CuboTocaTipo1 += ReaccionarATipo1;
        GestorEventos.CuboTocaTipo2 += ReaccionarATipo2;
    }

    private void OnDisable()
    {
        GestorEventos.CuboTocaTipo1 -= ReaccionarATipo1;
        GestorEventos.CuboTocaTipo2 -= ReaccionarATipo2;
    }

    private void ReaccionarATipo1()
    {
        if (CompareTag("Tipo2"))
        {
            objetivo = BuscarEscudoTipo2MasCercano();
        }
    }

    private void ReaccionarATipo2()
    {
        if (CompareTag("Tipo1"))
        {
            objetivo = escudoTipo1;
        }
    }

    private Transform BuscarEscudoTipo2MasCercano()
    {
        Transform masCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (Transform escudo in escudosTipo2)
        {
            if (escudo == null)
                continue;

            float distancia = Vector3.Distance(
                transform.position, escudo.position);

            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                masCercano = escudo;
            }
        }

        return masCercano;
    }

    private void Update()
    {
        if (objetivo == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivo.position,
            velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EscudoTipo1") ||
            collision.gameObject.CompareTag("EscudoTipo2"))
        {
            CambiarColor();
        }
    }

    private void CambiarColor()
    {
        foreach (Renderer r in renderers)
        {
            foreach (Material m in r.materials)
            {
                m.color = Color.yellow;
            }
        }
    }
}
