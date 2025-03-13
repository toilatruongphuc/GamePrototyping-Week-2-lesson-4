using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterSO", menuName ="GameData/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    // Start is called before the first frame update
    public string CharacterName;
    public float CharacterJumpPower;
    public float CharacterMoveSpeed;
}
