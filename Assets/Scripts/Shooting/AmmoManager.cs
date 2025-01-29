using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class AmmoManager : MonoBehaviour
{
    public int maxAmmo = 10;
    private int currentAmmo;
    public TMP_Text ammoText;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateUI(currentAmmo, maxAmmo);
    }

    public void UpdateUI(int current, int max)
    {
        ammoText.text = $"Ammo: {current}/{max}";
    }
}