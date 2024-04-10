using System.Collections;
using UnityEngine;
using TMPro;
public class WaveManager : MonoBehaviour
{
  [SerializeField] private float _spawnRate = 1.0f;
  [SerializeField] private float _timeBetweenWaves = 3.0f;
  [SerializeField] private GameObject _enemy;
  [SerializeField] private Transform _spawnPoint;
  public TextMeshProUGUI _waveCountText;
  private int _waveCount = -1;
  private int _enemyCount;
  private bool _waveIsDone = true;
  private void Update()
  {
    _waveCountText.text = "Wave: " + _waveCount.ToString();
    if (_waveIsDone == true)
    {
      StartCoroutine(WaveSpawner());
    } 
  }

  private IEnumerator WaveSpawner()
  {
    _waveIsDone = false;
    
    for (int i = 0; i < _enemyCount; i++)
    {
      GameObject enemyClone = Instantiate(_enemy, _spawnPoint);
      yield return new WaitForSeconds(_spawnRate);
    }

    _spawnRate -= 0.1f;
    _enemyCount += 1;
    _waveCount += 1;
    yield return new WaitForSeconds(_timeBetweenWaves);
    _waveIsDone = true;
  }
}
