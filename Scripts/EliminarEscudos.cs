
using UnityEngine;

public class EliminarEscudos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscudoTipo1") ||
            other.CompareTag("EscudoTipo2"))
        {
            Destroy(other.gameObject);
        }
    }
}
