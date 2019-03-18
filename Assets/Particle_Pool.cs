using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Pool : MonoBehaviour {

    int particleIndex;
    Particle_Decal[] particleDecals;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ParticleCollide(ParticleCollisionEvent particleCollision)
    {


    }

    public void SetParticles()
    {
        particleIndex++;
    }

    public void DrawParticles()
    {
        for (int i = 0; i < particleDecals.Length; i++)
        {
            //particles[i].position = particleData[i].position;
            //particles[i].rotation3D = particleData[i].rotation;
            //particles[i].startSize = particleData[i].size;
        }
    }
}
