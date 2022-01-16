using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public int zombieAmount;
    public int normalZombies;
    public int speedyZombies;
    public int giantZombies;
    public int inteligentZombies;
}
