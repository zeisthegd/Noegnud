using Godot;
using System;

public class MainMusicPlayer : AudioStreamPlayer
{
	MusicPlayer musicPlayer;
	[Export]
	AudioStream mainMenuMusic;
	[Export]
	AudioStream dungeon1Music;

	[Export]
	AudioStream confirm;
	[Export]
	AudioStream back;

	public override void _Ready()
	{
		base._Ready();
		PlayMainMenuMusic();

	}
	public void PlayMainMenuMusic()
	{
		PlayStream(mainMenuMusic);
	}
	public void PlayDungeon1Music()
	{
		PlayStream(dungeon1Music);
	}
	private void PlayStream(AudioStream stream)
	{
		Stream = stream;
		VolumeDb = AutoLoad.MusicVolume;
		Play();
	}

	public void _on_Music_Volume_Change()
	{
		VolumeDb = AutoLoad.MusicVolume;
	}
}
