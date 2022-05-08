using XIVSlothComboPlugin.Combos;

namespace XIVSlothComboPlugin
{
    internal static class WARPVP
    {
        public const byte ClassID = 3;
        public const byte JobID = 21;
        internal const uint
            HeavySwing = 29074,
            Maim = 29075,
            StormsPath = 29076,
            PrimalRend = 29084,
            Onslaught = 29079,
            Orogeny = 29080,
            Blota = 29081,
            Bloodwhetting = 29082;

        internal class Buffs
        {
            internal const ushort
                NascentChaos = 1992,
                InnerRelease = 1303;
        }


        internal class WARBurstMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WARBurstMode;

            protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
            {
                if (actionID is HeavySwing or Maim or StormsPath)
                {
                    var canWeave = CanWeave(actionID);

                    if (!GetCooldown(Bloodwhetting).IsCooldown && (IsEnabled(CustomComboPreset.WARBurstOption) || canWeave))
                        return OriginalHook(Bloodwhetting);

                    if (!GetCooldown(PrimalRend).IsCooldown)
                        return OriginalHook(PrimalRend);

                    if (!InMeleeRange() && !GetCooldown(Blota).IsCooldown && !TargetHasEffectAny(PVPCommon.Debuffs.Stun) &&
                        (IsNotEnabled(CustomComboPreset.WARBurstBlotaOption) || GetCooldown(PrimalRend).CooldownRemaining >= 5))
                        return OriginalHook(Blota);

                    if (!GetCooldown(Onslaught).IsCooldown && canWeave)
                        return OriginalHook(Onslaught);

                    if (InMeleeRange())
                    {
                        if (HasEffect(Buffs.NascentChaos))
                            return OriginalHook(Bloodwhetting);

                        if (!GetCooldown(Orogeny).IsCooldown && canWeave)
                            return OriginalHook(Orogeny);
                    }
                }
                return actionID;
            }
        }
    }
}