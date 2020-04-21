using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStat
{
    private static Dictionary<Stats, float> playerStats = new Dictionary<Stats, float>();

    public static Dictionary<Stats, float> PlayerStats { get => playerStats; set => playerStats = value; }

    public static Vector3 lastCoordinate = new Vector3();
    public static int order;
    public static bool isFinished = false;
}

public enum Stats
{
    Life,
    AbsorptionTime,
    GivenLife,
    FlameParticleNumber,
    InitLife,
    Dead,
}
