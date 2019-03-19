using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Pool : MonoBehaviour {

    public int maxNumberDecals = 75;
    public float maxDecalSize = 1.5f;
    public float minDecalSize = 0.5f;

    private ParticleSystem particleSystemDecal;
    private int particleIndex;
    private Particle_Decal[] particleDecals;
    public ParticleSystem.Particle[] particleClump;

    void Start ()
    {
        particleSystemDecal = GetComponent<ParticleSystem>();
        particleClump = new ParticleSystem.Particle[maxNumberDecals];
        particleDecals = new Particle_Decal[maxNumberDecals];
		for (int i = 0; i < maxNumberDecals; i++)
        {
            particleDecals[i] = new Particle_Decal();
        }
	}

    public void ParticleCollide(ParticleCollisionEvent particleCollision)
    {
        SetParticle(particleCollision);
        DrawParticles();
    }

    public void SetParticle(ParticleCollisionEvent particleCollision)
    {
        if (particleIndex >= maxNumberDecals)
        {
            particleIndex = 0;
        }

        particleDecals[particleIndex].position = particleCollision.intersection;
        Vector3 particleRotation = Quaternion.LookRotation(particleCollision.normal).eulerAngles;
        particleRotation.z = Random.Range(0, 360);
        particleDecals[particleIndex].rotation = particleRotation;
        particleDecals[particleIndex].scale = Random.Range(minDecalSize, maxDecalSize);

        particleIndex++;
    }

    public void DrawParticles()
    {
        for (int i = 0; i < particleDecals.Length; i++)
        {
            particleClump[i].position = particleDecals[i].position;
            particleClump[i].rotation3D = particleDecals[i].rotation;
            particleClump[i].startSize = particleDecals[i].scale;
            particleClump[i].startColor = new Color(1, 0, 0);
        }
        particleSystemDecal.SetParticles(particleClump, particleClump.Length);
    }
}
