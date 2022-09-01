using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public CharacterStats_SO characterDefinition;
    
    #region Constructors
    public CharacterStats()
    {

    }
    #endregion

    private void Start()
    {
        if(characterDefinition.isHero)
        {
            characterDefinition.maxHealth = 5;
            characterDefinition.currentHealth = 5;

            characterDefinition.currentDamage = 1;
            characterDefinition.baseDamage = 1;

            characterDefinition.baseResistance = 0;
            characterDefinition.currentResistance = 0;

            characterDefinition.baseJumpForce = 150f;
            characterDefinition.currentJumpForce = 150f;

            characterDefinition.baseMoveSpeed = 1;
            characterDefinition.currentMoveSpeed = 1;            
        }
    }

    #region Stat Increasers
    public void IncreaseHealth(int healthAmount)
    {
        characterDefinition.IncreaseHealth(healthAmount);
    }

    public void IncreaseResistance(int amount)
    {
        characterDefinition.IncreaseResistance(amount);
    }
    #endregion

    #region Stat Reducers

    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    #endregion

    #region Reporters 

    public int GetCurrentHealth() =>  characterDefinition.currentHealth;

    public int GetCurrentDamage() => characterDefinition.currentDamage;

    public int GetCurrentResistance() => characterDefinition.currentResistance;

    public float GetCurrentMoveSpeed() => characterDefinition.currentMoveSpeed;

    public float GetCurrentJumpForce() => characterDefinition.currentJumpForce;

    public int GetDamage()
    {
        return characterDefinition.currentDamage;
    }

    #endregion
}
