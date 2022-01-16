using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command Card", menuName = "Command Card")]
public class CommandCard : ScriptableObject
{
    public int[] commandCardType = new int[15];
    public int[] effectLayer = new int[15];
    public int[] commandCardImageID = new int[15];
    public string[] ccName = new string[15];
    [TextArea]
    public string[] ccDescription = new string[15];
    public int[] ccCosts = new int[15];
    public int[] currentUpgrade = new int[15];
    public int[] maxUpgrade = new int[15];
    
    public float[] abilityRange = new float[15];

    public float[] currentCD = new float[15];
    public float[] maxCD = new float[15];
    //[Header("ABILITY FUNCTIONALITY")]
    //public GameObject abilityBase;
    //public  abilityFunctions;


    /*[Header("IGNORE THESE")]
    public Coroutine[] cooldownActive = new Coroutine[15];
    public bool[] cooldown = new bool[15];*/
}
