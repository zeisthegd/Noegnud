using Godot;
using System;

public class MainMusicPlayer : AudioStreamPlayer
{
	[Export]
	int volumeDb = 0;

	[Export]
	AudioStream mainMenuMusic;
	[Export]
	AudioStream dungeon1Music;
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
		VolumeDb = volumeDb;
		Play();
	}
}
