﻿using System;
using System.Collections.Generic;
using System.Linq;

public static class Server_Database
{
	//	id
	//	email
	//	password
	//	accountType
	private static List<Server_User> usersTable = new List<Server_User>()
	{
		new Server_User(1, "Player 1", "testpassword", AccountTypeEnum.Player),
		new Server_User(2, "Developper 1", "dev", AccountTypeEnum.Developper), 
		new Server_User(3, "bvb", "bvb", AccountTypeEnum.Player)
	};

	//	userId
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	private static List<Server_Robot_Player> playerRobotsTable = new List<Server_Robot_Player>()
	{
		new Server_Robot_Player(1, 1, 30, 50, 40, 0, 40, 50),
		new Server_Robot_Player(3, 1, 30, 50, 40, 0, 40, 50)
	};

	//	algoGenId
	//	name
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	private static List<Server_Robot_AlgoGen> algoGenRobotsTable = new List<Server_Robot_AlgoGen>()
	{
		new Server_Robot_AlgoGen(1, "HAL 9000", 2, 10, 70, 20, 0, 20, 10)
	};


	//	Methodes table User
	public static int GetServer_UserIdFromEmail(string arg_email)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetEmail() == arg_email)
            {
                return lp_user.GetId();
            }
        }
        return 0;
	}

	public static bool CheckServer_UserPasswordFromUserId(int arg_userId, string arg_password)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId && lp_user.GetPassword() == arg_password)
            {
                return true;
            }
                
        }

        return false;
    }

	public static AccountTypeEnum GetServer_UserAccountTypeFromUserId(int arg_userId)
	{
		foreach (Server_User lp_user in usersTable)
		{
			if (lp_user.GetId() == arg_userId)
			{
				return lp_user.GetAccountType();
			}
		}

		return AccountTypeEnum.Player;
	}

	public static Server_User GetServer_UserFromId(int arg_userId)
	{
		foreach (Server_User lp_serverUser in usersTable)
		{
			if (lp_serverUser.GetId() == arg_userId)
			{
				return lp_serverUser;
			}
		}

		return null;
	}

	public static String GetUserTokenFromUserId(int arg_userId)
	{
		foreach (Server_User lp_serverUser in usersTable)
		{
			if (lp_serverUser.GetId() == arg_userId)
			{
				return lp_serverUser.GetToken();
			}
		}

		return "";
	}

	public static int GetServer_UserWinsFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                return lp_user.GetWins();
            }
        }

        return 0;
	}

	public static int GetServer_UserLossesFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                return lp_user.GetLosses();
            }
        }

        return 0;
    }

	public static void IncrementServer_UserWinsFromUserId(int arg_userId, string arg_userToken)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
				if (lp_user.GetToken() == arg_userToken)
				{
					int loc_wins = lp_user.GetWins();
					lp_user.SetWins(loc_wins + 1);
					break;
				}   
            }
        }
    }

	public static void IncrementServer_UserLossesFromUserId(int arg_userId, string arg_userToken)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
				if (lp_user.GetToken() == arg_userToken)
				{
					int loc_losses = lp_user.GetLosses();
					lp_user.SetLosses(loc_losses + 1);
					break;
				}	
            }
        }
    }


	//	Methodes table playerRobots
	public static Server_Robot_Player GetServer_Robot_PlayerFromUserId(int arg_userId)
	{
		foreach (Server_Robot_Player lp_robotPlayer in playerRobotsTable)
		{
			if (lp_robotPlayer.GetUserId() == arg_userId)
			{
				return lp_robotPlayer;
			}
		}
		return null;
	}

	public static void SetServer_Robot_PlayerFromUserId(int arg_userId, Server_Robot_Player arg_serverRobot, string arg_userToken)
	{
		for (int i = 0; i < playerRobotsTable.Count; i++)
		{
			if (playerRobotsTable[i].GetUserId() == arg_userId)
			{
				if (GetUserTokenFromUserId(arg_userId) == arg_userToken)
				{
					playerRobotsTable[i] = arg_serverRobot;
					break;
				}
			}
		}
	}


	//	Methodes table algoGenRobots
	public static Server_Robot_AlgoGen GetServer_Robot_AlgoGenFromId(int algoGen_id)
	{
		foreach (Server_Robot_AlgoGen lp_robotAlgoGen in algoGenRobotsTable)
		{
			if (lp_robotAlgoGen.GetAlgoGenId() == algoGen_id)
			{
				return lp_robotAlgoGen;
			}
		}
		return null;
	}


	//	Méthodes de conversion d'objets serveur en objets locaux
	public static Robot_Player CreateRobot_PlayerFromServer(Server_Robot_Player arg_serverRobot)
	{
		return new Robot_Player(arg_serverRobot.GetWeaponId(), arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}

	public static Server_Robot_Player ConvertRobot_PlayerToServer(Robot_Player arg_robotPlayer)
	{
		return new Server_Robot_Player(Game.GetCurentUser().GetId(), arg_robotPlayer.GetWeaponId(), arg_robotPlayer.GetStatAttack(), arg_robotPlayer.GetStatHp(), arg_robotPlayer.GetStatSpeed(), arg_robotPlayer.GetBehaviorProximity(), arg_robotPlayer.GetBehaviorAgility(), arg_robotPlayer.GetBehaviorAggressivity());
	}

	public static Robot_AlgoGen CreateRobot_AlgoGenFromServer(Server_Robot_AlgoGen arg_serverRobot)
	{
		return new Robot_AlgoGen(arg_serverRobot.GetAlgoGenId(), arg_serverRobot.GetName(), arg_serverRobot.GetWins(), arg_serverRobot.GetLosses(), arg_serverRobot.GetWeaponId(), arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}

	public static User_Player CreateUser_PlayerFromServer(Server_User arg_serverUser)
	{
		int loc_randomRobot_AlgoGenId = 1;
		return new User_Player(arg_serverUser.GetId(), arg_serverUser.GetAccountType(), arg_serverUser.GetEmail(), arg_serverUser.GetToken(), CreateRobot_PlayerFromServer(GetServer_Robot_PlayerFromUserId(arg_serverUser.GetId())), CreateRobot_AlgoGenFromServer(GetServer_Robot_AlgoGenFromId(loc_randomRobot_AlgoGenId)));
		//	ATTENTION, POUR CETTE VERSION L'EMAIL EST UTILISE POUR LE CHAMP NAME
	}

	public static User_Developper CreateUser_DevelopperFromServer(Server_User arg_serverUser)
	{
		Robot_AlgoGen[] loc_algoGenSessionTable = { };
		return new User_Developper(arg_serverUser.GetId(), arg_serverUser.GetAccountType(), arg_serverUser.GetEmail(), arg_serverUser.GetToken(), loc_algoGenSessionTable);
		//	ATTENTION, POUR CETTE VERSION L'EMAIL EST UTILISE POUR LE CHAMP NAME
	}


	//	Méthodes d'ajout de nouvel utilisateur joueur
	public static void AddNewServer_Robot_Player(int arg_userId)
	{
		playerRobotsTable.Add(new Server_Robot_Player(arg_userId, 1 , 50, 50, 50, 50, 50, 50));
	}

	public static void AddNewServer_User(string arg_email, string arg_password)
	{
		int loc_userId = usersTable.Count + 1;
		Server_User loc_serverUser = new Server_User(loc_userId, arg_email, arg_password, AccountTypeEnum.Player);
		loc_serverUser.SetToken("RandomToken");
		usersTable.Add(loc_serverUser);
		AddNewServer_Robot_Player(loc_userId);
	}
}