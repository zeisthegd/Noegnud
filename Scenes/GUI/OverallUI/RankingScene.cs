using Godot;
using Database;
using System;
using System.Linq;
using System.Collections.Generic;

public class RankingScene : Node2D
{
	VBoxContainer rankFrames;
	List<PlayerDTO> sortedPlayerList;
	//AudioStream rankingScene = (AudioStream)ResourceLoader.Load(@"res://Audio/Music/Home - Toby Fox.ogg");

	[Export]
	PackedScene rankFrame1Path;
	[Export]
	PackedScene rankFrame2Path;
	[Export]
	PackedScene rankFramePath;
	[Export]
	PackedScene currentRankFramePath;

	public override void _Ready()
	{
		rankFrames = (VBoxContainer)GetNode("FramesContainer/RankFrames");
		sortedPlayerList = AutoLoad.PlayerBUS.PlayersList.OrderByDescending(o => o.HighScore).ToList();
		PrintPlayerList();
		DisplayPlayersRanks();


		//AutoLoad.PlayMusic(this, rankingScene);
	}

	private void DisplayPlayersRanks()
	{
		if (sortedPlayerList.Count > 0)
		{
			Add1stRankFrame();
			if (sortedPlayerList.Count > 1)
			{
				Add2ndRankFrame();
				if (sortedPlayerList.Count > 2)
					AddOthersRankFrames();
			}
			AddCurrentPlayerRankFrame();
		}
	}


	private void Add1stRankFrame()
	{
		RankFrames newFrame = (RankFrames)rankFrame1Path.Instance();
		rankFrames.AddChild(newFrame);
		newFrame.DisplayPlayerData("#1", sortedPlayerList[0].UserName, sortedPlayerList[0].HighScore.ToString());
	}
	private void Add2ndRankFrame()
	{
		RankFrames newFrame = (RankFrames)rankFrame2Path.Instance();
		rankFrames.AddChild(newFrame);
		newFrame.DisplayPlayerData("#2", sortedPlayerList[1].UserName, sortedPlayerList[1].HighScore.ToString());
	}
	private void AddOthersRankFrames()
	{
		for (int i = 2; i < sortedPlayerList.Count; i++)
		{
			RankFrames newFrame = (RankFrames)rankFramePath.Instance();
			rankFrames.AddChild(newFrame);
			newFrame.DisplayPlayerData($"#{i + 1}", sortedPlayerList[i].UserName,
				sortedPlayerList[i].HighScore.ToString());
		}

	}
	private void AddCurrentPlayerRankFrame()
	{
		PlayerDTO currentPlayer = AutoLoad.PlayerBUS.GetCurrentPlayer();
		RankFrames newFrame = (RankFrames)currentRankFramePath.Instance();
		this.AddChild(newFrame);
		newFrame.RectGlobalPosition = new Vector2(64,340);
		newFrame.DisplayPlayerData($"#{sortedPlayerList.IndexOf(currentPlayer) + 1}", currentPlayer.UserName, currentPlayer.HighScore.ToString());
	}

	private void _on_Back_pressed()
	{
		AutoLoad.Global.GotoScene(Global.StartMenu);
	}

	void PrintPlayerList()
	{
		foreach(PlayerDTO player in sortedPlayerList)
		{
			GD.Print(player.UserName);
		}
	}


}


