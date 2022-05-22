using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVSlothComboPlugin.Combos
{
    internal static class GNB
    {
        public const byte JobID = 37;

        public static int MaxCartridges(byte level)
        {
            return level >= Levels.CartridgeCharge3 ? 3 : 2;
        }

        public const uint
            KeenEdge = 16137,
            NoMercy = 16138,
            BrutalShell = 16139,
            DemonSlice = 16141,
            SolidBarrel = 16145,
            GnashingFang = 16146,
            SavageClaw = 16147,
            DemonSlaughter = 16149,
            WickedTalon = 16150,
            SonicBreak = 16153,
            Continuation = 16155,
            JugularRip = 16156,
            AbdomenTear = 16157,
            EyeGouge = 16158,
            BowShock = 16159,
            HeartOfLight = 16160,
            BurstStrike = 16162,
            FatedCircle = 16163,
            Aurora = 16151,
            DoubleDown = 25760,
            DangerZone = 16144,
            BlastingZone = 16165,
            Bloodfest = 16164,
            Hypervelocity = 25759,
            RoughDivide = 16154,
            LightningShot = 16143;

        public static class Buffs
        {
            public const ushort
                NoMercy = 1831,
                Aurora = 1835,
                ReadyToRip = 1842,
                ReadyToTear = 1843,
                ReadyToGouge = 1844,
                ReadyToBlast = 2686;
        }

        public static class Debuffs
        {
            public const ushort
                BowShock = 1838,
                SonicBreak = 1837;
        }

        public static class Levels
        {
            public const byte
                NoMercy = 2,
                BrutalShell = 4,
                DangerZone = 18,
                SolidBarrel = 26,
                BurstStrike = 30,
                DemonSlaughter = 40,
                Aurora = 45,
                SonicBreak = 54,
                RoughDivide = 56,
                GnashingFang = 60,
                BowShock = 62,
                Continuation = 70,
                FatedCircle = 72,
                Bloodfest = 76,
                BlastingZone = 80,
                EnhancedContinuation = 86,
                CartridgeCharge3 = 88,
                DoubleDown = 90;
        }
        public static class Config
        {
            public const string
                GnbKeepRoughDivideCharges = "GnbKeepRoughDivideCharges";
        }


        internal class GunbreakerSolidBarrelCombo : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerSolidBarrelCombo;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == SolidBarrel)
                {
                    var gauge = GetJobGauge<GNBGauge>();
                    var roughDivideChargesRemaining = Service.Configuration.GetCustomIntValue(Config.GnbKeepRoughDivideCharges);
                    var quarterWeave = GetCooldown(actionID).CooldownRemaining < 1 && GetCooldown(actionID).CooldownRemaining > 0.2;

                    if (IsEnabled(CustomComboPreset.GunbreakerRangedUptimeFeature))
                    {
                        if (!InMeleeRange())
                            return LightningShot;
                    }

                    if (comboTime > 0)
                    {
                        if (quarterWeave && IsEnabled(CustomComboPreset.GunbreakerMainComboCDsGroup) && IsEnabled(CustomComboPreset.GunbreakerNoMercyonST))
                        {
                            if (level >= Levels.NoMercy && IsOffCooldown(NoMercy))
                            {
                                if (level >= Levels.BurstStrike &&
                                    ((gauge.Ammo == 1 && IsOffCooldown(GnashingFang) && IsOffCooldown(Bloodfest)) || //Opener Conditions
                                    (gauge.Ammo == 2 && IsOnCooldown(GnashingFang) && GetCooldownRemainingTime(Bloodfest) < 3) || //GFNM windows
                                    gauge.Ammo == MaxCartridges(level) && GetCooldownRemainingTime(GnashingFang) < 2)) //Regular NMGF
                                    return NoMercy;
                                if (level < Levels.BurstStrike) //no cartridges unlocked
                                    return NoMercy;
                            }
                        }

                        //oGCDs
                        if (CanWeave(actionID))
                        {
                            if (IsEnabled(CustomComboPreset.GunbreakerMainComboCDsGroup) && IsEnabled(CustomComboPreset.GunbreakerBloodfestonST))
                            {
                                if (gauge.Ammo == 0 && IsOffCooldown(Bloodfest) && level >= Levels.Bloodfest && IsOnCooldown(GnashingFang))
                                    return Bloodfest;
                            }

                            //Blasting Zone outside of NM
                            if (IsEnabled(CustomComboPreset.GunbreakerMainComboCDsGroup) && level >= Levels.DangerZone && IsOffCooldown(DangerZone))
                            {
                                if (IsEnabled(CustomComboPreset.GunbreakerDZOnMainComboFeature) && !HasEffect(Buffs.NoMercy) &&
                                    ((IsOnCooldown(GnashingFang) && gauge.AmmoComboStep != 1 && GetCooldown(GnashingFang).CooldownRemaining > 20) || //Post Gnashing Fang
                                    (level < Levels.GnashingFang) && IsOnCooldown(NoMercy))) //Pre Gnashing Fang
                                    return OriginalHook(DangerZone);
                            }

                            //60 second weaves
                            if (IsOnCooldown(DoubleDown))
                            {
                                if (IsEnabled(CustomComboPreset.GunbreakerDZOnMainComboFeature) && IsOffCooldown(DangerZone))
                                    return OriginalHook(DangerZone);
                                if (IsEnabled(CustomComboPreset.GunbreakerBSOnMainComboFeature) && IsOffCooldown(BowShock))
                                    return BowShock;
                            }

                            //30 second weaves
                            if (IsOnCooldown(SonicBreak))
                            {
                                if (IsEnabled(CustomComboPreset.GunbreakerBSOnMainComboFeature) && level >= Levels.BowShock && IsOffCooldown(BowShock))
                                    return BowShock;
                                if (IsEnabled(CustomComboPreset.GunbreakerDZOnMainComboFeature) && level >= Levels.DangerZone && IsOffCooldown(DangerZone))
                                    return OriginalHook(DangerZone);
                            }

                            //Continuation
                            if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangOnMain) && level >= Levels.Continuation &&
                                (HasEffect(Buffs.ReadyToRip) || HasEffect(Buffs.ReadyToTear) || HasEffect(Buffs.ReadyToGouge)))
                                return OriginalHook(Continuation);

                            //Rough Divide Feature
                            if (level >= Levels.RoughDivide && IsEnabled(CustomComboPreset.GunbreakerRoughDivideFeature) && GetRemainingCharges(RoughDivide) > roughDivideChargesRemaining)
                            {
                                if (IsNotEnabled(CustomComboPreset.GunbreakerMeleeRoughDivideOption) ||
                                    (IsEnabled(CustomComboPreset.GunbreakerMeleeRoughDivideOption) && GetTargetDistance() <= 1 && HasEffect(Buffs.NoMercy) && IsOnCooldown(OriginalHook(DangerZone)) && IsOnCooldown(BowShock) && IsOnCooldown(Bloodfest)))
                                    return RoughDivide;
                            }
                        }

                        // 60s window features
                        if (GetCooldownRemainingTime(NoMercy) > 57 || HasEffect(Buffs.NoMercy) && IsEnabled(CustomComboPreset.GunbreakerMainComboCDsGroup))
                        {
                            if (level >= Levels.DoubleDown)
                            {
                                if (IsEnabled(CustomComboPreset.GunbreakerDDonMain) && IsOffCooldown(DoubleDown) && gauge.Ammo >= 2 && !HasEffect(Buffs.ReadyToRip) && gauge.AmmoComboStep >= 1)
                                    return DoubleDown;
                                if (IsEnabled(CustomComboPreset.GunbreakerSBOnMainComboFeature) && IsOffCooldown(SonicBreak) && IsOnCooldown(DoubleDown))
                                    return SonicBreak;
                            }

                            if (level < Levels.DoubleDown)
                            {
                                if (IsEnabled(CustomComboPreset.GunbreakerSBOnMainComboFeature) && level >= Levels.SonicBreak && IsOffCooldown(SonicBreak) && !HasEffect(Buffs.ReadyToRip) && IsOnCooldown(GnashingFang))
                                    return SonicBreak;

                                //sub level 54 functionality
                                if (IsEnabled(CustomComboPreset.GunbreakerDZOnMainComboFeature) && level is >= Levels.DangerZone and < Levels.SonicBreak && IsOffCooldown(DangerZone))
                                    return OriginalHook(DangerZone);
                            }
                        }

                        //Pre Gnashing Fang stuff
                        if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangOnMain) && level >= Levels.GnashingFang)
                        {
                            if (IsEnabled(CustomComboPreset.GunbreakerGFStartonMain) && IsOffCooldown(GnashingFang) && gauge.AmmoComboStep == 0 &&
                                ((gauge.Ammo == MaxCartridges(level) && GetCooldownRemainingTime(NoMercy) > 55) || //Regular 60 second GF/NM timing
                                (gauge.Ammo > 0 && GetCooldownRemainingTime(NoMercy) > 17 && GetCooldownRemainingTime(NoMercy) < 35) || //Regular 30 second window                                                                        
                                (gauge.Ammo == 3 && GetCooldownRemainingTime(Bloodfest) < 2 && GetCooldownRemainingTime(NoMercy) < 2) || //3 minute window
                                (gauge.Ammo == 1 && GetCooldownRemainingTime(NoMercy) > 55 && ((IsOffCooldown(Bloodfest) && level >= Levels.Bloodfest) || level < Levels.Bloodfest)))) //Opener Conditions
                                return GnashingFang;
                            if (gauge.AmmoComboStep is 1 or 2)
                                return OriginalHook(GnashingFang);
                        }

                        if (IsEnabled(CustomComboPreset.GunbreakerBSinNMFeature) && IsEnabled(CustomComboPreset.GunbreakerMainComboCDsGroup))
                        {
                            if ((HasEffect(Buffs.NoMercy) || HasEffect(All.Buffs.Medicated)) && gauge.AmmoComboStep == 0 && level >= Levels.BurstStrike)
                            {
                                if (level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                                    return Hypervelocity;
                                if (gauge.Ammo != 0 && IsOnCooldown(GnashingFang))
                                    return BurstStrike;
                            }

                            //final check if Burst Strike is used right before No Mercy ends
                            if (level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                                return Hypervelocity;
                        }

                        // Regular 1-2-3 combo with overcap feature
                        if (lastComboMove == KeenEdge && level >= Levels.BrutalShell)
                            return BrutalShell;
                        if (lastComboMove == BrutalShell && level >= Levels.SolidBarrel)
                        {
                            if (IsEnabled(CustomComboPreset.GunbreakerAmmoOvercapFeature))
                            {
                                if (level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                                    return Hypervelocity;
                                if (level >= Levels.BurstStrike && (gauge.Ammo == MaxCartridges(level) ||
                                    (IsEnabled(CustomComboPreset.GunbreakerBloodfestonST) && GetCooldownRemainingTime(Bloodfest) < 6 && gauge.Ammo != 0 && IsOnCooldown(NoMercy) && level >= Levels.Bloodfest))) //Burns Ammo for Bloodfest
                                    return BurstStrike;
                            }

                            return SolidBarrel;
                        }
                    }

                    return KeenEdge;
                }

                return actionID;
            }
        }

        internal class GunbreakerGnashingFangCombo : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerGnashingFangCombo;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == GnashingFang)
                {
                    var gauge = GetJobGauge<GNBGauge>();

                    if (IsOffCooldown(NoMercy) && CanDelayedWeave(actionID) && IsOffCooldown(GnashingFang) && IsEnabled(CustomComboPreset.GunbreakerNoMercyonGF))
                        return NoMercy;
                    if (HasEffect(Buffs.NoMercy) && IsOnCooldown(GnashingFang))
                    {
                        if (level >= Levels.DoubleDown)
                        {
                            if (IsEnabled(CustomComboPreset.GunbreakerDDOnGF) && IsOffCooldown(DoubleDown) && gauge.Ammo is 2 or 3 && !HasEffect(Buffs.ReadyToRip))
                                return DoubleDown;
                            if (IsOnCooldown(DoubleDown) && IsEnabled(CustomComboPreset.GunbreakerCDsOnGF))
                            {
                                if (CanWeave(actionID))
                                {
                                    if (IsOffCooldown(DangerZone))
                                        return OriginalHook(DangerZone);
                                    if (IsOffCooldown(BowShock))
                                        return BowShock;
                                }

                                if (IsOffCooldown(SonicBreak))
                                    return SonicBreak;
                            }
                        }

                        if (level < Levels.DoubleDown && IsEnabled(CustomComboPreset.GunbreakerCDsOnGF))
                        {
                            if (level >= Levels.SonicBreak && IsOffCooldown(SonicBreak) && !HasEffect(Buffs.ReadyToRip))
                                return SonicBreak;
                            if (IsOnCooldown(SonicBreak) && CanWeave(actionID))
                            {
                                if (level >= Levels.BowShock && IsOffCooldown(BowShock))
                                    return BowShock;
                                if (level >= Levels.DangerZone && IsOffCooldown(DangerZone))
                                    return OriginalHook(DangerZone);
                            }
                        }
                    }

                    if (CanWeave(actionID))
                    {
                        if (level >= Levels.DangerZone && IsOnCooldown(GnashingFang) && !HasEffect(Buffs.NoMercy) && IsOffCooldown(DangerZone) && gauge.AmmoComboStep != 1 && IsEnabled(CustomComboPreset.GunbreakerCDsOnGF))
                            return OriginalHook(DangerZone);
                        if ((HasEffect(Buffs.ReadyToRip) || HasEffect(Buffs.ReadyToTear) || HasEffect(Buffs.ReadyToGouge)) && level >= Levels.Continuation)
                            return OriginalHook(Continuation);
                    }

                    if ((gauge.AmmoComboStep == 0 && IsOffCooldown(GnashingFang)) || gauge.AmmoComboStep is 1 or 2)
                        return OriginalHook(GnashingFang);
                    if (IsEnabled(CustomComboPreset.GunbreakerCDsOnGF))
                    {
                        if (HasEffect(Buffs.NoMercy) && HasEffect(All.Buffs.Medicated) && gauge.AmmoComboStep == 0)
                        {
                            if (level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                                return Hypervelocity;
                            if ((gauge.Ammo != 0) && level >= Levels.BurstStrike)
                                return BurstStrike;
                        }

                        //final check if Burst Strike is used right before No Mercy ends
                        if (level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                            return Hypervelocity;
                    }
                }

                return actionID;
            }
        }

        internal class GunbreakerBurstStrikeConFeature : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerBurstStrikeConFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == BurstStrike && level >= Levels.EnhancedContinuation && HasEffect(Buffs.ReadyToBlast))
                    return Hypervelocity;
                return actionID;
            }
        }

        internal class GunbreakerDemonSlaughterCombo : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDemonSlaughterCombo;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                var gauge = GetJobGauge<GNBGauge>();
                if (actionID == DemonSlaughter)
                {
                    if (CanWeave(actionID))
                    {
                        if (IsEnabled(CustomComboPreset.GunbreakerNoMercyAOEOption) && IsOffCooldown(NoMercy) && level >= Levels.NoMercy)
                            return NoMercy;
                        if (IsEnabled(CustomComboPreset.GunbreakerBloodfestAOEOption) && gauge.Ammo == 0 && IsOffCooldown(Bloodfest) && level >= Levels.Bloodfest)
                            return Bloodfest;
                    }

                    if (IsEnabled(CustomComboPreset.GunbreakerDoubleDownAOEOption) && gauge.Ammo >= 2 && IsOffCooldown(DoubleDown) && level >= Levels.DoubleDown)
                        return DoubleDown;
                    if (IsEnabled(CustomComboPreset.GunbreakerBloodfestAOEOption) && gauge.Ammo != 0 && GetCooldownRemainingTime(Bloodfest) < 6 && level >= Levels.FatedCircle)
                        return FatedCircle;
                    if (comboTime > 0 && lastComboMove == DemonSlice && level >= Levels.DemonSlaughter)
                    {
                        if (IsEnabled(CustomComboPreset.GunbreakerAmmoOvercapFeature) && level >= Levels.FatedCircle && gauge.Ammo == MaxCartridges(level))
                            return FatedCircle;
                        if (IsEnabled(CustomComboPreset.GunbreakerBowShockFeature) && level >= Levels.BowShock && IsOffCooldown(BowShock))
                            return BowShock;
                        return DemonSlaughter;
                    }

                    return DemonSlice;
                }

                return actionID;
            }
        }

        internal class GunbreakerBloodfestOvercapFeature : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerBloodfestOvercapFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                var gauge = GetJobGauge<GNBGauge>().Ammo;
                if (actionID == BurstStrike && gauge == 0 && level >= Levels.Bloodfest && !HasEffect(Buffs.ReadyToBlast))
                    return Bloodfest;
                return actionID;
            }
        }

        internal class GunbreakerDDonBurstStrikeFeature : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDDonBurstStrikeFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                var gauge = GetJobGauge<GNBGauge>().Ammo;
                if (actionID == BurstStrike && HasEffect(Buffs.NoMercy) && IsOffCooldown(DoubleDown) && gauge >= 2)
                    return DoubleDown;
                return actionID;
            }
        }

        internal class GunbreakerCDsonNMFeature : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerCDsonNMFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == NoMercy)
                {
                    if (IsOnCooldown(NoMercy) && InCombat())
                    {
                        if (IsOffCooldown(SonicBreak))
                            return SonicBreak;
                        if (IsOffCooldown(BowShock))
                            return BowShock;
                    }
                }

                return actionID;
            }
        }

        internal class GunbreakerAuroraProtectionFeature : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerAuroraProtectionFeature;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == Aurora && HasEffect(Buffs.Aurora)) return WAR.NascentFlash;
                return actionID;
            }
        }
    }
}