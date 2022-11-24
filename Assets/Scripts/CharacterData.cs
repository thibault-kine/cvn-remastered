using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Game/New Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
}
