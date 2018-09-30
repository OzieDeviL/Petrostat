using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrostat.Domain.GameplaySequences
{
    public static class GameStart
    {
        public static void Main(Player parentPlayer, string gameName)
        {
            #region Hardcode1
            //hardcoded player and game name
            Player hcParentPlayer = UIInputParentPlayer();
            String hcName = "TestGame-" + DateTime.UtcNow.ToString();
            #endregion Hardcode1

            //create a new game
            Game game = new Game(hcParentPlayer, hcName);
            //settings
            Settings preGameSettings = UIInputSettings(game.Id); //UI input

            //add initial nonParent players
            game.ActivePlayers.AddRange(UIInputStartingPlayers());

            //create and add corresponding playerGameSessions
            foreach (Player player in game.ActivePlayers)
            {
                PlayerGameSession playerGameSession = new PlayerGameSession(player.Id, game.Id);
                game.ActivePlayerGameSessions.Add(playerGameSession);
            }
            game.PlayerGameSessions.AddRange(game.ActivePlayerGameSessions);
            
            //generate ideology instances
            game.Ideologies = UIInputStartingIdeologies(game.Id, game.ActivePlayerGameSessions.Count);

            //assign ideologies to playerSessions, based on UIInput
            //game.CurrentGameSessionIdeologies.Add(game.PlayerGameSessions[0], UIInputIdeologyAssignment(game.ActiveIdeologies, 0));
            //game.AllGameSessionIdeologies.Add(game.PlayerGameSessions[0], UIInputIdeologyAssignment(game.ActiveIdeologies, 0));
            #region Hardcode2
            for (int i = 0; i < game.Ideologies.Count; i++)   //hardcode
            {
                game.CurrentGameSessionIdeologies.Add(
                                        game.ActivePlayerGameSessions[i]
                                        , UIInputIdeologyAssignment(game.Ideologies, i)
                                        );
                game.AllGameSessionIdeologies.Add(
                        game.ActivePlayerGameSessions[i]
                        , UIInputIdeologyAssignment(game.Ideologies, i)
                        );
            }
            #endregion Hardcode2

            //game setup
            game.Nation.SetUp();

            //turn 0
            while (game.ActivePlayerGameSessions.Count > 4 && !game.GameplayComplete)
            {
                Turn turn = new Turn(game);
                turn.Sequence(game);
            }

            //Policy Phase
            //Round 1
            //2
            //3
            //National Events Phase
            //Surplus Discontent
            //Elections
            //Market Growth
            //Oil
            //Collect Taxes
            //Public Spending
            //Political Capital
            //Victory Points
            //turn 0 + n

            //war
        }

        private static Player UIInputParentPlayer()
        {
            Player uiPlayer = new Player
            {
                Id = Guid.Parse("a821b964-93fb-4b3a-aa89-7976eb43a223"),
                Name = "TestPlayer0",
                Nickname = "OzieTester0"
            };
            return uiPlayer;
        }
        private static Settings UIInputSettings(Guid gameId)
        {
            Settings uiInputSettings = new Settings
            {
                Balance = 0
            };
            Socialist socialist = new Socialist(gameId);
            Liberal liberal = new Liberal(gameId);
            Authoritarian authoritarian = new Authoritarian(gameId);
            MinoritySectarian minoritySectarian = new MinoritySectarian(gameId);
            MajoritySectarian majoritySectarian= new MajoritySectarian(gameId);
            Nationalist nationalist = new Nationalist(gameId);
            Fundamentalist fundamentalist = new Fundamentalist(gameId);
            uiInputSettings.AvailableIdeologies = new List<Ideology>
            {
                socialist
                , liberal
                , authoritarian
                , minoritySectarian
                , majoritySectarian
                , nationalist
                , fundamentalist
            };
            uiInputSettings.TurnOrder = new Dictionary<int, Ideology>
            {
                { 0, socialist }
                , { 1, liberal }
                , { 2, authoritarian }
                , { 3, minoritySectarian }
                , { 4, majoritySectarian }
                , { 5, nationalist }
                , { 6, fundamentalist }
            };
            uiInputSettings.QuickPlay = false;
            return uiInputSettings;
        }
        private static List<Player> UIInputStartingPlayers()
        {
            //make a bunch of new players
            Player player1 = new Player()
            {
                Id = Guid.Parse("0d9fff41-182c-47d3-975d-60214fca259d"),
                Name = "TestPlayer1",
                Nickname = "OzieTester1"
            };
            Player player2 = new Player()
            {
                Id = Guid.Parse("b3bb75ce-c47e-41d0-8e1c-14dcbdf9fabb"),
                Name = "TestPlayer2",
                Nickname = "OzieTester2"
            };
            Player player3 = new Player()
            {
                Id = Guid.Parse("9c12c297-6c7a-4df4-a0ab-2817abe991af"),
                Name = "TestPlayer3",
                Nickname = "OzieTester3"
            };
            Player player4 = new Player()
            {
                Id = Guid.Parse("f76dcbd3-c56d-449c-aecc-bb488fefe527"),
                Name = "TestPlayer4",
                Nickname = "OzieTester4"
            };
            Player player5 = new Player()
            {
                Id = Guid.Parse("a821b964-93fb-4b3a-aa89-7976eb43a223"),
                Name = "TestPlayer5",
                Nickname = "OzieTester5"
            };
            Player player6 = new Player()
            {
                Id = Guid.Parse("bc71950e-cbf4-4838-bf8b-1cad51042cc0"),
                Name = "TestPlayer6",
                Nickname = "OzieTester6"
            };
            //throw them in a list
            List<Player> initialJoiningPlayers = new List<Player>
            {
                player1
                , player2
                , player3
                , player4
                , player5
                , player6
            };
            return initialJoiningPlayers;
        }
        private static List<Ideology> UIInputStartingIdeologies(Guid gameId, int playerCount)
        {
            //add base five ideologies
            List<Ideology> startingIdeologies = new List<Ideology>
            {
                    new Socialist(gameId)
                    , new Liberal(gameId)
                    , new Authoritarian(gameId)
                    , new MinoritySectarian(gameId)
                    , new MajoritySectarian(gameId)
            };
            //add nationalist if there are enough players
            if (playerCount > 5)
            {
                startingIdeologies.Add(new Nationalist(gameId));
            }
            //add fundamentalist
            if (playerCount > 6)
            {
                startingIdeologies.Add(new Fundamentalist(gameId));
            }
            return startingIdeologies;
        }
        private static Ideology UIInputIdeologyAssignment(List<Ideology> activeIdeologies, int i)
        {
            //get ideology for a playerSession
                //code
            return activeIdeologies[i]; //hardcode
        }

}
}
