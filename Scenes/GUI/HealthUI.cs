using Godot;
using System;

//HealthUI dùng để hiển thị HP của người chơi
//Dưới dạng Hearts(các trái tim)
public class HealthUI : Control
{
	PlayerStats playerStats;
	int hearts;
	int maxHearts;

	int spriteSize = 15;

	TextureRect heartUIFull;
	TextureRect heartUIEmpty;

	

	public override void _Ready()
	{
		GetPlayerStats();
		InitializeChildNodes();
		maxHearts = playerStats.MaxHealth;
		SetHearts(hearts);
		SetMaxHearts(maxHearts);
	}

	
	public override void _Process(float delta)
	{
		hearts = playerStats.CurrentHealth;	
		SetHearts(hearts);
	}
	
	private void InitializeChildNodes()
	{
		heartUIFull = (TextureRect)GetNode("HeartUIFull");
		heartUIEmpty = (TextureRect)GetNode("HeartUIEmpty");
	}

	//Hien thi cac Hearts ra man hinh
	private void SetHearts(int value)
	{	
		hearts = Mathf.Clamp(value,0,maxHearts);
		if(heartUIFull != null)
		{
			heartUIFull.RectSize = new Vector2(hearts * spriteSize, heartUIFull.RectSize.y);
		}
	}
	 
	private void SetMaxHearts(int value)
	{
		maxHearts = Mathf.Max(value, 1);
		if (heartUIEmpty != null)
		{
			hearts = Mathf.Min(hearts, maxHearts);//Chon gia tri nho nhat giua 2 gia tri
			heartUIEmpty.RectSize = new Vector2(maxHearts * spriteSize, heartUIEmpty.RectSize.y);
		}
	}


	//Lay du lieu cua nguoi choi
	private void GetPlayerStats()
	{
		string playerStatsName = "PlayerStats";		
		this.playerStats = (PlayerStats)Global.GetPlayer().GetNode(playerStatsName);
	}

	public int MaxHearts { get => maxHearts; set => maxHearts = Mathf.Max(value, 1); }

	//https://www.youtube.com/watch?v=7A4EPIr-6Sc&list=PL9FzW-m48fn2SlrW0KoLT4n5egNdX-W9a&index=18&ab_channel=HeartBeast
	//Chi tiết
}
