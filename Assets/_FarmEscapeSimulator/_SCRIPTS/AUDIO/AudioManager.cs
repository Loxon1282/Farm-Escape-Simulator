using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	[Header("Debugging")]
	public bool debugKeys;
	[Header("Sounds list")]
	public Sound[] sounds;

	void Awake() {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.playOnAwake = false;
			s.source.clip = s.audioClip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Update() {
		if (debugKeys) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				PlaySound ("MineBlow");
			}
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				PlaySound ("Background");
			}
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				MuteSound ("Background");
			}
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				UnMuteSound ("Background");
			}
			if (Input.GetKeyDown (KeyCode.Alpha5)) {
				ToggleMute ("Background");
			}
		}
	}

	public void PlaySound(string name) {
		Sound s = GetSound (name);
		if (s != null) {
			s.source.Play ();
		}
	}

	public void StopPlaying(string name) {
		Sound s = GetSound (name);
		if (s != null) {
			if (s.source.isPlaying) {
				s.source.Stop ();
			}
		}
	}

	public void ToggleMute(string name) {
		Sound s = GetSound (name);
		if (s != null) {
			if (s.muted == true) {
				UnMuteSound (name);
			} else {
				MuteSound (name);
			}
		}
	}

	public void MuteSound(string name) {
		Sound s = GetSound (name);
		if (s != null) {
			s.source.volume = 0;
			s.muted = true;
		}
	}

	public void UnMuteSound(string name) {
		Sound s = GetSound (name);
		if (s != null) {
			s.source.volume = s.volume;
			s.muted = false;
		}
	}

	Sound GetSound(string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return null;
		}
		return s;
	}
}
