using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Puwarer : MonoBehaviour {

    public ParticleSystem particleLaunch;
    public ParticleSystem splatterLaunch;
    public Particle_Pool particlePool;

    List<ParticleCollisionEvent> particleCollisions;

    private void Awake()
    {
        particleLaunch = GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start ()
    {
        particleCollisions = new List<ParticleCollisionEvent>();
        //particleLaunch.Emit(5);
	}

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLaunch, other, particleCollisions);
        for (int i = 0; i< particleCollisions.Count; i++)
        {
            particlePool.ParticleCollide(particleCollisions[i]);
            Emission(particleCollisions[i]);
        }
    }

    void Emission(ParticleCollisionEvent particleCollision)
    {
        splatterLaunch.transform.position = particleCollision.intersection;
        splatterLaunch.transform.rotation = Quaternion.LookRotation(particleCollision.normal);
        splatterLaunch.Emit(1);
    }
}
