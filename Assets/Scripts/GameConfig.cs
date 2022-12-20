using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameConfig", menuName = "My GameJam Game/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] public LayerMask layerItems;
    [SerializeField] public LayerMask layerEnemies;
    
    [Header("Health")]
    [SerializeField] public int scoreOnHitItem;
    [SerializeField] public int scoreOnHitEnemy;

    [Header("Health")]
    [SerializeField] public int maxHealth;
    [SerializeField] public int damageOnHitEnemy;
}
