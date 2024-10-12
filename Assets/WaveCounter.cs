using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI waveUI;

    private void OnGUI()
    {
        waveUI.text = EnemySpawner.currentWave.ToString();
    }

}
