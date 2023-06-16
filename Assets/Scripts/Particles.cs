
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    public void ParticlesOn()
    {
        particle.SetActive(true);
    }
}
