using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		//左右移动时，动画朝向跟随方向
		if (direction > Vector2.Zero)
		{
			animatedSprite.FlipH = false;
		}
		else if (direction < Vector2.Zero)
		{
			animatedSprite.FlipH = true;
		}
		//在地面上时，根据状态播放不同动画
		if (IsOnFloor())
		{
			if (direction == Vector2.Zero)
			{
				animatedSprite.Play("idle");
			}
			else
			{
				animatedSprite.Play("run");
			}
		}
		//在空中时，播放跳跃动画
		else
		{
			animatedSprite.Play("jump");
		}

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
