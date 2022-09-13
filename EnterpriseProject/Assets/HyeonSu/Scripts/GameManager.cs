using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveVariables saveVariables;


}

[System.Serializable]
public class SaveVariables
{
    [Header("Money")]
    public ulong gold;
    [Header("Facility")]
    public int facilityUpgrade;
    public int facilityUpgradeCostIncrease;
    [Header("Room")]
    public int roomUpgrade;
    public int roomUpgradeCostDecrease;
    [Header("Teacher")]
    public int TeacherUpgrade1;
    public int TeacherUpgrade2;
    public int TeacherUpgrade3; 
    public int TeacherUpgrade4; 
    public int TeacherUpgrade5; 
    public int TeacherUpgrade6;
}
