using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialize : MonoBehaviour
{
    [SerializeField]
    private float StartLife,AbsorptionTime,GivenLife,FireParticleNumber;



    public float getInitLife()
    {
        return StartLife;
    }

    private void Awake()
    {
            PlayerStat.isFinished = false;
            PlayerStat.PlayerStats = new Dictionary<Stats, float>();
            PlayerStat.PlayerStats.Add(Stats.Life, StartLife);
            PlayerStat.PlayerStats.Add(Stats.AbsorptionTime, AbsorptionTime);
            PlayerStat.PlayerStats.Add(Stats.GivenLife, GivenLife);
            PlayerStat.PlayerStats.Add(Stats.FlameParticleNumber, FireParticleNumber);
            PlayerStat.PlayerStats.Add(Stats.InitLife, StartLife);
            PlayerStat.isFinished = true;
            PlayerStat.PlayerStats.Add(Stats.Dead, 0);


        
    }

    

}
