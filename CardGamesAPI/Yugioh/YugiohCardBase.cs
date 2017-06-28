﻿using System;
namespace CardGamesAPI.Yugioh
{
    /// <summary>
    /// This class will be the base class for ALL Yugioh Cards.
    /// </summary>
    public abstract class YugiohCardBase : CardEffectBase, IYugiohCard
    {
        public string CardName { get; set; }

        public string KonamiID { get; set; }

        public YugiohCardBaseType CardBaseType { get; set; }

        public YugiohCardPosition Position { get; set; }

        public int SpellSpeed { get; set; }

        public Guid SysGuid { get; set; }

        public string LocalPath { get; set; }

        public string Url { get; set; }

        public event EventHandler<YugiohCardEventArgs> EffectTriggered;


        protected virtual void RaiseEffectTriggered(YugiohCardEventArgs e) => EffectTriggered?.Invoke(this, e);

        public void SetKonamiID(string konamiId)
        {
            KonamiID = konamiId;
        }

        public abstract void Dispose();
    }
}
