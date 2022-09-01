using UnityEngine;

[CreateAssetMenu(fileName = "Attack.asset", menuName = "Attack/BaseAttack")]
public class AttackDefinition : ScriptableObject
{
    public float Cooldown { get; set; }
    public float Range { get; set; }

    public int Damage { get; set; }

    public Attack CreateAttack(CharacterStats attackerStats, CharacterStats defenderStats)
    {
        var coreDamage = attackerStats.GetDamage();
        if(defenderStats != null)
        {
            coreDamage -= defenderStats.GetCurrentResistance();
        }

        return new Attack(coreDamage);
    }
}
