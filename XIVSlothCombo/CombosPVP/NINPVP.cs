﻿using XIVSlothComboPlugin.Combos;

namespace XIVSlothComboPlugin
{
    internal static class NINPVP
    {
        public const byte ClassID = 18;
        public const byte JobID = 30;

        internal const uint
            SpinningEdge = 29500,
            GustSlash = 29501,
            AeolianEdge = 29502,
            FumaShuriken = 29505,
            Mug = 29509,
            ThreeMudra = 29507,
            Bunshin = 29511,
            Shukuchi = 29513,
            SeitonTenchu = 29515,
            ForkedRaiju = 29510,
            FleetingRaiju = 29707,
            HyoshoRanryu = 29506,
            GokaMekkyaku = 29504,
            Meisui = 29508,
            Huton = 29512,
            Doton = 29514,
            Assassinate = 29503;

        internal class Buffs
        {
            internal const ushort
                ThreeMudra = 1317,
                Hidden = 1316,
                Bunshin = 2010,
                ShadeShift = 2011;
        }

        internal class Debuffs
        {
            internal const ushort
                SealedHyoshoRanryu = 3194,
                SealedGokaMekkyaku = 3193,
                SealedHuton = 3196,
                SealedDoton = 3197,
                SeakedForkedRaiju = 3195,
                SealedMeisui = 3198;
        }


        internal class NINBurstMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NINBurstMode;

            protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
            {
                if (actionID is SpinningEdge or AeolianEdge or GustSlash)
                {
                    var threeMudrasCD = GetCooldown(ThreeMudra);
                    var fumaCD = GetCooldown(FumaShuriken);
                    var bunshinStacks = HasEffect(Buffs.Bunshin) ? GetBuffStacks(Buffs.Bunshin) : 0;
                    bool raijuLocked = HasEffect(Debuffs.SeakedForkedRaiju);
                    bool meisuiLocked = HasEffect(Debuffs.SealedMeisui);
                    bool hyoshoLocked = HasEffect(Debuffs.SealedHyoshoRanryu);
                    bool dotonLocked = HasEffect(Debuffs.SealedDoton);
                    bool gokaLocked = HasEffect(Debuffs.SealedGokaMekkyaku);
                    bool hutonLocked = HasEffect(Debuffs.SealedHuton);
                    bool mudraMode = HasEffect(Buffs.ThreeMudra);
                    bool canWeave = CanWeave(actionID);

                    if (HasEffect(Buffs.Hidden))
                        return OriginalHook(Assassinate);

                    if (canWeave)
                    {
                        if (InMeleeRange() && !GetCooldown(Mug).IsCooldown)
                            return OriginalHook(Mug);

                        if (!GetCooldown(Bunshin).IsCooldown)
                            return OriginalHook(Bunshin);

                        if (threeMudrasCD.RemainingCharges > 0 && !mudraMode)
                            return OriginalHook(ThreeMudra);
                    }

                    if (mudraMode)
                    {
                        if (!hyoshoLocked)
                            return OriginalHook(HyoshoRanryu);

                        if (!raijuLocked && bunshinStacks > 0)
                            return OriginalHook(ForkedRaiju);

                        if (!hutonLocked)
                            return Huton;
                    }

                    if (fumaCD.RemainingCharges > 0)
                        return OriginalHook(FumaShuriken);

                }

                return actionID;
            }
        }

        internal class NINAoEBurstMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NINAoEBurstMode;

            protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
            {
                if (actionID == FumaShuriken)
                {
                    var threeMudrasCD = GetCooldown(ThreeMudra);
                    var fumaCD = GetCooldown(FumaShuriken);
                    var bunshinStacks = HasEffect(Buffs.Bunshin) ? GetBuffStacks(Buffs.Bunshin) : 0;
                    bool raijuLocked = HasEffect(Debuffs.SeakedForkedRaiju);
                    bool meisuiLocked = HasEffect(Debuffs.SealedMeisui);
                    bool hyoshoLocked = HasEffect(Debuffs.SealedHyoshoRanryu);
                    bool dotonLocked = HasEffect(Debuffs.SealedDoton);
                    bool gokaLocked = HasEffect(Debuffs.SealedGokaMekkyaku);
                    bool hutonLocked = HasEffect(Debuffs.SealedHuton);
                    bool mudraMode = HasEffect(Buffs.ThreeMudra);
                    bool canWeave = CanWeave(actionID);

                    if (canWeave)
                    {
                        if (InMeleeRange() && !GetCooldown(Mug).IsCooldown)
                            return Mug;

                        if (!GetCooldown(Bunshin).IsCooldown)
                            return Bunshin;

                        if (threeMudrasCD.RemainingCharges > 0 && !mudraMode)
                            return OriginalHook(ThreeMudra);
                    }

                    if (mudraMode)
                    {
                        if (!dotonLocked)
                            return OriginalHook(Doton);

                        if (!gokaLocked)
                            return OriginalHook(GokaMekkyaku);
                    }

                    if (fumaCD.RemainingCharges > 0)
                        return OriginalHook(FumaShuriken);

                    if (InMeleeRange())
                    {
                        if (lastComboActionID == GustSlash)
                            return OriginalHook(AeolianEdge);

                        if (lastComboActionID == SpinningEdge)
                            return OriginalHook(GustSlash);

                        return OriginalHook(SpinningEdge);
                    }
                }

                return actionID;
            }
        }
    }
}