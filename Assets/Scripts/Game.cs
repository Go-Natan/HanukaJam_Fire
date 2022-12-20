using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Game rules")]
    [SerializeField] private GameConfig config;

    [Header("Scene dependencies")]
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image flash;
    
    [Header("Gameplay State")]
    private int _playerHealth;
    private int _playerScore;
    
    [Header("Effects State")]
    private float _flashTimeTotal;
    private float _flashTimeLeft;
    

    private List<GameObject> _collidedAlready;
    private bool _playerJustDied;

    // Start is called before the first frame update
    void Start()
    {
        _playerScore = 0;
        _playerHealth = config.maxHealth;
            
        _collidedAlready = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        _collidedAlready.Clear();

        HandlePlayerDeath();

        HandleEscapeToRestart();
        
        UpdateUI();
        UpdateFlash();
    }

    private void HandlePlayerDeath()
    {
        if (_playerJustDied) {
            _playerJustDied = false;
            
            player.SetActive(false);
            ScreenFlash(Color.red, 0.24f, 1f);
        }
    }

    private void HandleEscapeToRestart()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {_playerScore.ToString()}";
        healthText.text = $"{_playerHealth.ToString()}%";
    }
    
    private void UpdateFlash()
    {
        if (_flashTimeLeft > 0)
        {
            _flashTimeLeft -= Time.deltaTime;
            var color = flash.color;
            color.a = _flashTimeLeft / _flashTimeTotal;
            flash.color = color;
        } else {
            flash.color = new Color(1, 1, 1, 0);
        }
    }
    

    public void OnCollision(GameObject obj1, GameObject obj2)
    {
        if (_collidedAlready.Contains(obj1) || _collidedAlready.Contains(obj2))
        {
            return;
        }
        
        if (player == obj1) {
            OnPlayerCollision(obj2);
        } else if (player == obj2) {
            OnPlayerCollision(obj1);
        }
        
        _collidedAlready.Add(obj1);
        _collidedAlready.Add(obj2);
    }

    public void OnPlayerCollision(GameObject other)
    {
        var layer = other.layer;
        if (InLayerMask(layer, config.layerItems)) {
            OnPlayerHitItem(other);
        } else if (InLayerMask(layer, config.layerEnemies)) {
            OnPlayerHitEnemy(other);
        }
    }

    public void OnPlayerHitItem(GameObject item)
    {
        _playerScore += config.scoreOnHitItem;
        Destroy(item);

        ScreenFlash(Color.cyan, 0.05f, 0.3f);
    }
    
    public void OnPlayerHitEnemy(GameObject enemy)
    {
        _playerScore += config.scoreOnHitEnemy;
        DamagePlayer(config.damageOnHitEnemy);
        Destroy(enemy);
        
        ScreenFlash(Color.red, 0.1f, 0.8f);
    }

    private void DamagePlayer(int damage)
    {
        var wasAlive = _playerHealth > 0;
        _playerHealth -= damage;
        _playerHealth = Mathf.Max(0, _playerHealth);
        _playerJustDied = wasAlive && _playerHealth <= 0;
    }

    /// <summary>
    /// Flahes the screen for some time
    /// </summary>
    /// <param name="color">The color of the effect</param>
    /// <param name="time">The total duration of the effect</param>
    /// <param name="strength">The alpha strength of the effect. 1 is full opacity, 0 is invisible</param>
    private void ScreenFlash(Color color, float time, float strength)
    {
        if (strength == 0) {
            return;
        }

        _flashTimeTotal = time / strength;
        _flashTimeLeft = time;
        flash.color = color;
    }

    private bool InLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask & (1 << layer)) != 0;
    }
}
