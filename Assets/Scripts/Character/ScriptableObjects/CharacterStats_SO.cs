using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName ="Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    #region Fields

    public bool isHero = false;
    public bool saveDataOnClose = false;

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public int baseResistance = 0;
    public int currentResistance = 0;

    public float baseMoveSpeed = 0f;
    public float currentMoveSpeed = 0f;

    public float baseJumpForce = 0f;
    public float currentJumpForce = 0f;

    #endregion

    #region Stat Increasers
    public void IncreaseHealth(int healthAmount)
    {
        if(maxHealth < currentHealth + healthAmount)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void IncreaseResistance(int resistanceAmount)
    {
        currentResistance += resistanceAmount;
    }

    #endregion
    #region Stat Reducers
    public void TakeDamage(int amount)
    {
        if (currentHealth - amount <= 0)
        {
            currentHealth = 0;
            Death();
        }
        else
        {
            currentHealth -= amount;
        }
    }

    public void ReduceResistance(int resistanceAmount)
    {
        currentResistance -= resistanceAmount;
    }

    #endregion

    private void Death()
    {
        Debug.Log("You're Dead");
    }
}
