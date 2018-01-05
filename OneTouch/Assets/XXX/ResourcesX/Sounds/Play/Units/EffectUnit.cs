using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem)), ExecuteInEditMode]
public class EffectUnit : MonoBehaviour {
    public AudioClip audioClip = null;
    public AudioClip audioClip2 = null;
    public bool Play = false;
	private ParticleSystem _particle;

	void Awake() { _particle = GetComponent<ParticleSystem>(); }

	public void Animate()
	{
		Debug.Log(this.name + " animating");
		_particle.Play();

        if (audioClip != null) AudioSource.PlayClipAtPoint(audioClip, transform.position);
        if (audioClip2 != null) AudioSource.PlayClipAtPoint(audioClip2, transform.position);

    }

    public void Update()
    {
        if (Play == true)
        {
            Debug.Log("Animation");
            Animate();
            Play = false;
        }
    }
}
