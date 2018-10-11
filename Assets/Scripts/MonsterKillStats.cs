using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonsterKillStats{
    public static int monstersKilled = 0;
    public delegate void monsterAction(int monsterKilled);
    public static event monsterAction OnMonsterCountChanged;
    public static void IncreaseMonstersKilled()
    {
        monstersKilled++;
        if (OnMonsterCountChanged != null)
        {
            OnMonsterCountChanged(monstersKilled);
        }
    }
}
