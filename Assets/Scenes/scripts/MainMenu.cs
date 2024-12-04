using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para iniciar el juego
    public void PlayGame()
    {
        // Cambia "GameScene" por el nombre de la escena que quieras cargar
        SceneManager.LoadScene("GameScene");
    }

    // Método para abrir las opciones
    public void OpenOptions()
    {
        // Aquí puedes implementar la lógica para mostrar un panel de opciones
        Debug.Log("Abriendo opciones...");
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
