using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad del enemigo
    public Transform core; // Referencia al núcleo
    public float attackRange = 1.5f; // Distancia para atacar el núcleo

    private void Update()
    {
        // Moverse hacia el núcleo
        if (core != null)
        {
            Vector3 direction = (core.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotar hacia el núcleo
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("core"))
        {
            AttackCore();
        }
    }

    private void AttackCore()
    {
        Debug.Log("El enemigo está atacando el núcleo.");
        // Aquí puedes incluir lógica extra si necesitas animaciones o efectos
    }
}
