using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Objects.Enums;
using XIVSlothCombo.CustomComboNS;
using XIVSlothCombo.Extensions;

namespace XIVSlothCombo.Combos.PvE
{
    internal static class SGE
    {
        public const byte JobID = 40;

        public const uint

            // Heals and Shields
            Diagnosis = 24284,
            Prognosis = 24286,
            Physis = 24288,
            Druochole = 24296,
            Kerachole = 24298,
            Ixochole = 24299,
            Pepsis = 24301,
            Physis2 = 24302,
            Taurochole = 24303,
            Haima = 24305,
            Panhaima = 24311,
            Holos = 24310,
            EukrasianDiagnosis = 24291,
            EukrasianPrognosis = 24292,

            // DPS
            Dosis1 = 24283,
            Dosis2 = 24306,
            Dosis3 = 24312,
            EukrasianDosis1 = 24293,
            EukrasianDosis2 = 24308,
            EukrasianDosis3 = 24314,
            Phlegma = 24289,
            Phlegma2 = 24307,
            Phlegma3 = 24313,
            Dyskrasia = 24297,
            Dyskrasia2 = 24315,
            Toxikon = 24304,
            Pneuma = 24318,

            // Buffs
            Soteria = 24294,
            Zoe = 24300,
            Krasis = 24317,

            // Other
            Kardia = 24285,
            Eukrasia = 24290,
            Rhizomata = 24309,

            // Role
            Egeiro = 24287;

        public static class Buffs
        {
            public const ushort
                Kardia = 2604,
                Eukrasia = 2606,
                EukrasianDiagnosis = 2607,
                Kardion = 2872,
                EukrasianPrognosis = 2609;
        }

        public static class Debuffs
        {
            public const ushort
            EukrasianDosis1 = 2614,
            EukrasianDosis2 = 2615,
            EukrasianDosis3 = 2616;
        }

        public static class Levels // Per 6.1 Patch https://na.finalfantasyxiv.com/jobguide/sage/
        {
            public const byte
                Dosis = 1,
                Diagnosis = 2,
                Kardia = 4,
                Prognosis = 10,
                Egeiro = 12,
                Physis = 20,
                Phlegma = 26,
                Eukrasia = 30, // Includes Dosis, Diagnosis, & Prognosis
                Soteria = 35,
                Icarus = 40,
                Druochole = 45,
                Dyskrasia = 46,
                Kerachole = 50,
                Ixochole = 52,
                Zoe = 56,
                Pepsis = 58,
                Physis2 = 60,
                Taurochole = 62,
                Toxikon = 66,
                Haima = 70,
                Dosis2 = 72, // Includes Eukrasian Dosis 2 
                Phlegma2 = 72,
                Rhizomata = 74,
                Holos = 76,
                Panhaima = 80,
                Dosis3 = 82, // Includes Eukrasian Dosis 3
                Dyskrasia2 = 82,
                Phlegma3 = 82,
                Toxikon2 = 82,
                Krasis = 86,
                Pneuma = 90;
        }
        public static class Range
        {
            public const byte Phlegma = 6;
        }

        public static class Config
        {
            public const string
                // GUI Customization Storage Names
                SGE_ST_Dosis_EDosisHPPer = "SGE_ST_Dosis_EDosisHPPer",
                SGE_ST_Dosis_Lucid = "SGE_ST_Dosis_Lucid",
                SGE_ST_Dosis_Toxikon = "SGE_ST_Dosis_Toxikon",
                SGE_ST_Heal_Zoe = "SGE_ST_Heal_Zoe",
                SGE_ST_Heal_Haima = "SGE_ST_Heal_Haima",
                SGE_ST_Heal_Krasis = "SGE_ST_Heal_Krasis",
                SGE_ST_Heal_Pepsis = "SGE_ST_Heal_Pepsis",
                SGE_ST_Heal_Soteria = "SGE_ST_Heal_Soteria",
                SGE_ST_Heal_Diagnosis = "SGE_ST_Heal_Diagnosis",
                SGE_ST_Heal_Druochole = "SGE_ST_Heal_Druochole",
                SGE_ST_Heal_Taurochole = "SGE_ST_Heal_Taurochole",
                SGE_AoE_Phlegma_Lucid = "SGE_AoE_Phlegma_Lucid";
        }



