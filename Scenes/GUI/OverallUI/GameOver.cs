using Godot;
using System;

public class GameOver : Control
{
	Control ui;
	Label name, score, hiScore;
	int width = 96, height = 59;
	public override void _Ready()
	{
		SetAppearPosition();

		name = (Label)GetNode("Data").GetNode("Username");
		score = (Label)GetNode("Data").GetNode("Lines");
		hiScore = (Label)GetNode("Data").GetNode("Highscore");
		ui = (Control)GetParent();

		SetText();
	}

	private void SetText()
	{
		name.Text = AutoLoad.PlayerBUS.GetCurrentPlayer().UserName;
		//score.Text = ui.TotalLinesScored();
		hiScore.Text = AutoLoad.PlayerBUS.GetCurrentPlayer().HighScore.ToString();
	}

	public void SetAppearPosition()
	{
		RectGlobalPosition = new Vector2(AutoLoad.WINDOW_WIDTH/2 - width,
			AutoLoad.WINDOW_HEIGHT / 2 - height);
	}
	private void _on_Restart_pressed()
	{
		GetTree().ReloadCurrentScene();
	}


	private void _on_MainMenu_pressed()
	{
		AutoLoad.Global.GotoScene(Global.StartMenu);
	}

	private void _on_Ranking_pressed()
	{
		AutoLoad.Global.GotoScene(Global.Ranking);
	}
}





