﻿using Common;
using System;
using System.Collections.Generic;

namespace CardGamesAPI.Yugioh
{
    public class YugiohMove : MoveBase
    {
        public int CurrentDrawSize { get; set; } = 1;

        public bool IsTurnPlayer { get; set; }

        public YugiohMove()
        {
            Children = new List<IMove>();
        }

        public YugiohMove(bool isTurnPlayer, int playerScore)
        {
            IsTurnPlayer = isTurnPlayer;
            if (isTurnPlayer)
                TurnPlayer.Score = playerScore;
            else
                Opponent.Score = playerScore;

        }

        public YugiohMove(IPlayer turnPlayer, int turnPlayerScore)
            : this(turnPlayer, null)
        {
            TurnPlayer.Score = turnPlayerScore;
        }

        public YugiohMove(IPlayer turnPlayer, IPlayer opponent)
            : this()
        {
            TurnPlayer = turnPlayer;
            TurnPlayer.Opponent = opponent;
            if (Opponent == null)
            {
                TurnPlayer.Opponent = new YugiohPlayer();
            }
        }

        //public int GetScore() => GetTurnPlayer(IsTurnPlayer).Score;

        public override bool IsTerminal(bool turnPlayer)
        {
            //todo: implement special win-conditions here
            return GetTurnPlayer().IsDead || Children.IsNullOrEmpty();

            //return turnPlayer ? (TurnPlayer.IsDead) ? true : false : (Opponent.IsDead) ? true : false;
        }

        public override int GetScore(bool turnPlayer) => GetTurnPlayer().Score;

        public override int GetScoreOf(IPlayer player) => player.Score;

        private IPlayer GetTurnPlayer() => IsTurnPlayer ? TurnPlayer : Opponent;

        public override void GenerateMoves()
        {
            throw new NotImplementedException();
        }

    }

}