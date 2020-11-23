using Godot;
using System;
using Database;

public class GUI : Control
{
	[Export]
	PackedScene gameOverScene;
	[Export]
	PackedScene pauseWindowScene;
	Progress progress;

	int currentScore = 0;

	public override void _Ready()
	{
		base._Ready();
		progress = (Progress)GetNode("Progress");
		Global.PlayerStats.Connect(nameof(PlayerStats.OutOfHealth), this, nameof(GameOverFunction));
	}
	public override void _Process(float delta)
	{
		base._Process(delta);
		PauseGame();
	}
	public void GameOverFunction()
	{
		if (Convert.ToInt32(progress.Score) > AutoLoad.PlayerBUS.GetCurrentPlayer().HighScore)
			AutoLoad.PlayerBUS.UpdateHighScore(Convert.ToInt32(progress.Score));
		GameOver newGameOverScene = (GameOver)gameOverScene.Instance();
		newGameOverScene.SetCurrentScore(progress.Score);
		AddChild(newGameOverScene);		
	}

	public void PauseGame()
	{
		if(Input.IsActionJustPressed("pause"))
		{
			PauseWindow newwPauseWindow = (PauseWindow)pauseWindowScene.Instance();
			AddChild(newwPauseWindow);
			GetTree().Paused = true;
		}
	}
}
