using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Database;

public class AutoLoad : Node
{
	static PlayerBUS playerBUS;
	static Global global;
	static FloatingTextSpawner floatingTextSpawner;

	string saveFolderPath;
	static string savePathForCSharp = @"Saves\players.txt";
	static string savePath;
	static string configPath;
	
	public const int WINDOW_HEIGHT = 216, WINDOW_WIDTH = 384;

	const int CELL_SIZE = 16;

	static int musicVolume = 0;
	static int sfxVolume = 0;
	static bool fullScreen = true;

	public override void _Ready()
	{      
		global = (Global)GetNode("/root/Global");
		floatingTextSpawner = (FloatingTextSpawner)GetNode("/root/FloatingTextSpawner");

		InitSaveFolderAndFile();

		InitPlayerBUS();

		InitConfig();
		LoadConfig();            
	}

	


	public static void PlayMusic(Node currentNode,AudioStream music)
	{
		AudioStreamPlayer musicPlayer = new AudioStreamPlayer();
		currentNode.AddChild(musicPlayer);

		musicPlayer.Stream = music;
		musicPlayer.VolumeDb = musicVolume;
		musicPlayer.Play();

	}
	

	void ChangeMusicVolume(int value)
	{
		musicVolume = value;
		if (musicVolume == -40)
			musicVolume = -1000;
	}

	/// <summary>
	/// Create Saves folder and initiate a text file to store players' data
	/// </summary>
	void InitSaveFolderAndFile()
	{
		var directory = new Directory();
		//saveFolderPath = OS.GetExecutablePath().GetBaseDir().PlusFile("Saves");
		saveFolderPath = directory.GetCurrentDir() + "Saves";
		directory.MakeDir(saveFolderPath);

		savePath = saveFolderPath + "/players.txt";
		
		var file = new File();
		if(!file.FileExists(savePath))
		{
			file.Open(savePath, File.ModeFlags.WriteRead);
			file.Close();
		}
		
	}
	private void InitConfig()
	{
		var file = new File();
		configPath = saveFolderPath + "/config.ini";
		if (!file.FileExists(configPath))
		{
			file.Open(configPath, File.ModeFlags.WriteRead);  
			file.Close();
			SaveConfig();
		}
	}
	public static void SaveConfig()
	{
		var config = new ConfigFile();
		var file = new File();

		config.SetValue("audio", "music_volume", musicVolume);
		config.SetValue("display", "fullscreen", fullScreen);

		if (file.FileExists("res://Saves/config.ini"))
		{
			var err = config.Save(configPath);
			if (err != Error.Ok)
				floatingTextSpawner.ShowMessage("Failed to save the game!");
		}
		else floatingTextSpawner.ShowMessage("Failed to load config file!");

		
	}
	public static void LoadConfig()
	{
		var config = new ConfigFile();
		var err = config.Load(configPath);

		if (err != Error.Ok)
		{
			musicVolume = -10;
			fullScreen = false;
			floatingTextSpawner.ShowMessage("Failed to load config!");
			return;
		}

		musicVolume = (int)config.GetValue("audio", "music_volume");
		fullScreen = (bool)config.GetValue("display", "fullscreen");

		OS.WindowFullscreen = fullScreen;
	}

	public static void InitPlayerBUS()
	{
		playerBUS = new PlayerBUS();
	}

	#region Property

	public static int CellSize
	{
		get { return CELL_SIZE; }
	}

    

    public static Global Global { get => global; set => global = value; }
	public static FloatingTextSpawner FloatingTextSpawner { get => floatingTextSpawner; set => floatingTextSpawner = value; }
	public static string SavePath { get => savePath;}
	public static string SavePathForCSharp { get => savePathForCSharp;}
	internal static PlayerBUS PlayerBUS { get => playerBUS;}
	public static int MusicVolume { get => musicVolume; set => musicVolume = value; }
	public static bool FullScreen { get => fullScreen; set => fullScreen = value; }
    public static int SfxVolume { get => sfxVolume; set => sfxVolume = value; }
    #endregion


}
