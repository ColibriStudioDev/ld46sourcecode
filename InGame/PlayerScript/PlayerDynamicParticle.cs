using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDynamicParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem Flame;
    private ParticleSystem.EmissionModule flameEmission;


    private void Awake()
    {
        flameEmission = Flame.emission;
    }

    void Update()
    {
        if (PlayerStat.isFinished == false) return;

        float numberOfParticle = PlayerStat.PlayerStats[Stats.Life] * PlayerStat.PlayerStats[Stats.FlameParticleNumber] / PlayerStat.PlayerStats[Stats.InitLife];
        flameEmission.rateOverTime = numberOfParticle;

    }
}
