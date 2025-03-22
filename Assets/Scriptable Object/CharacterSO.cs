using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterSO", menuName ="GameData/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string CharacterName;
    public float CharacterJumpPower;
    public float CharacterMoveSpeed;
}
