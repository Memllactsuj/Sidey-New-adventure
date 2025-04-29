/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GlobalMessageManager : MonoBehaviour
{
    public static GlobalMessageManager Instance;  // Для глобального доступу
    public GameObject endMessage;                 // Кінцеве повідомлення
    public GameObject manager;
    public float displayDuration = 5f;            // Тривалість показу повідомлення
    public Canvas canvas;                         // Канвас, який потрібно зберегти

    private bool messageDisplayed = false;        // Чи було показано повідомлення

    private void Awake()
    {
        // Реалізація Singleton
        if (Instance == null)
        {
            Instance = this;

            // Переконуємось, що Canvas не буде знищуватись
            DontDestroyOnLoad(canvas.gameObject); // Зберігаємо Canvas між сценами
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);  // Запобігання дублюванню
        }
    }

    private void Start()
    {
        if (endMessage != null)
        {
            endMessage.SetActive(false);  // Ховаємо повідомлення на початку
        }
    }

    // Метод для показу кінцевого повідомлення
    public void ShowEndMessage()
    {
        if (!messageDisplayed && endMessage != null)
        {
            StartCoroutine(DisplayEndMessage());
        }
    }

    // Корутина для відображення кінцевого повідомлення
    private IEnumerator DisplayEndMessage()
    {
        messageDisplayed = true;  // Запобігаємо повторному показу
        endMessage.SetActive(true);  // Показуємо повідомлення

        yield return new WaitForSeconds(displayDuration);  // Чекаємо заданий час

        QuitGame();  // Завершуємо гру
    }

    // Метод для завершення гри
    private void QuitGame()
    {
        // У редакторі Unity:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // У готовій грі:
        Application.Quit();
#endif
    }
}
*/

/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GlobalMessageManager : MonoBehaviour
{
    public static GlobalMessageManager Instance;  // Для глобального доступу
    public GameObject endMessage;                 // Кінцеве повідомлення
    public GameObject manager;
    public float displayDuration = 5f;            // Тривалість показу повідомлення
    public Canvas canvas;                         // Канвас, який потрібно зберегти
    public float fadeDuration = 1f;               // Тривалість плавного появи/зникнення

    private bool messageDisplayed = false;        // Чи було показано повідомлення
    private CanvasGroup canvasGroup;              // CanvasGroup для керування альфою

    private void Awake()
    {
        // Реалізація Singleton
        if (Instance == null)
        {
            Instance = this;

            // Переконуємось, що Canvas не буде знищуватись
            DontDestroyOnLoad(canvas.gameObject); // Зберігаємо Canvas між сценами
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);  // Запобігання дублюванню
        }
    }

    private void Start()
    {
        if (endMessage != null)
        {
            endMessage.SetActive(false);  // Ховаємо повідомлення на початку
            canvasGroup = endMessage.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = endMessage.AddComponent<CanvasGroup>();  // Додаємо CanvasGroup, якщо його немає
            }
        }
    }

    // Метод для показу кінцевого повідомлення
    public void ShowEndMessage()
    {
        if (!messageDisplayed && endMessage != null)
        {
            StartCoroutine(DelayMessageAndShow());
        }
    }

    // Корутина для затримки перед показом кінцевого повідомлення
    private IEnumerator DelayMessageAndShow()
    {
        yield return new WaitForSeconds(4f);  // Чекаємо 4 секунди перед показом повідомлення

        messageDisplayed = true;  // Запобігаємо повторному показу
        endMessage.SetActive(true);  // Показуємо повідомлення

        // Плавно показуємо повідомлення
        yield return StartCoroutine(FadeIn());

        yield return new WaitForSeconds(displayDuration);  // Чекаємо заданий час

        // Плавно ховаємо повідомлення
        yield return StartCoroutine(FadeOut());

        QuitGame();  // Завершуємо гру
    }

    // Плавне збільшення прозорості (поява повідомлення)
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);  // Збільшуємо альфу від 0 до 1
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;  // Переконуємось, що альфа досягла 1
    }

    // Плавне зменшення прозорості (зникнення повідомлення)
    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);  // Зменшуємо альфу від 1 до 0
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;  // Переконуємось, що альфа досягла 0
        endMessage.SetActive(false);  // Ховаємо повідомлення після анімації
    }

    // Метод для завершення гри
    private void QuitGame()
    {
        // У редакторі Unity:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // У готовій грі:
        Application.Quit();
#endif
    }
}
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI; // Потрібно для роботи з UI елементами

public class GlobalMessageManager : MonoBehaviour
{
    public static GlobalMessageManager Instance;  // Для глобального доступу
    public GameObject endMessage;                 // Кінцеве повідомлення
    public GameObject manager;
    public float displayDuration = 5f;            // Тривалість показу повідомлення
    public float fadeDuration = 1f;               // Тривалість анімації затемнення
    public Canvas canvas;                         // Канвас, який потрібно зберегти

    private bool messageDisplayed = false;        // Чи було показано повідомлення

    private void Awake()
    {
        // Реалізація Singleton
        if (Instance == null)
        {
            Instance = this;

            // Переконуємось, що Canvas не буде знищуватись
            DontDestroyOnLoad(canvas.gameObject); // Зберігаємо Canvas між сценами
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);  // Запобігання дублюванню
        }
    }

    private void Start()
    {
        if (endMessage != null)
        {
            endMessage.SetActive(false);  // Ховаємо повідомлення на початку
        }
    }

    // Метод для показу кінцевого повідомлення
    public void ShowEndMessage()
    {
        if (!messageDisplayed && endMessage != null)
        {
            StartCoroutine(DisplayEndMessage());
        }
    }

    // Корутина для відображення кінцевого повідомлення з плавним появленням
    private IEnumerator DisplayEndMessage()
    {
        messageDisplayed = true;  // Запобігаємо повторному показу
        endMessage.SetActive(true);  // Показуємо повідомлення

        // Плавно змінюємо прозорість на 1 (повністю видно)
        CanvasGroup fadeGroup = endMessage.GetComponent<CanvasGroup>();
        if (fadeGroup == null)
        {
            fadeGroup = endMessage.AddComponent<CanvasGroup>();
        }
        fadeGroup.alpha = 0;

        float timeElapsed = 0;
        while (timeElapsed < fadeDuration)
        {
            fadeGroup.alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        fadeGroup.alpha = 1;  // Переконуємось, що прозорість стала 1

        yield return new WaitForSeconds(displayDuration);  // Чекаємо заданий час

        // Плавно зменшуємо прозорість до 0 (зникає)
        timeElapsed = 0;
        while (timeElapsed < fadeDuration)
        {
            fadeGroup.alpha = Mathf.Lerp(1, 0, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        fadeGroup.alpha = 0;  // Переконуємось, що прозорість стала 0

        QuitGame();  // Завершуємо гру
    }

    // Метод для завершення гри
    private void QuitGame()
    {
        // У редакторі Unity:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // У готовій грі:
        Application.Quit();
#endif
    }
}
