using Godot;
using System;

public class Player : KinematicBody2D
{
	static string spriteSheetPath = "res://Assets/Art/Player/Sheets/Knight.png";
	const string spriteNodeName = "Sprite";
	const string animationPlayerName = "AnimationPlayer";

	Sprite spriteSheet;
	AnimationPlayer animationPlayer;

	PlayerMovementHandler playerMovementHandler;
	PlayerRotationHandler rotationHandler;

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
		rotationHandler = new PlayerRotationHandler(this);
		TextureHandler.ChangePlayerTexture(spriteSheet,spriteSheetPath);
	}

	public override void _Process(float delta)
	{
		playerMovementHandler.HandleMoveInput();
		rotationHandler.MakePlayerLookAtCursor(spriteSheet);
	}

	public override void _PhysicsProcess(float delta)
	{
		playerMovementHandler.ApplyPhysics();
	}

	
}
