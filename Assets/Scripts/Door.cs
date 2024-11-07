using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad; // Nome della scena da caricare
    private bool isPlayerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the door area."); // Questo dovrebbe stampare nella console
        }
        else
        {
            Debug.Log("Object entered the door area: " + other.name); // Stampa il nome dell'oggetto entrato
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited the door area.");
            GameController gameController = GameObject.FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.SetState(GameState.FreeRoam);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Player pressed Z - loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
