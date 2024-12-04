using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI

public class Core : MonoBehaviour
{
    public float defenseTime = 60f; // Tiempo total para defender el núcleo
    private float currentProgress = 0f; // Progreso actual (tiempo defendido)
    public float regressionRate = 2f; // Cuánto se retrasa el progreso por segundo al ser atacado
    public bool isUnderAttack = false; // Indica si está siendo atacado

    [Header("UI Elements")]
    public Text progressText; // El Text que muestra el progreso
    public Text victoryText; // El Text que muestra el mensaje de victoria

    void Start()
    {
        // Asegura que el mensaje de victoria esté oculto al inicio
        victoryText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isUnderAttack)
        {
            // Incrementa el progreso cuando no está bajo ataque
            currentProgress += Time.deltaTime;
        }
        else
        {
            // Retrasa el progreso cuando está bajo ataque
            currentProgress -= regressionRate * Time.deltaTime;
            if (currentProgress < 0f) currentProgress = 0f; // Evita valores negativos
        }

        // Actualizar el texto del progreso
        progressText.text = $"Progreso: {currentProgress:F2}/{defenseTime}";

        // Verificar si el progreso ha alcanzado el objetivo
        if (currentProgress >= defenseTime)
        {
            Win();
        }
    }

    private void Win()
    {
        // Mostrar mensaje de victoria
        victoryText.text = "¡Felicidades! Has defendido el núcleo con éxito y el Proceso se Completo con Exito.";
        victoryText.gameObject.SetActive(true); // Hacer visible el mensaje

        Debug.Log("¡Has defendido el núcleo con éxito!");
        
        // Pausa el juego al ganar
        Time.timeScale = 0; // Pausa el juego
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isUnderAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isUnderAttack = false;
        }
    }
}
