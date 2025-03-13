using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    private CharacterSO characterSO;
    public CharacterData(CharacterSO characterSO)
    {
        this.characterSO = characterSO;
    }
    public float GetCharacterMoveSpeed()
    {
        float moveSpeed = characterSO.CharacterMoveSpeed + characterSO.CharacterMoveSpeed * 0.05f * CurrentLevel;
        return moveSpeed;
    }
    public float GetCharacterJumpPower()
    {
        float jumpPower = characterSO.CharacterJumpPower + characterSO.CharacterJumpPower * 0.1f * CurrentLevel;
        return jumpPower;
    }
    //getter, setter. public get, private set
    //every class can get but only this class can set
    public int CurrentLevel { get; private set; }
    public void LevelUp()
    {
        CurrentLevel++;
    }

}