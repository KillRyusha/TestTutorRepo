using UnityEngine;
using TMPro; // ��������: ��������� using ��� ������ � TextMeshPro

public class CoinCollector : MonoBehaviour
{
    public GameObject[] ObjectsToShow;
    public TMP_Text coinCounterText; // ��������: ������ �� TextMeshPro ������ Text
    private int coinsCollected = 0; // ���������� ��������� �����
    private int totalCoins = 3; // ����� ���������� ����� � ����

    void Start()
    {
        UpdateCoinCounter(); // ��������� ������� ��� ������
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) // ���������, ������� �� ������
        {
            coinsCollected++; // ����������� ������� ��������� �����
            UpdateCoinCounter(); // ��������� ����������� ��������
            Destroy(other.gameObject); // ������� ������ �� ����
        }
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = "Coins: " + coinsCollected + "/" + totalCoins; // ��������� ����� ��������
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