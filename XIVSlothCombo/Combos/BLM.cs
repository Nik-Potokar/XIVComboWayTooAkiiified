using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVSlothComboPlugin.Combos
{
    internal static class BLM
    {
        public const byte ClassID = 7;
        public const byte JobID = 25;

        public const uint
            Fire = 141,
            Blizzard = 142,
            Thunder = 144,
            Blizzard2 = 25793,
            Transpose = 149,
            Fire2 = 147,
            Fire3 = 152,
            Thunder3 = 153,
            Thunder2 = 7447,
            Thunder4 = 7420,
            Blizzard3 = 154,
            Scathe = 156,
            Freeze = 159,
            Flare = 162,
            LeyLines = 3573,
            Blizzard4 = 3576,
            Fire4 = 3577,
            BetweenTheLines = 7419,
            Despair = 16505,
            UmbralSoul = 16506,
            Paradox = 25797,
            Amplifier = 25796,
            HighFireII = 25794,
            HighBlizzardII = 25795,
            Xenoglossy = 16507,
            Foul = 7422,
            Sharpcast = 3574,
            Manafont = 158;

        public static class Buffs
        {
            public const ushort
                Thundercloud = 164,
                LeyLines = 737,
                Firestarter = 165,
                Sharpcast = 867;
        }

        public static class Debuffs
        {
            public const ushort
                Thunder = 161,
                Thunder2 = 162,
                Thunder3 = 163,
                Thunder4 = 1210;
        }

        public static class Levels
        {
            public const byte
                Fire3 = 34,
                Freeze = 35,
                Blizzard3 = 40,
                Thunder3 = 45,
                Flare = 50,
                LeyLines = 52,
                Sharpcast = 54,
                Blizzard4 = 58,
                Fire4 = 60,
                BetweenTheLines = 62,
                Foul = 70,
                Despair = 72,
                UmbralSoul = 76,
                Xenoglossy = 80,
                Amplifier = 86;
        }
    }

    internal class BlackBlizzardFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackBlizzardFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Blizzard)
            {
                var gauge = GetJobGauge<BLMGauge>().InUmbralIce;
                if (level >= 40 && !gauge)
                {
                    return BLM.Blizzard3;
                }
            }

            if (actionID == BLM.Freeze && level < 35)
            {
                return 146u;
            }

            return actionID;
        }
    }

    internal class BlackFire13Feature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackFire13Feature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Fire)
            {
                var gauge = CustomCombo.GetJobGauge<BLMGauge>();
                if ((level >= 34 && !gauge.InAstralFire) || CustomCombo.HasEffect(BLM.Buffs.Firestarter))
                {
                    return CustomCombo.OriginalHook(BLM.Fire3);
                }
            }

            return actionID;
        }
    }

    internal class BlackLeyLinesFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackLeyLinesFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == 3573 && CustomCombo.HasEffect(737) && level >= 62)
            {
                return 7419u;
            }

            return actionID;
        }
    }

    internal class BlackManaFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackManaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == 149)
            {
                var gauge = CustomCombo.GetJobGauge<BLMGauge>();
                if (gauge.InUmbralIce && level >= 76)
                {
                    return 16506u;
                }
            }

            return actionID;
        }
    }

    internal class BlackEnochianFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackEnochianFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Scathe)
            {
                var gauge = GetJobGauge<BLMGauge>();
                var GCD = GetCooldown(actionID);
                var thundercloudduration = FindEffectAny(BLM.Buffs.Thundercloud);
                var thunderdebuffontarget = FindTargetEffect(BLM.Debuffs.Thunder3);
                var thunderOneDebuff = FindTargetEffect(BLM.Debuffs.Thunder);
                var thunder3DebuffOnTarget = TargetHasEffect(BLM.Debuffs.Thunder3);

                // oGCD Feature
                if (gauge.IsEnochianActive)
                {
                    if (IsEnabled(CustomComboPreset.BlackAmplifierFeature) && level >= BLM.Levels.Amplifier && IsOffCooldown(BLM.Amplifier) && gauge.PolyglotStacks < 2 && GCD.CooldownRemaining > 0.7)
                        return BLM.Amplifier;

                    if (gauge.IsEnochianActive && IsEnabled(CustomComboPreset.BlackLeyLinesAutoFeature) && level >= BLM.Levels.LeyLines && IsOffCooldown(BLM.LeyLines) && GCD.CooldownRemaining > 0.7)
                        return BLM.LeyLines;

                    if (gauge.IsEnochianActive && IsEnabled(CustomComboPreset.BlackSharpcastFeature) && level >= BLM.Levels.Sharpcast && GetRemainingCharges(BLM.Sharpcast) > 0 && !HasEffect(BLM.Buffs.Sharpcast) && GCD.CooldownRemaining > 0.7)
                        return BLM.Sharpcast;
                }

                // Polygot Overcap Feature
                if (gauge.ElementTimeRemaining >= 6000 && IsEnabled(CustomComboPreset.BlackPolygotFeature) && thunder3DebuffOnTarget)
                {
                    if (gauge.InUmbralIce || (gauge.InAstralFire && gauge.UmbralHearts == 0))
                    {
                        if (level >= BLM.Levels.Xenoglossy)
                        {
                            if (gauge.PolyglotStacks == 2)
                                return BLM.Xenoglossy;
                        }
                        else if (level >= BLM.Levels.Foul)
                        {
                            if (gauge.PolyglotStacks == 1)
                                return BLM.Foul;
                        }
                    }
                }

                if (gauge.InUmbralIce && level >= BLM.Levels.Blizzard4)
                {
                    if (gauge.ElementTimeRemaining >= 0 && IsEnabled(CustomComboPreset.BlackThunderFeature))
                    {
                        if (HasEffect(BLM.Buffs.Thundercloud))
                        {
                            if ((TargetHasEffect(BLM.Debuffs.Thunder3) && thunderdebuffontarget.RemainingTime < 4) || (!thunder3DebuffOnTarget && HasEffect(BLM.Buffs.Thundercloud) && thundercloudduration.RemainingTime > 0 && thundercloudduration.RemainingTime < 35))
                                return BLM.Thunder3;
                        }

                        if (IsEnabled(CustomComboPreset.BlackThunderUptimeFeature) && !thunder3DebuffOnTarget && lastComboMove != BLM.Thunder3)
                            return BLM.Thunder3;

                        if (gauge.IsParadoxActive && level >= 90)
                            return BLM.Paradox;

                        if (IsEnabled(CustomComboPreset.BlackAspectSwapFeature) && gauge.UmbralHearts == 3 && LocalPlayer.CurrentMp >= 10000)
                            return BLM.Fire3;

                    }

                    return BLM.Blizzard4;
                }

                if (level >= BLM.Levels.Fire4)
                {
                    if (gauge.ElementTimeRemaining >= 6000 && CustomCombo.IsEnabled(CustomComboPreset.BlackThunderFeature))
                    {
                        if (HasEffect(BLM.Buffs.Thundercloud))
                        {
                            if ((TargetHasEffect(BLM.Debuffs.Thunder3) && thunderdebuffontarget.RemainingTime < 4) || (!thunder3DebuffOnTarget && HasEffect(BLM.Buffs.Thundercloud) && thundercloudduration.RemainingTime > 0 && thundercloudduration.RemainingTime < 35))
                                return BLM.Thunder3;
                        }

                        if (IsEnabled(CustomComboPreset.BlackThunderUptimeFeature) && !thunder3DebuffOnTarget && lastComboMove != BLM.Thunder3)
                            return BLM.Thunder3;
                    }

                    if (gauge.ElementTimeRemaining < 3000 && HasEffect(BLM.Buffs.Firestarter) && CustomCombo.IsEnabled(CustomComboPreset.BlackFire13Feature))
                    {
                        return BLM.Fire3;
                    }

                    if (IsEnabled(CustomComboPreset.BlackAspectSwapFeature) && LocalPlayer.CurrentMp == 0 && level >= BLM.Levels.Blizzard3)
                    {
                        if (IsEnabled(CustomComboPreset.BlackManafontFeature) && IsOffCooldown(BLM.Manafont) && GCD.CooldownRemaining > 0.7)
                        {
                            return BLM.Manafont;
                        }
                        if (lastComboMove != BLM.Manafont)
                        {
                            return BLM.Blizzard3;
                        }
                    }

                    if (gauge.ElementTimeRemaining > 0 && LocalPlayer.CurrentMp < 2400 && level >= BLM.Levels.Despair && CustomCombo.IsEnabled(CustomComboPreset.BlackDespairFeature))
                    {
                        return BLM.Despair;
                    }

                    if (gauge.IsEnochianActive)
                    {
                        if (gauge.ElementTimeRemaining < 6000 && !HasEffect(BLM.Buffs.Firestarter) && IsEnabled(CustomComboPreset.BlackFire13Feature) && level == 90 && gauge.IsParadoxActive)
                            return BLM.Paradox;
                        if (gauge.ElementTimeRemaining < 6000 && !HasEffect(BLM.Buffs.Firestarter) && IsEnabled(CustomComboPreset.BlackFire13Feature) && !gauge.IsParadoxActive)
                            return BLM.Fire;
                    }
                    else if (IsEnabled(CustomComboPreset.BlackEnochainRecoveryFeature))
                    {
                        if (LocalPlayer.CurrentMp >= 2000)
                        {
                            return BLM.Fire3;
                        }
                        else
                        {
                            return BLM.Blizzard3;
                        }
                    }

                    return BLM.Fire4;
                }

                if (gauge.ElementTimeRemaining >= 5000 && IsEnabled(CustomComboPreset.BlackThunderFeature) && level < BLM.Levels.Thunder3)
                {
                    if (HasEffect(BLM.Buffs.Thundercloud))
                    {
                        if (TargetHasEffect(BLM.Debuffs.Thunder) && thunderOneDebuff.RemainingTime < 4)
                            return BLM.Thunder;
                    }

                    if (IsEnabled(CustomComboPreset.BlackThunderUptimeFeature) && !TargetHasEffect(BLM.Debuffs.Thunder) && lastComboMove != BLM.Thunder)
                        return BLM.Thunder;
                }

                if (level < BLM.Levels.Fire3)
                    return BLM.Fire;

                if (gauge.InAstralFire)
                {
                    if (HasEffect(BLM.Buffs.Firestarter) && level == 90)
                        return BLM.Paradox;
                    if (HasEffect(BLM.Buffs.Firestarter))
                        return BLM.Fire3;
                    if (IsEnabled(CustomComboPreset.BlackAspectSwapFeature) && LocalPlayer.CurrentMp < 1600)
                    {
                        if (IsEnabled(CustomComboPreset.BlackManafontFeature) && IsOffCooldown(BLM.Manafont) && CanWeave(lastComboMove))
                        {
                            return BLM.Manafont;
                        }
                        if (lastComboMove != BLM.Manafont)
                        {
                            return BLM.Blizzard3;
                        }
                    }

                    return BLM.Fire;
                }
            }

            return actionID;
        }
    }

    internal class BlackAoEComboFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackAoEComboFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Flare)
            {
                var gauge = GetJobGauge<BLMGauge>();
                var thunder4Debuff = TargetHasEffect(BLM.Debuffs.Thunder4);
                var thunder4Timer = FindTargetEffect(BLM.Debuffs.Thunder4);
                var thunder2Debuff = TargetHasEffect(BLM.Debuffs.Thunder2);
                var thunder2Timer = FindTargetEffect(BLM.Debuffs.Thunder2);
                var currentMP = LocalPlayer.CurrentMp;

                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature))
                {
                    if ((!gauge.InUmbralIce && !gauge.InAstralFire) || (gauge.InAstralFire && currentMP <= 100))
                    {
                        if (IsEnabled(CustomComboPreset.BlackManafontFeature) && gauge.InAstralFire && currentMP <= 100)
                        {
                            if (IsOffCooldown(BLM.Manafont) && CanWeave(lastComboMove))
                            {
                                return BLM.Manafont;
                            }
                        }
                        if (level <= 81)
                            return BLM.Blizzard2;
                        if (level >= 82)
                            return BLM.HighBlizzardII;
                    }
                }
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature))
                {
                    if (gauge.InUmbralIce && gauge.UmbralHearts <= 2)
                    {
                        if (level >= BLM.Levels.Blizzard4)
                        {
                            return BLM.Freeze;
                        }
                        else if (level >= 40 && currentMP < 10000 && thunder2Debuff)
                        {
                            return BLM.Freeze;
                        }
                    }
                }
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 26 && level <= 63)
                {
                    if ((gauge.InUmbralIce && (gauge.UmbralHearts == 3 || level < BLM.Levels.Blizzard4) && !thunder2Debuff) ||
                        (gauge.InUmbralIce && (gauge.UmbralHearts == 3 || level < BLM.Levels.Blizzard4) && thunder2Timer.RemainingTime <= 3 && level >= 26 && level <= 63) ||
                        (gauge.InAstralFire && !thunder2Debuff && level >= 26 && level <= 63))
                    {
                        if (lastComboMove == BLM.Thunder2)
                        {
                        }
                        else
                        {
                            return BLM.Thunder2;
                        }
                    }
                }
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 64)
                {
                    if ((gauge.InUmbralIce && gauge.UmbralHearts == 3 && !thunder4Debuff) || (gauge.InUmbralIce && gauge.UmbralHearts == 3 && thunder4Timer.RemainingTime <= 3) || (gauge.InAstralFire && !thunder4Debuff))
                    {
                        if (lastComboMove == BLM.Thunder4)
                        {
                        }
                        else
                        {
                            return BLM.Thunder4;
                        }
                    }
                }
                // low level
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 26 && level <= 63)
                {
                    if ((gauge.InUmbralIce && (gauge.UmbralHearts == 3 || level < BLM.Levels.Blizzard4) && thunder2Debuff && thunder2Timer.RemainingTime >= 3) ||
                        (gauge.InUmbralIce && (gauge.UmbralHearts == 3 || level < BLM.Levels.Blizzard4) && lastComboMove == BLM.Thunder2))
                    {
                        if (level <= 81)
                            return BLM.Fire2;
                    }
                }
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 26 && level <= 63)
                {
                    if ((gauge.InAstralFire && LocalPlayer.CurrentMp > 7000 && thunder2Debuff) || (gauge.InAstralFire && LocalPlayer.CurrentMp > 7000 && lastComboMove == BLM.Thunder2))
                    {
                        if (level <= 81)
                            return BLM.Fire2;
                    }
                }
                // highlevel
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature))
                {
                    if ((gauge.InUmbralIce && gauge.UmbralHearts == 3 && thunder4Debuff && thunder4Timer.RemainingTime >= 3) || (gauge.InUmbralIce && gauge.UmbralHearts == 3 && lastComboMove == BLM.Thunder4))
                    {
                        if (level <= 81)
                            return BLM.Fire2;
                        if (level >= 82)
                            return BLM.HighFireII;
                    }
                }
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature))
                {
                    if ((gauge.InAstralFire && LocalPlayer.CurrentMp > 7000 && thunder4Debuff) || (gauge.InAstralFire && LocalPlayer.CurrentMp > 7000 && lastComboMove == BLM.Thunder4))
                    {
                        if (level <= 81)
                            return BLM.Fire2;
                        if (level >= 82)
                            return BLM.HighFireII;
                    }
                }
                // lowlevel
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 50 && level <= 63)
                {
                    if ((gauge.InAstralFire && LocalPlayer.CurrentMp <= 7000 && thunder2Debuff) || (gauge.InAstralFire && LocalPlayer.CurrentMp <= 7000 && lastComboMove == BLM.Thunder2))
                        return BLM.Flare;
                }
                // highlevel
                if (IsEnabled(CustomComboPreset.BlackAoEComboFeature) && level >= 64)
                {
                    if ((gauge.InAstralFire && LocalPlayer.CurrentMp <= 7000 && thunder4Debuff) || (gauge.InAstralFire && LocalPlayer.CurrentMp <= 7000 && lastComboMove == BLM.Thunder4))
                        return BLM.Flare;
                }
                if (level <= 81)
                    return BLM.Blizzard2;
                if (level >= 82)
                    return BLM.HighBlizzardII;
            }

            return actionID;
        }
    }
}
