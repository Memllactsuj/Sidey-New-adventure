using UnityEngine;

public class CheckCollectedStones : MonoBehaviour
{
    public GameObject messageCollectedAll;    // Повідомлення, якщо всі камені зібрані
    public GameObject messageMissingStones;   // Повідомлення, якщо камені не всі зібрані
    public PlayerInventory playerInventory;   // Посилання на інвентар гравця

    private void Start()
    {
        // Ховаємо обидва повідомлення на старті
        if (messageCollectedAll != null) messageCollectedAll.SetActive(false);
        if (messageMissingStones != null) messageMissingStones.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Перевіряємо, чи гравець увійшов у тригер
        {
            if (playerInventory.HasCollectedAllStones())
            {
                // Усі камені зібрані - показуємо відповідне повідомлення
                if (messageCollectedAll != null) messageCollectedAll.SetActive(true);
            }
            else
            {
                // Камені ще не всі зібрані - показуємо інше повідомлення
                if (messageMissingStones != null) messageMissingStones.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Перевіряємо, чи гравець вийшов із тригера
        {
            // Ховаємо обидва повідомлення
            if (messageCollectedAll != null) messageCollectedAll.SetActive(false);
            if (messageMissingStones != null) messageMissingStones.SetActive(false);
        }
    }
}
