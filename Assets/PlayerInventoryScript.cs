using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int collectedStones = 0; // Лічильник зібраних каменів
    public int totalStones = 3;     // Загальна кількість каменів в грі

    public void CollectStone()
    {
        collectedStones++; // Збільшуємо лічильник зібраних каменів
        Debug.Log("Камінь зібрано! Загальна кількість: " + collectedStones);
    }

    public bool HasCollectedAllStones()
    {
        return collectedStones >= totalStones; // Перевіряємо, чи зібрано всі камені
    }
}
