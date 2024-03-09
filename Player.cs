using Godot;
using System;
using Godot.Collections;

public partial class Player : Node3D
{
	private bool _moving;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		var movementSpeed = TimeSpan.FromMilliseconds(100);
		if (@event.IsAction("forward") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + Vector3.Forward, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}
		
		if (@event.IsAction("backward") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + Vector3.Back, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}
		
		if (@event.IsAction("left") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + Vector3.Left, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}
		
		if (@event.IsAction("right") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + Vector3.Right, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}
		
		base._Input(@event);
	}
}
