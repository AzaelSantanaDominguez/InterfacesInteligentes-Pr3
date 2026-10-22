
using UnityEngine;

public class GeneradorEscudos : MonoBehaviour
{
    public GameObject escudoTipo1;
    public GameObject escudoTipo2;
    public Transform areaSpawn;

    public float intervalo = 1.5f;
    public float alturaSobrePlano = 10f;

    void Start()
    {
        InvokeRepeating(nameof(CrearEscudo), 1f, intervalo);
    }

    void CrearEscudo()
    {
        if (areaSpawn == null)
        {
            Debug.LogWarning("Asigna el plano AreaSpawn.");
            return;
        }

        // Calcula una posición aleatoria dentro del plano
        Vector3 escala = areaSpawn.lossyScale;

        float x = Random.Range(-5f * escala.x, 5f * escala.x);
        float z = Random.Range(-5f * escala.z, 5f * escala.z);

        Vector3 posicion = areaSpawn.position
            + areaSpawn.right * x
            + areaSpawn.forward * z
            + Vector3.up * alturaSobrePlano;

        GameObject prefab = Random.value < 0.5f
            ? escudoTipo1
            : escudoTipo2;

        if (prefab != null)
        {
            Instantiate(prefab, posicion, prefab.transform.rotation);
        }
    }
}
