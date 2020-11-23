using Godot;
using System;
using Database;

public class GUI : Control
{
	[Export]
	PackedScene gameOverScene;
	Progress progress;

	int currentScore = 0;

	public override void _Ready()
	{
		base._Ready();
		progress = (Progress)GetNode("Progress");
		Global.PlayerStats.Connect(nameof(PlayerStats.OutOfHealth), this, nameof(GameOverFunction));
	}
	public void GameOverFunction()
	{
		if (Convert.ToInt32(progress.Score) > AutoLoad.PlayerBUS.GetCurrentPlayer().HighScore)
			AutoLoad.PlayerBUS.UpdateHighScore(Convert.ToInt32(progress.Score));
		GameOver newGameOverScene = (GameOver)gameOverScene.Instance();
		newGameOverScene.SetCurrentScore(progress.Score);
		AddChild(newGameOverScene);
		
	}
}
