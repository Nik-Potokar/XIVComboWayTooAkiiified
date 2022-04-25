namespace XIVSlothComboPlugin.Combos
{
    internal static class MCHPVP
    {
        public const byte JobID = 31;

        public const uint
            BlastCharge = 29402,
            HeatBlast = 29403,
            Scattergun = 29404,
            Drill = 29405,
            BioBlaster = 29406,
            AirAnchor = 29407,
            ChainSaw = 29408,
            Wildfire = 29409,
            BishopTurret = 29412,
            AetherMortar = 29413,
            Analysis = 29414,
            MarksmanSpite = 29415;

        public static class Buffs
        {
            public const ushort
                Heat = 3148,
                Overheated = 3149,
                DrillPrimed = 3150,
                BioblasterPrimed = 3151,
                AirAnchorPrimed = 3152,
                ChainSawPrimed = 3153,
                Analysis = 3158;
        }

        public static class Debuffs
        {
            public const ushort
                Wildfire = 1323;
        }
    }

    internal class HeatedCleanShotFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MCHBurstMode;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCHPVP.BlastCharge)
            {
                var canWeave = CanWeave(actionID);
                var analysisStacks = GetRemainingCharges(MCHPVP.Analysis);
                var bigDamageStacks = GetRemainingCharges(OriginalHook(MCHPVP.Drill));
                var overheated = HasEffect(MCHPVP.Buffs.Overheated);

                if (canWeave && HasEffect(MCHPVP.Buffs.Overheated) && IsOffCooldown(MCHPVP.Wildfire))
                    return OriginalHook(MCHPVP.Wildfire);

                if (overheated)
                    return OriginalHook(MCHPVP.HeatBlast);

                if ((HasEffect(MCHPVP.Buffs.DrillPrimed) || 
                    (HasEffect(MCHPVP.Buffs.ChainSawPrimed) && !IsEnabled(CustomComboPreset.MCHAltAnalysis)) ||
                    (HasEffect(MCHPVP.Buffs.AirAnchorPrimed) && IsEnabled(CustomComboPreset.MCHAltAnalysis))) &&
                    !HasEffect(MCHPVP.Buffs.Analysis) && analysisStacks > 0 && (!IsEnabled(CustomComboPreset.MCHAltDrill)
                    || IsOnCooldown(MCHPVP.Wildfire)) && !canWeave && !overheated && bigDamageStacks > 0)
                    return OriginalHook(MCHPVP.Analysis);

                if (bigDamageStacks > 0)
                {
                    if (HasEffect(MCHPVP.Buffs.DrillPrimed))
                        return OriginalHook(MCHPVP.Drill);

                    if (HasEffect(MCHPVP.Buffs.BioblasterPrimed) && GetTargetDistance() <= 12)
                        return OriginalHook(MCHPVP.BioBlaster);

                    if (HasEffect(MCHPVP.Buffs.AirAnchorPrimed))
                        return OriginalHook(MCHPVP.AirAnchor);

                    if (HasEffect(MCHPVP.Buffs.ChainSawPrimed))
                        return OriginalHook(MCHPVP.ChainSaw);
                }
            }

            return actionID;
        }
    }
}