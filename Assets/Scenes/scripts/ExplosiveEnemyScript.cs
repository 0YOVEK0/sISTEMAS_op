using UnityEngine;
using System.Collections;

public class ExplosiveEnemyScript : MonoBehaviour
{
    float randomTime;
    bool routineStarted = false;

    // Flag para saber si debe explotar
    public bool explode = false;

    [Header("Prefabs")]
    public Transform explosionPrefab;
    public Transform destroyedEnemyPrefab;

    [Header("Customizable Options")]
    public float minTime = 0.05f;
    public float maxTime = 0.25f;

    [Header("Explosion Options")]
    public float explosionRadius = 12.5f;
    public float explosionForce = 4000.0f;

    private void Update()
    {
        randomTime = Random.Range(minTime, maxTime);

        if (explode)
        {
            if (!routineStarted)
            {
                StartCoroutine(Explode());
                routineStarted = true;
            }
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(randomTime);

        // Cambiar modelo a destrucción
        Instantiate(destroyedEnemyPrefab, transform.position, transform.rotation);

        // Aplicar fuerza de explosión
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce * 50, explosionPos, explosionRadius);

            // Si golpea a otro enemigo explosivo
            if (hit.transform.tag == "ExplosiveEnemy")
            {
                hit.transform.gameObject.GetComponent<ExplosiveEnemyScript>().explode = true;
            }

            // Otros efectos pueden ir aquí...
        }

        // Instanciar efecto de explosión
        RaycastHit checkGround;
        if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
        {
            Instantiate(explosionPrefab, checkGround.point,
                Quaternion.FromToRotation(Vector3.forward, checkGround.normal));
        }

        // Destruir enemigo
        Destroy(gameObject);
    }
}
