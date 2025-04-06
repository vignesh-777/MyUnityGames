## Description
Brick Blaster is a classic 2D arcade-style breakout game built using Unity. The player controls a paddle to bounce a ball and break bricks while collecting exciting power-ups. Each power-up affects gameplay in unique ways, keeping the game dynamic and challenging.

This game was made as a personal project to practice and learn Unity game development from scratch. All core systems like player health, ball duplication, and power-up management were built using C# scripts.

## Features
1. Ball & Paddle Mechanics
Classic ball bouncing and paddle control using Rigidbody2D.

2.  Power-Up System
3.  Double Ball
4. Ball Size Up
5.  Ultra Power (placeholder for future expansion)
6. Paddle Size Up
7. Life Gain
8.  Smart Health System

## Tracks player lives

Decreases life only if the last ball touches the death wall

Handles game over scenarios

## Death Wall

Destroys balls on contact

Triggers health loss conditionally

## Random Power-Up Spawner

Randomly spawns power-ups when the ball hits certain points

Not triggered for every hit, making gameplay unpredictable

## Organized Scripts

PowerUp.cs for power logic

PlayerHealth.cs using Singleton pattern

DeathWall.cs to manage health and destroy balls

PowerUpSpawner.cs for random spawn control

## How to Play
Use your mouse or arrow keys to move the paddle.

Bounce the ball to break bricks.

Catch falling power-ups for cool effects.

Don’t let the last ball fall into the death wall!

## output
![Screenshot 2025-04-06 125906](https://github.com/user-attachments/assets/1a9cef32-a5c2-4027-866c-3e81dc7b6de0)