        // SageSoteriaKardia
        // Soteria becomes Kardia when Kardia's Buff is not active or Soteria is on cooldown.
        internal class SGE_Kardia : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Kardia;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Soteria &&
                    (!HasEffect(Buffs.Kardia) || IsOnCooldown(Soteria))
                   ) return Kardia;
                else return actionID;
            }
        }

        /*
        SageRhizomata
        Replaces all Addersgal using Abilities (Taurochole/Druochole/Ixochole/Kerachole) with Rhizomata if out of Addersgall stacks
        (Scholar speak: Replaces all Aetherflow abilities with Aetherflow when out)
        */
        internal class SGE_Rhizo : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Rhizo;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Taurochole or Druochole or Ixochole or Kerachole &&
                    Rhizomata.LevelChecked() &&
                    IsOffCooldown(actionID) &&
                    GetJobGauge<SGEGauge>().Addersgall == 0
                   ) return Rhizomata;
                else return actionID;
            }
        }

        /*
        SageDruoTauro
        Druochole Upgrade to Taurochole (like a trait upgrade)
        Replaces Druocole with Taurochole when Taurochole is available
        (As of 6.0) Taurochole (single target massive insta heal w/ cooldown), Druochole (Single target insta heal)
        */
        internal class SGE_DruoTauro : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_DruoTauro;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Druochole && Taurochole.LevelChecked() && IsOffCooldown(Taurochole)) return Taurochole;
                else return actionID;
            }
        }

        //SageZoePneumaFeature
        //Places Zoe on top of Pneuma when both are available.
        internal class SGE_ZoePneuma : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ZoePneuma;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Pneuma && Pneuma.LevelChecked() && IsOffCooldown(Pneuma) && IsOffCooldown(Zoe)) return Zoe;
                else return actionID;
            }
        }

        // Sage AoE / Phlegma Replacement
        // Replaces Zero Charges/Stacks of Phlegma with Toxikon (if you can use it) or Dyskrasia 
        internal class SGE_AoE_Phlegma : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_AoE_Phlegma;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Phlegma or Phlegma2 or Phlegma3)
                {
                    //Lucid Dreaming
                    if (IsEnabled(CustomComboPreset.SGE_AoE_Phlegma_Lucid) &&
                        level >= All.Levels.LucidDreaming &&
                        IsOffCooldown(All.LucidDreaming) &&
                        LocalPlayer.CurrentMp <= GetOptionValue(Config.SGE_AoE_Phlegma_Lucid) &&
                        CanSpellWeave(actionID)
                       ) return All.LucidDreaming;

                    var NoPhlegmaToxikon  = IsEnabled(CustomComboPreset.SGE_AoE_Phlegma_NoPhlegmaToxikon);
                    var OutOfRangeToxikon = IsEnabled(CustomComboPreset.SGE_AoE_Phlegma_OutOfRangeToxikon);
                    if ((NoPhlegmaToxikon || OutOfRangeToxikon) &&
                        Toxikon.LevelChecked() &&
                        CurrentTarget.IsEnemy() && 
                        GetJobGauge<SGEGauge>().Addersting > 0)
                    {
                        if ((NoPhlegmaToxikon && GetCooldown(OriginalHook(Phlegma)).RemainingCharges == 0) ||
                            (OutOfRangeToxikon && (GetTargetDistance() > Range.Phlegma)))
                            return OriginalHook(Toxikon);
                    }
                    var NoPhlegmaDyskrasia = IsEnabled(CustomComboPreset.SGE_AoE_Phlegma_NoPhlegmaDyskrasia);
                    var NoTargetDyskrasia  = IsEnabled(CustomComboPreset.SGE_AoE_Phlegma_NoTargetDyskrasia);
                    if ((NoPhlegmaDyskrasia || NoTargetDyskrasia) &&
                        Phlegma.LevelChecked())
                    {
                        if ((NoPhlegmaDyskrasia && GetCooldown(OriginalHook(Phlegma)).RemainingCharges == 0) ||
                            (NoTargetDyskrasia && CurrentTarget is null))
                            return OriginalHook(Dyskrasia);
                    }
                }
                return actionID;
            }
        }

        /*
        Single Target Dosis Combo
        Currently Replaces Dosis with Eukrasia when the debuff on the target is < 3 seconds or not existing
        Lucid Dreaming, Target of Target optional
        */
        internal class SGE_ST_Dosis : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ST_Dosis;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Dosis1 or Dosis2 or Dosis3 && InCombat())
                {
                    //Lucid Dreaming
                    if (IsEnabled(CustomComboPreset.SGE_ST_Dosis_Lucid) &&
                        level >= All.Levels.LucidDreaming &&
                        IsOffCooldown(All.LucidDreaming) &&
                        LocalPlayer.CurrentMp <= GetOptionValue(Config.SGE_ST_Dosis_Lucid) &&
                        CanSpellWeave(actionID)
                       ) return All.LucidDreaming;

                    //Eukrasian Dosis.
                    //If we're too low level to use Eukrasia, we can stop here.
                    if (IsEnabled(CustomComboPreset.SGE_ST_Dosis_EDosis) && 
                        Eukrasia.LevelChecked() &&
                        CurrentTarget.IsEnemy())
                    {
                        //If we're already Eukrasian'd, the whole point of this section is moot
                        if (HasEffect(Buffs.Eukrasia)) return OriginalHook(Dosis1); //OriginalHook will autoselect the correct Dosis for us

                        //Determine which Dosis debuff to check
                        var DosisDebuffID = level switch
                        {
                            //Using FindEffect b/c we have a custom Target variable
                            >= Levels.Dosis3 => FindTargetEffect(Debuffs.EukrasianDosis3),
                            >= Levels.Dosis2 => FindTargetEffect(Debuffs.EukrasianDosis2),
                            //Ekrasia Dosis unlocks with Eukrasia, checked at the start
                            _ => FindTargetEffect(Debuffs.EukrasianDosis1),
                        };

                        //Got our Debuff for our level, check for it and procede 
                        if (((DosisDebuffID is null) || (DosisDebuffID.RemainingTime <= 3)) &&
                            (CurrentTarget.GetHPPercent() > GetOptionValue(Config.SGE_ST_Dosis_EDosisHPPer))
                           ) return Eukrasia;
                    }

                    //Toxikon
                    if (IsEnabled(CustomComboPreset.SGE_ST_Dosis_Toxikon) &&
                        Toxikon.LevelChecked() &&
                        CurrentTarget.IsEnemy() &&
                        ((!GetOptionBool(Config.SGE_ST_Dosis_Toxikon) && IsMoving) || GetOptionBool(Config.SGE_ST_Dosis_Toxikon)) &&
                        GetJobGauge<SGEGauge>().Addersting > 0
                       ) return OriginalHook(Toxikon);
                }
                return actionID;
            }
        }

        // Swiftcast combos to Egeiro (Raise) while Swiftcast is on cooldown
        internal class SGE_Raise : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Raise;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is All.Swiftcast && IsOnCooldown(All.Swiftcast)) return Egeiro;
                else return actionID;
            }
        }

        internal class SGE_ST_Heal : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ST_Heal;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Diagnosis)
                {
                    if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Druochole) &&
                        Druochole.LevelChecked() &&
                        IsOffCooldown(Druochole) &&
                        GetJobGauge<SGEGauge>().Addersgall >= 1 &&
                        CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Druochole)
                       ) return Druochole;

                    if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Taurochole) &&
                        Taurochole.LevelChecked() &&
                        IsOffCooldown(Taurochole) &&
                        GetJobGauge<SGEGauge>().Addersgall >= 1 &&
                        CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Taurochole)
                       ) return Taurochole;

                    if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Rhizomata) &&
                        Rhizomata.LevelChecked() &&
                        IsOffCooldown(Rhizomata) &&
                        GetJobGauge<SGEGauge>().Addersgall is 0
                       ) return Rhizomata;

                    if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Kardia) &&
                        Kardia.LevelChecked() &&
                        FindEffect(Buffs.Kardia) is null &&
                        FindTargetEffect(Buffs.Kardion) is null
                       ) return Kardia;

                    if (CurrentTarget.IsPlayer())
                    {
                        if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Soteria) &&
                            Soteria.LevelChecked() &&
                            IsOffCooldown(Soteria) &&
                            CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Soteria)
                           ) return Soteria;

                        if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Zoe) &&
                            Zoe.LevelChecked() &&
                            IsOffCooldown(Zoe) &&
                            CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Zoe)
                           ) return Zoe;

                        if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Krasis) &&
                            Krasis.LevelChecked() &&
                            IsOffCooldown(Krasis) && CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Krasis)
                           ) return Krasis;

                        if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Pepsis) &&
                            Pepsis.LevelChecked() &&
                            IsOffCooldown(Pepsis) && CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Pepsis) &&
                            FindTargetEffect(Buffs.EukrasianDiagnosis) is not null
                           ) return Pepsis;

                        if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Haima) &&
                            Haima.LevelChecked() &&
                            IsOffCooldown(Haima) && CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Haima)
                           ) return Haima;
                    }

                    if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Diagnosis) &&
                        Eukrasia.LevelChecked() &&
                        FindTargetEffect(Buffs.EukrasianDiagnosis) is null &&
                        CurrentTarget.GetHPPercent() <= GetOptionValue(Config.SGE_ST_Heal_Diagnosis))
                    {
                        if (!HasEffect(Buffs.Eukrasia))
                            return Eukrasia;
                        else return EukrasianDiagnosis;
                    }
                }
                return actionID;
            }
        }

        internal class SGE_AoE_Heal : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_AoE_Heal;
            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Prognosis)
                {
                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Rhizomata) &&
                        Rhizomata.LevelChecked() &&
                        IsOffCooldown(Rhizomata) &&
                        GetJobGauge<SGEGauge>().Addersgall is 0
                       ) return Rhizomata;

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Kerachole) &&
                        Kerachole.LevelChecked() &&
                        IsOffCooldown(Kerachole) &&
                        GetJobGauge<SGEGauge>().Addersgall >= 1
                       ) return Kerachole;

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Ixochole) &&
                        Ixochole.LevelChecked() &&
                        IsOffCooldown(Ixochole) &&
                        GetJobGauge<SGEGauge>().Addersgall >= 1
                       ) return Ixochole;

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Physis) &&
                        Physis.LevelChecked() &&
                        IsOffCooldown(OriginalHook(Physis))
                       ) return OriginalHook(Physis);

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_EPrognosis) &&
                        Eukrasia.LevelChecked() &&
                        FindEffect(Buffs.EukrasianPrognosis) is null)
                    {
                        if (!HasEffect(Buffs.Eukrasia))
                            return Eukrasia;
                        if (HasEffect(Buffs.Eukrasia))
                            return EukrasianPrognosis;
                    }

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Holos) &&
                        Holos.LevelChecked() &&
                        IsOffCooldown(Holos)
                       ) return Holos;

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Panhaima) &&
                        Panhaima.LevelChecked() &&
                        IsOffCooldown(Panhaima)
                       ) return Panhaima;

                    if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Pepsis) &&
                        Pepsis.LevelChecked() &&
                        IsOffCooldown(Pepsis) &&
                        FindEffect(Buffs.EukrasianPrognosis) is not null
                       ) return Pepsis;
                }
                return actionID;
            }
        }
    }
}