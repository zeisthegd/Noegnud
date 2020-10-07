using Godot;
using System;

public class Player : KinematicBody2D
{
	static string spriteSheetPath = "res://Assets/Art/Player/Player.png";
	const string spriteNodeName = "Sprite";
	const string animationPlayerName = "AnimationPlayer";

	Sprite spriteSheet;
	AnimationPlayer animationPlayer;

	PlayerMovementHandler playerMovementHandler;

	PlayerStateMachine playerStateMachine;

	

	public override void _Ready()
	{	
		InitializeAllChilds();
		InitializePlayer();
	}

	private void InitializeAllChilds()
	{
		spriteSheet = (Sprite)GetNode(spriteNodeName);
		animationPlayer = (AnimationPlayer)GetNode(animationPlayerName);
		
	}

	private void InitializePlayer()
	{
		playerMovementHandler = new PlayerMovementHandler(this);
		TextureHandler.ChangePlayerTexture(spriteSheet,spriteSheetPath);

		playerStateMachine = new PlayerStateMachine(this);
	}

	public override void _Process(float delta)
	{
		playerMovementHandler.HandleMoveInput();

		playerStateMachine.HandleKeypressEvent();
	}

	public override void _PhysicsProcess(float delta)
	{
		playerMovementHandler.ApplyPhysics();
	}
	#region Properties

	public AnimationPlayer AnimationPlayer { get => animationPlayer; }

	#endregion

}
