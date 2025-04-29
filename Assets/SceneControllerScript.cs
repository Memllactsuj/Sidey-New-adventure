/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
    public PlayerInventory playerInventory; // Об'єкт гравця з інвентарем
    public Transform endPoint;             // Точка кінця лабіринту
    public string nextSceneName;           // Назва наступної сцени
    public float delayBeforeSceneChange = 5f; // Затримка перед зміною сцени
    public GameObject mask; // Маска, яка закриває лабіринт
    public GameObject maze;

    private bool hasAllStones = false;      // Чи всі камені зібрані

    private void Awake()
    {
        // Забезпечуємо, щоб гравець (та його інвентар) залишався між сценами
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player); // Гравець залишається між сценами
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи гравець досяг кінця лабіринту
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Гравець досяг кінця лабіринту!");

            CheckForStones(); // Перевіряємо, чи всі камені зібрані
        }
    }

    private void CheckForStones()
    {
        // Перевірка, чи всі камені зібрані
        if (playerInventory.collectedStones >= 3)
        {
            hasAllStones = true;
            Debug.Log("Всі камені зібрані! Затримка перед зміною сцени...");
            StartCoroutine(WaitAndChangeScene());
        }
        else
        {
            Debug.Log("Не всі камені зібрані! Збирай ще камені.");
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        // Затримка перед зміною сцени
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Якщо всі камені зібрані
        if (hasAllStones)
        {
            Debug.Log("Знищуємо маску перед переходом...");
            if (mask != null)
            {
                Destroy(mask); // Знищуємо маску
            }
            if (maze != null)
            {
                Destroy(maze);
            }

            Debug.Log("Відкривається наступна сцена...");
            SceneManager.LoadScene(nextSceneName); // Завантажуємо наступну сцену
        }
        else
        {
            Debug.Log("Сцена не змінена, оскільки не всі камені зібрані.");
        }
    }
}
*/


/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
    public PlayerInventory playerInventory;  // Об'єкт гравця з інвентарем
    public Transform endPoint;              // Точка кінця лабіринту
    public string nextSceneName;            // Назва наступної сцени
    public float delayBeforeSceneChange = 2f;  // Затримка перед зміною сцени
    public GameObject mask;                // Маска, яка закриває лабіринт
    public GameObject maze;                // Лабіринт

    private bool hasAllStones = false;     // Чи всі камені зібрані

    private void Awake()
    {
        // Забезпечуємо, щоб гравець (та його інвентар) залишався між сценами
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player); // Гравець залишається між сценами
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи гравець досяг кінця лабіринту
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Гравець досяг кінця лабіринту!");
            CheckForStones(); // Перевіряємо, чи всі камені зібрані
        }
    }

    private void CheckForStones()
    {
        // Перевірка, чи всі камені зібрані
        if (playerInventory.collectedStones >= 3)
        {
            hasAllStones = true;
            Debug.Log("Всі камені зібрані! Починається затемнення...");
            StartCoroutine(WaitAndChangeScene());
        }
        else
        {
            Debug.Log("Не всі камені зібрані! Збирай ще камені.");
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        // Затримка перед зміною сцени
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Якщо всі камені зібрані
        if (hasAllStones)
        {
            Debug.Log("Знищуємо маску перед переходом...");
            if (mask != null)
            {
                Destroy(mask); // Знищуємо маску
            }
            if (maze != null)
            {
                Destroy(maze); // Знищуємо лабіринт
            }

            Debug.Log("Починаємо перехід між сценами...");
            // Викликаємо перехід на нову сцену з анімацією затемнення
            SceneTransitionController.Instance.TransitionToScene(nextSceneName);
        }
        else
        {
            Debug.Log("Сцена не змінена, оскільки не всі камені зібрані.");
        }
    }
}

*/
/*using UnityEngine;
using System.Collections;


public class SceneControllerScript : MonoBehaviour
{
    public PlayerInventory playerInventory; // Об'єкт гравця з інвентарем
    public Transform endPoint;             // Точка кінця лабіринту
    public string nextSceneName;           // Назва наступної сцени
    public GameObject mask;                // Маска, яка закриває лабіринт
    public GameObject maze;                // Лабіринт

    private bool hasAllStones = false;      // Чи всі камені зібрані

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевірка на зіткнення з гравцем (наприклад, точка кінця лабіринту)
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Гравець досяг кінця лабіринту!");

            CheckForStones(); // Перевіряємо, чи всі камені зібрані
        }
    }

    private void CheckForStones()
    {
        // Перевірка, чи всі камені зібрані
        if (playerInventory.collectedStones >= 3)
        {
            hasAllStones = true;
            Debug.Log("Всі камені зібрані! Перехід до нової сцени...");
            // Якщо всі камені зібрані, активуємо перехід зі затримкою
            StartCoroutine(WaitAndChangeScene());
        }
        else
        {
            Debug.Log("Не всі камені зібрані! Збирай ще камені.");
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        // Затримка перед початком затемнення
        yield return new WaitForSeconds(4f);

        if (hasAllStones)
        {
            // Видаляємо маску перед переходом
            if (mask != null)
            {
                Destroy(mask);
            }

            if (maze != null)
            {
                Destroy(maze);
            }

            // Викликаємо перехід між сценами з ефектом затемнення
            SceneTransitionController.Instance.TransitionToScene(nextSceneName);
        }
    }
}
*/
using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
    public PlayerInventory playerInventory; // Об'єкт гравця з інвентарем
    public Transform endPoint;             // Точка кінця лабіринту
    public string nextSceneName;           // Назва наступної сцени
    public GameObject mask;                // Маска, яка закриває лабіринт
    public GameObject maze;                // Лабіринт

    private bool hasAllStones = false;      // Чи всі камені зібрані

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевірка на зіткнення з гравцем (наприклад, точка кінця лабіринту)
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Гравець досяг кінця лабіринту!");

            CheckForStones(); // Перевіряємо, чи всі камені зібрані
        }
    }

    private void CheckForStones()
    {
        // Перевірка, чи всі камені зібрані
        if (playerInventory.collectedStones >= 3)
        {
            hasAllStones = true;
            Debug.Log("Всі камені зібрані! Перехід до нової сцени...");
            // Якщо всі камені зібрані, активуємо перехід зі затримкою
            StartCoroutine(WaitAndChangeScene());
        }
        else
        {
            Debug.Log("Не всі камені зібрані! Збирай ще камені.");
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        // Затримка перед початком затемнення
        yield return new WaitForSeconds(3f);

        if (hasAllStones)
        {
            // Видаляємо маску перед переходом
            if (mask != null)
            {
                mask.SetActive(false); // Сховати маску
            }

            if (maze != null)
            {
                Destroy(maze); // Видаляємо лабіринт
            }

            // Викликаємо перехід між сценами з ефектом затемнення
            SceneTransitionController.Instance.TransitionToScene(nextSceneName);
        }
    }
}
