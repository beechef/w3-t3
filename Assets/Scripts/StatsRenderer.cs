using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsRenderer : MonoBehaviour
{
    
    public Text strength;
    public Text agility;
    public Text vitality;
    public Text intelligence;

    private void Update()
    {
        strength.text = CharacterData.Stats.strength.ToString();
        agility.text = CharacterData.Stats.agility.ToString();
        vitality.text = CharacterData.Stats.vitality.ToString();
        intelligence.text = CharacterData.Stats.intelligence.ToString();
    }
}
