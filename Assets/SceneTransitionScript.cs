/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance;  // Для доступу через статичний метод
    public Image fadeImage;                             // Чорний екран для затемнення
    public float fadeDuration = 1f;                     // Тривалість ефекту

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Ініціалізація синглтона
        }
        else
        {
            Destroy(gameObject);  // Якщо вже є екземпляр, знищуємо дубль
        }
    }

    // Метод для анімації затемнення та переходу на нову сцену
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Починаємо затемнення
        yield return StartCoroutine(Fade(1f));  // Повне затемнення

        // Завантажуємо нову сцену
        SceneManager.LoadScene(sceneName);

        // Чекаємо, поки сцена завантажиться, після чого починаємо освітлення
        yield return new WaitForSeconds(0.5f);  // Підтримка часу для завантаження сцени

        // Починаємо освітлення нової сцени
        yield return StartCoroutine(Fade(0f));  // З'являється на новій сцені
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Завершуємо, щоб точно встановити цільове значення альфа-каналу
        color.a = targetAlpha;
        fadeImage.color = color;
    }
}
*/
/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance;  // Для доступу через статичний метод
    public Image fadeImage;                             // Чорний екран для затемнення
    public float fadeDuration = 1f;                     // Тривалість ефекту
    public float delayBeforeFade = 4f;
    // Затримка перед початком затемнення (4 секунди)
    private void Awake()
    {
        // Забезпечуємо, щоб гравець (та його інвентар) залишався між сценами
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player); // Гравець залишається між сценами
        }
        if (Instance == null)
        {
            Instance = this;  // Ініціалізація синглтона
        }
        else
        {
            Destroy(gameObject);  // Якщо вже є екземпляр, знищуємо дубль
        }
    }

    
    // Метод для анімації затемнення та переходу на нову сцену
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Чекаємо 4 секунди перед початком затемнення
        yield return new WaitForSeconds(delayBeforeFade);

        // Починаємо затемнення
        yield return StartCoroutine(Fade(1f));  // Повне затемнення

        // Завантажуємо нову сцену
        SceneManager.LoadScene(sceneName);

        // Чекаємо, поки сцена завантажиться, після чого починаємо освітлення
        yield return new WaitForSeconds(0.5f);  // Підтримка часу для завантаження сцени

        // Починаємо освітлення нової сцени
        yield return StartCoroutine(Fade(0f));  // З'являється на новій сцені
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Завершуємо, щоб точно встановити цільове значення альфа-каналу
        color.a = targetAlpha;
        fadeImage.color = color;
    }
}*/

/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance;  // Для доступу через статичний метод
    public Image fadeImage;                             // Чорний екран для затемнення
    public GameObject mask;                             // Маска, яка покриває лабіринт
    public float fadeDuration = 1f;                     // Тривалість ефекту
    public float delayBeforeFade = 4f;                  // Затримка перед початком затемнення (4 секунди)

    private void Awake()
    {
        // Забезпечуємо, щоб гравець (та його інвентар) залишався між сценами
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player); // Гравець залишається між сценами
        }
        if (Instance == null)
        {
            Instance = this;  // Ініціалізація синглтона
        }
        else
        {
            Destroy(gameObject);  // Якщо вже є екземпляр, знищуємо дубль
        }
    }

    // Метод для анімації затемнення та переходу на нову сцену
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Починаємо затемнення
        yield return StartCoroutine(Fade(1f));  // Повне затемнення

        // Знищуємо маску після того, як затемнення почнеться
        if (mask != null)
        {
            Destroy(mask); // Знищуємо маску
        }

        // Завантажуємо нову сцену
        SceneManager.LoadScene(sceneName);

        // Чекаємо, поки сцена завантажиться, після чого починаємо освітлення
        yield return new WaitForSeconds(0.5f);  // Підтримка часу для завантаження сцени

        // Починаємо освітлення нової сцени
        yield return StartCoroutine(Fade(0f));  // З'являється на новій сцені
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Завершуємо, щоб точно встановити цільове значення альфа-каналу
        color.a = targetAlpha;
        fadeImage.color = color;
    }

    private IEnumerator FadeMask(float targetAlpha)
    {
        // Перевірка, чи маска є
        if (mask != null)
        {
            Image maskImage = mask.GetComponent<Image>();
            if (maskImage != null)
            {
                Color maskColor = maskImage.color;
                float startAlpha = maskColor.a;
                float elapsedTime = 0f;

                while (elapsedTime < fadeDuration)
                {
                    elapsedTime += Time.deltaTime;
                    maskColor.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
                    maskImage.color = maskColor;
                    yield return null;
                }

                // Завершуємо, щоб точно встановити цільове значення альфа-каналу
                maskColor.a = targetAlpha;
                maskImage.color = maskColor;
            }
        }
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance; // Singleton для доступу до скрипта
    public Image fadeImage;                           // Чорний екран
    public float fadeDuration = 1f;                   // Тривалість затемнення

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player); // Гравець залишається між сценами
        }
        // Забезпечуємо, щоб об'єкт залишався між сценами
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не знищувати Canvas при завантаженні нової сцени
        }
        else
        {
            Destroy(gameObject); // Уникнення дублювання об'єктів
        }
    }

    // Перехід до нової сцени
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndSwitchScenes(sceneName));
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        // Починаємо затемнення
        yield return StartCoroutine(Fade(1f));  // Повне затемнення

        // Завантаження нової сцени
        SceneManager.LoadScene(sceneName);

        // Чекаємо 0.5 секунди для стабілізації
        yield return new WaitForSeconds(0.5f);

        // Починаємо освітлення нової сцени
        yield return StartCoroutine(Fade(0f));  // З'являється на новій сцені
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color currentColor = fadeImage.color;
        float startAlpha = currentColor.a;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }

        // Фіксуємо фінальне значення альфа-каналу
        fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }
}

