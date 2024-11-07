using UnityEngine;

public class MyAudioClip
{
	public string name;

	public AudioClip clip;

	public long timeStart;

	public MyAudioClip(string filename)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		clip = (AudioClip)Resources.Load(filename);
		name = filename;
	}

	public void Play()
	{
		((Component)Main.main).GetComponent<AudioSource>().PlayOneShot(clip);
		timeStart = mSystem.currentTimeMillis();
	}

	public bool isPlaying()
	{
		return false;
	}
}
