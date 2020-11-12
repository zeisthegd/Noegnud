using Godot;
using System;
using Database;

public class LoginScreen : Control
{
	[Export]
	PackedScene loginWindow;
	[Export]
	PackedScene registerWindow;

	public override void _Ready()
	{

	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		OnEnterPress();
	}
	private void OnEnterPress()
	{
		if(Input.IsActionJustPressed("ui_accept"))
		{
			Global.UiSFXPlayer.PlayUIConfirm();
			SpawnLoginWindow(new Vector2(96,72));
			SpawnRegisterWindow(new Vector2(96, 50));
		}	
	}

	private void _on_Quit_pressed()
	{
		GetTree().Quit();
	}
	private void SpawnLoginWindow(Vector2 position)
	{
		LoginWindow window = (LoginWindow)loginWindow.Instance();
		Global.CurrentScene.AddChild(window);
		window.RectGlobalPosition = position;
	}

	private void SpawnRegisterWindow(Vector2 position)
	{
		RegisterWindow window = (RegisterWindow)registerWindow.Instance();
		Global.CurrentScene.AddChild(window);
		window.RectGlobalPosition = position;
		window.Hide();
	}

	private void _on_Button_pressed()
	{
		Global.UiSFXPlayer.PlayUIConfirm();
		SpawnLoginWindow(new Vector2(96, 72));
		SpawnRegisterWindow(new Vector2(96, 50));
	}
}















