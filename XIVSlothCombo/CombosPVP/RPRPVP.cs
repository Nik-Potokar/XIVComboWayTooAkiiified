using XIVSlothComboPlugin.Combos;

namespace XIVSlothComboPlugin
{
    internal static class RPRPVP
    {
        public const byte JobID = 39;

        internal const uint
            Slice = 29538,
            WaxingSlice = 29539,
            InfernalSlice = 29540,
            Gibbet = 29541,
            Gallows = 29542,
            VoidReaping = 29543,
            CrossReaping = 29544,
            HarvestMoon = 29545,
            PlentifulHarvest = 29546,
            GrimSwathe = 29547,
            LemuresSlice = 29548,
            DeathWarrant = 29549,
            HellsIngress = 29550,
            Regress = 29551,
            ArcaneCrest = 29552,
            TenebraeLemurum = 29553,
            Communio = 29554,
            SoulSlice = 29566;

        internal class Buffs
        {
            internal const ushort
                Soulsow = 2750,
                SoulReaver = 2854,
                GallowsOiled = 2856,
                Enshrouded = 2863,
                ImmortalSacrifice = 3204,
                PlentifulHarvest = 3205,
                HellsIngress = 3207;
        }

        internal class Debuffs
        {
            internal const ushort
                DeathWarrant = 3206;
        }
        public static class Config
        {
            public const string
                RPRPvPImmortalStackThreshold = "RPRPvPImmortalStackThreshold";
            public const string
                RPRPvPArcaneCircleOption = "RPRPvPArcaneCircleOption";
        }


        internal class RPRBurstMode : CustomCombo // Burst Mode
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RPRBurstMode; // Burst Mode Preset Name

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Slice or WaxingSlice or InfernalSlice)
                {

                    bool grimSwatheReady = !GetCooldown(GrimSwathe).IsCooldown;
                    bool lemuresSliceReady = !GetCooldown(LemuresSlice).IsCooldown;
                    bool arcaneReady = !GetCooldown(ArcaneCrest).IsCooldown;
                    var arcaneThreshold = Service.Configuration.GetCustomIntValue(Config.RPRPvPArcaneCircleOption);
                    bool deathWarrantReady = !GetCooldown(DeathWarrant).IsCooldown;
                    bool plentifulReady = !GetCooldown(PlentifulHarvest).IsCooldown;
                    var plentifulCD = GetCooldown(PlentifulHarvest).CooldownRemaining;
                    bool enshrouded = HasEffect(Buffs.Enshrouded);
                    var enshroudStacks = GetBuffStacks(Buffs.Enshrouded);
                    var immortalStacks = GetBuffStacks(Buffs.ImmortalSacrifice);
                    var immortalThreshold = Service.Configuration.GetCustomIntValue(Config.RPRPvPImmortalStackThreshold);
                    bool soulsow = HasEffect(Buffs.Soulsow);
                    bool canBind = !TargetHasEffect(PVPCommon.Debuffs.Bind);
                    bool GCDStopped = !GetCooldown(OriginalHook(Slice)).IsCooldown;
                    bool enemyGuarded = TargetHasEffectAny(PVPCommon.Buffs.Guard);
                    var HP = PlayerHealthPercentageHp();
                    bool canWeave = CanWeave(actionID);
                    var distance = GetTargetDistance();

                    // Arcane Cirle Option
                    if (IsEnabled(CustomComboPreset.RPRPvPArcaneCircleOption) && arcaneReady && HP <= arcaneThreshold)
                        return ArcaneCrest;

                    if (!enemyGuarded)
                    {
                        // Plentiful Harvest Opener
                        if (IsEnabled(CustomComboPreset.RPRPvPPlentifulOpenerOption) && !InCombat() && plentifulReady && distance <= 15)
                            return PlentifulHarvest;

                        // Harvest Moon Ranged Option
                        if (IsEnabled(CustomComboPreset.RPRPvPRangedHarvestMoonOption) && distance > 5 && soulsow && GCDStopped)
                            return HarvestMoon;

                        // Occurring inside of Enshroud burst
                        if (IsEnabled(CustomComboPreset.RPRPvPEnshroudedOption) && enshrouded)
                        {
                            if (canWeave)
                            {
                                // Enshrouded Death Warrant Option
                                if (IsEnabled(CustomComboPreset.RPRPvPEnshroudedDeathWarrantOption) && deathWarrantReady && enshroudStacks >= 3 && distance <= 25)
                                    return OriginalHook(DeathWarrant);

                                // Lemure's Slice
                                if (lemuresSliceReady && canBind && distance <= 8)
                                    return LemuresSlice;

                                // Harvest Moon proc
                                if (soulsow && distance <= 25)
                                    return OriginalHook(DeathWarrant);
                            }

                            // Communio Option
                            if (IsEnabled(CustomComboPreset.RPRPvPEnshroudedCommunioOption) && enshroudStacks == 1 && distance <= 25)
                            {
                                // Holds Communio when moving & Enshrouded Time Remaining > 2s
                                // Returns a Void/Cross Reaping if under 2s to avoid charge waste
                                if (this.IsMoving && GetBuffRemainingTime(Buffs.Enshrouded) > 2)
                                    return BLM.Xenoglossy;

                                // Returns Communio if stationary
                                // This doesn't work as an 'else if' and I can't be bothered to refactor it further
                                if (!this.IsMoving)
                                    return Communio;
                            }
                        }

                        // Occurring outside of Enshroud burst
                        if (!enshrouded)
                        {
                            // Death Warrant Option
                            if (IsEnabled(CustomComboPreset.RPRPvPDeathWarrantOption) && deathWarrantReady && distance <= 25
                                && (plentifulCD > 20 && immortalStacks < immortalThreshold || plentifulReady && immortalStacks >= immortalThreshold))
                                return OriginalHook(DeathWarrant);

                            // Plentiful Harvest Pooling Option
                            if (IsEnabled(CustomComboPreset.RPRPvPImmortalPoolingOption) && plentifulReady && immortalStacks >= immortalThreshold && TargetHasEffect(Debuffs.DeathWarrant) && distance <= 15)
                                return PlentifulHarvest;

                            // Weaves
                            if (canWeave)
                            {
                                // Harvest Moon Proc
                                if (soulsow && distance <= 25)
                                    return OriginalHook(DeathWarrant);

                                // Grim Swathe Option
                                if (IsEnabled(CustomComboPreset.RPRPvPGrimSwatheOption) && grimSwatheReady && distance <= 8)
                                    return GrimSwathe;
                            }
                        }
                    }

                    // Soul Slice
                    if (!enshrouded && distance <= 5 && (GetRemainingCharges(SoulSlice) == 2 || GetRemainingCharges(SoulSlice) > 0 && !HasEffect(Buffs.GallowsOiled) && !HasEffect(Buffs.SoulReaver)))
                        return SoulSlice;
                }

                return actionID;
            }
        }
    }
}