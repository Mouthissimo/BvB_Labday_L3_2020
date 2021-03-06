﻿using System;

public class Robot_AlgoGen : Robot
{
	private int algoGenId;
	private string name;
	private int wins;
	private int losses;
	
	
	//	Constructor
	public Robot_AlgoGen(int arg_algoGenId, string arg_name, int arg_wins, int arg_losses, int arg_weaponId, int arg_statAttack, int arg_statHp, int arg_statSpeed, int arg_behaviorProximity, int arg_behaviorAgility, int arg_behaviorAggressivity)
	{
		algoGenId = arg_algoGenId;
		name = arg_name;
		wins = arg_wins;
		losses = arg_losses;
		SetWeaponId(arg_weaponId);
		SetStatAttack(arg_statAttack);
		SetStatHp(arg_statHp);
		SetStatSpeed(arg_statSpeed);
		SetBehaviorProximity(arg_behaviorProximity);
		SetBehaviorAgility(arg_behaviorAgility);
		SetBehaviorAggressivity(arg_behaviorAggressivity);
		SetCurentStatHp(GetStatHp() + Game.minimumRobotHp);
	}


	//	Getters
	public int GetAlgoGenId()
	{
		return algoGenId;
	}

	public string GetName()
	{
		return name;
	}

	public int GetWins()
	{
		return wins;
	}

	public int GetLosses()
	{
		return losses;
	}


	//	Setters
	public void SetWins(int arg_algoGenRobotWins)
	{
		wins = arg_algoGenRobotWins;
	}

	public void SetLosses(int arg_algoGenRobotLosses)
	{
		losses = arg_algoGenRobotLosses;
	}
}
