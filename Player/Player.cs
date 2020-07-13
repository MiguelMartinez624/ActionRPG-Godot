using Godot;
using System;
using ActionRPG.Core.Components;
using ActionRPG.Core.Items;
using ActionRPG.Core.StateMachine;
using ActionRPG.States;
using Godot.Collections;

namespace ActionRPG
{
    public class Player : KinematicBody2D
    {
        [Export] public int Speed = 80;

        // Node Components
        private AnimationTree _animationTree = null;
        private AnimationNodeStateMachinePlayback _animationNodeStateMachinePlayback = null;
        private AttackArea _attackArea;

        // State handlers
        private StateMachine<Player> _stateMachine;

        // Data Components
        public readonly MovementComponent MovementComponent = new MovementComponent(180);
        public readonly DamageComponent DamageComponent = new DamageComponent();
        public readonly HealthComponent HealthComponent = new HealthComponent(100);

        public override void _Ready()
        {
            base._Ready();
            // Initialize and mount the state machine.
            this._stateMachine = new StateMachine<Player>(this, StatesIndex.Idle);
            this._stateMachine
                .AddState(new PlayerAttackState())
                .AddState(new PlayerMovingState())
                .AddState(new PlayerIdleState());


            this._attackArea = GetNode<AttackArea>("./AttackArea");
            this._attackArea.SetWeapon(new Sword(10, 10));
            // Get Animation components (nodos). 
            this._animationTree = GetNode<AnimationTree>("./AnimationTree");
            this._animationTree.Active = true;
            this._animationNodeStateMachinePlayback =
                (AnimationNodeStateMachinePlayback) this._animationTree.Get("parameters/playback");
        }

        public override void _PhysicsProcess(float delta)
        {
            // Move and update the velocity after collision.
            MovementComponent.Velocity = MoveAndSlide(MovementComponent.Velocity);

            var v = MovementComponent.Velocity;
            if (v == Vector2.Zero) return;
            this._attackArea.UpdateOrientation(v);
        }


        public override void _Process(float delta)
        {
            // Get and handle user inputs.
            GetInput();

            // Update the player state machine
            this._stateMachine.Update(delta);

            // play animations according to components data
            PlayAnimations();
        }

        private void GetInput()
        {
            MovementComponent component = this.MovementComponent;
            if (this.MovementComponent != null)
            {
                // get movement inputs
                this.MovementComponent.ItsMovingRight = Input.IsActionPressed("ui_right");
                this.MovementComponent.ItsMovingLeft = Input.IsActionPressed("ui_left");
                this.MovementComponent.ItsMovingBackward = Input.IsActionPressed("ui_down");
                this.MovementComponent.ItsMovingForward = Input.IsActionPressed("ui_up");
            }

            this.DamageComponent.ItsAttacking = Input.IsActionPressed("attack");
        }

        private void PlayAnimations()
        {
            if (this.MovementComponent.Velocity != Vector2.Zero)
            {
                _animationTree.Set("parameters/Idle/blend_position", MovementComponent.Velocity);
                _animationTree.Set("parameters/Run/blend_position", MovementComponent.Velocity);
                _animationTree.Set("parameters/Attack1/blend_position", MovementComponent.Velocity);
            }

            switch (this._stateMachine.CurrentState?.Code)
            {
                case StatesIndex.Attack:
                    _animationNodeStateMachinePlayback.Travel("Attack1");
                    break;
                case StatesIndex.Idle:
                    _animationNodeStateMachinePlayback.Travel("Idle");
                    break;
                case StatesIndex.MoveForward:
                    _animationNodeStateMachinePlayback.Travel("Run");
                    break;
                default:
                    _animationNodeStateMachinePlayback.Travel("Idle");
                    break;
            }
        }

        public void DisableAttack()
        {
            this._attackArea.DisabledHitBox();
        }
    }
}