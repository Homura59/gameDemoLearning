using Godot;
using System;

public partial class slime : Node2D
{

	private RayCast2D rayCastRight;
	private RayCast2D rayCastLeft;
	private const float SPEED = 30.0f;
	private int direction = 1;
	private AnimatedSprite2D slimeSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		slimeSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (rayCastRight.IsColliding())
		{
			direction = -1;
			slimeSprite.FlipH = true;
		}
		if (rayCastLeft.IsColliding())
		{
			direction = 1;
			slimeSprite.FlipH = false;
		}
		Vector2 currentPosition = Position;
		currentPosition.X += direction * (float)delta * SPEED;
		Position = currentPosition;
	}
}
