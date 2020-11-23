using Godot;
using System;

public class GameOver : Control
{
	Control ui;
	Label name, score, hiScore;
	

	int currentScore;
	public override void _Ready()
	{
		SetAppearPosition();
		name = (Label)GetNode("Username");
		score = (Label)GetNode("Lines");
		hiScore = (Label)GetNode("Highscore");
		ui = (Control)GetParent();
		

		SetText();
		
	}
	public void SetCurrentScore(int score)
    {
		currentScore = score;
    }

	public void SetText()
	{
		name.Text = AutoLoad.PlayerBUS.GetCurrentPlayer().UserName;
		this.score.Text = currentScore.ToString() ;
		hiScore.Text = AutoLoad.PlayerBUS.GetCurrentPlayer().HighScore.ToString();
	}

	public void SetAppearPosition()
	{
		RectGlobalPosition = new Vector2(120,40);
	}
	private void _on_Restart_pressed()
	{
		Global.PlayerStats.ResetStats();
		AutoLoad.Global.ReloadScene(Global.CurrentScene);
	}


	private void _on_MainMenu_pressed()
	{
		Global.PlayerStats.ResetStats();
		AutoLoad.Global.GotoScene(Global.StartMenu);
	}

	private void _on_Ranking_pressed()
	{
		Global.PlayerStats.ResetStats();
		AutoLoad.Global.GotoScene(Global.Ranking);
	}
}





