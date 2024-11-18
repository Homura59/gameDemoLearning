using Godot;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Coin : Area2D
{
	private GameManager _gameManager;
	private AnimationPlayer _animationPlayer;
	// Called when the node enters the scene tree for te first time.
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%gameManager");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnCoinBodyEntered(Node body)
	{
		_gameManager.AddScore();
		_animationPlayer.Play("pickup");
	}
}
