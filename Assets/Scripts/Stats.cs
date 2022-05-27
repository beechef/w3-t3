using UnityEngine;

[System.Serializable]
public class Stats
{
    public float strength;
    public float agility;
    public float intelligence;
    public float vitality;
    public static Stats operator +(Stats statsA, Stats statsB)
    {
        return new()
        {
            strength = statsA.strength + statsB.strength,
            agility = statsA.agility + statsB.agility,
            vitality = statsA.vitality + statsB.vitality,
            intelligence = statsA.intelligence + statsB.intelligence,
        };
    }

    public override string ToString()
    {
        return $"Strength: {strength}" +
               $"\nAgility: {agility}" +
               $"\nVitality: {vitality}" +
               $"\nIntelligence: {intelligence}";
    }
}