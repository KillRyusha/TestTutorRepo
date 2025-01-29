using UnityEngine;
using TMPro; // Изменено: добавляем using для работы с TextMeshPro

public class CoinCollector : MonoBehaviour
{
    public GameObject[] ObjectsToShow;
    public TMP_Text coinCounterText; // Изменено: ссылка на TextMeshPro вместо Text
    private int coinsCollected = 0; // Количество собранных монет
    private int totalCoins = 3; // Общее количество монет в игре

    void Start()
    {
        UpdateCoinCounter(); // Обновляем счётчик при старте
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) // Проверяем, собрана ли монета
        {
            coinsCollected++; // Увеличиваем счётчик собранных монет
            UpdateCoinCounter(); // Обновляем отображение счётчика
            Destroy(other.gameObject); // Удаляем монету из игры
        }
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = "Coins: " + coinsCollected + "/" + totalCoins; // Обновляем текст счётчика
    }
    private void ShowIfMax()
    {
        if (coinsCollected >= totalCoins) 
        {
            for (int i = 0; i < ObjectsToShow.Length; i++)
            {
                ObjectsToShow[i].SetActive(true);
            }
        }
    }
}