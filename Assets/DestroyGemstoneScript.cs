using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject myObject;      // Об'єкт, який потрібно знищити
    public AudioClip destroySound;   // Звук для відтворення
    private AudioSource playerAudioSource; // Компонент AudioSource гравця
    public PlayerInventory playerInventory; // Інвентар гравця

    private void Start()
    {
        // Знаходимо AudioSource на об'єкті гравця
        playerAudioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();

        // Якщо немає AudioSource на гравцеві, додаємо його
        if (playerAudioSource == null)
        {
            playerAudioSource = GameObject.FindWithTag("Player").AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Відтворюємо звук на гравцеві
            playerAudioSource.PlayOneShot(destroySound);

            // Додаємо камінь до інвентаря
            playerInventory.CollectStone();

            // Знищуємо предмет
            Destroy(myObject);

            Debug.Log("Камінь знищено!");
        }
    }
}
