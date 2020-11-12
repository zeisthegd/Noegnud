using Godot;
using System;

public class StartMenu : Control
{
	//AudioStream loginScreen = (AudioStream)ResourceLoader.Load(@"res://Audio/Music/Home - Toby Fox.ogg");
	Global global;
	public override void _Ready()
	{

	}


	private void _on_Start_pressed()
	{
		AutoLoad.Global.GotoScene(Global.Game);
		Global.UiSFXPlayer.PlayUIConfirm();
		Global.MainMusicPlayer.PlayDungeon1Music();
	}

	
	private void _on_Ranking_pressed()
	{
		Global.UiSFXPlayer.PlayUIConfirm();
		AutoLoad.Global.GotoScene(Global.Ranking);
	}


	private void _on_Options_pressed()
	{
		Global.UiSFXPlayer.PlayUIConfirm();
		AutoLoad.Global.GotoScene(Global.Option);
	}

	private void _on_Exit_pressed()
	{
		Global.UiSFXPlayer.PlayUIBack();
		GetTree().Quit();
	}
	private void _on_Logout_pressed()
	{
		Global.UiSFXPlayer.PlayUIBack();
		AutoLoad.Global.GotoScene(Global.LoginScreen);
	}

}












