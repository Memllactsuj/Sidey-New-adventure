using UnityEngine;

public class ShowBlueAndMoveScript : MonoBehaviour
{
    public Transform targetObject; // Об'єкт, до якого рухається персонаж
    public GameObject textSprite;  // Текст (або картинка) над персонажем
    public float moveSpeed = 2f;   // Швидкість руху персонажа
    public float activationDistance = 1f;   // Відстань для активації тексту
    public float deactivationDistance = 2f; // Відстань, на якій текст зникає

    private Vector2 objectPosition; // Координати об'єкта
    private bool objectCollected = false; // Чи зібрано об'єкт
    private bool isTextVisible = false; // Чи видимий текст

    void Start()
    {
        // Ховаємо текст на початку гри
        if (textSprite != null)
        {
            textSprite.SetActive(false);
        }

        if (targetObject != null)
        {
            objectPosition = targetObject.position; // Запам'ятовуємо координати об'єкта
        }
    }

    void Update()
    {
        // Вираховуємо дистанцію до об'єкта або його попередньої позиції
        float distanceToTarget = Vector2.Distance(transform.position, objectPosition);

        // Якщо персонаж у межах активації тексту, показуємо текст
        if (distanceToTarget < activationDistance && !isTextVisible && !objectCollected)
        {
            ShowTextSprite();
        }

        // Якщо персонаж віддаляється від об'єкта або його точки після зникнення, ховаємо текст
        if (isTextVisible && distanceToTarget > deactivationDistance)
        {
            // HideTextSprite();
            if (textSprite != null)
            {
                Destroy(textSprite);  // Знищуємо текст повністю
            }

        }

        // Якщо персонаж досягає об'єкта
        if (distanceToTarget < 0.1f && !objectCollected)
        {
            CollectObject(); // Збираємо об'єкт
        }
    }

    void ShowTextSprite()
    {
        if (textSprite != null && !isTextVisible)
        {
            textSprite.SetActive(true); // Показуємо текст
            isTextVisible = true;       // Позначаємо, що текст видимий
        }
    }

    void CollectObject()
    {
        if (targetObject != null)
        {
            objectPosition = targetObject.position;  // Зберігаємо позицію об'єкта
            Destroy(targetObject.gameObject);        // Знищуємо об'єкт
            objectCollected = true;                 // Позначаємо, що об'єкт зібрано

            if (textSprite != null)
            {
                Destroy(textSprite);  // Знищуємо текст повністю
            }

            Debug.Log("Об'єкт зібрано та текст знищено!");
        }
    }
}