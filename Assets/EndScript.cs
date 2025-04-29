using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Викликаємо кінцеве повідомлення через глобальний менеджер
            GlobalMessageManager.Instance.ShowEndMessage();
        }
    }
}
