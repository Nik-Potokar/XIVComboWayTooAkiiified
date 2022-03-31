using XIVSlothComboPlugin.Attributes;
using XIVSlothComboPlugin.Combos;

namespace XIVSlothComboPlugin
{
    /// <summary>
    /// Combo presets.
    /// </summary>
    public enum CustomComboPreset
    {
        // ====================================================================================
        #region Misc

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", ADV.JobID)]
        AdvAny = 0,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", AST.JobID)]
        AstAny = AdvAny + AST.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BLM.JobID)]
        BlmAny = AdvAny + BLM.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BRD.JobID)]
        BrdAny = AdvAny + BRD.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DNC.JobID)]
        DncAny = AdvAny + DNC.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOH.JobID)]
        DohAny = AdvAny + DOH.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOL.JobID)]
        DolAny = AdvAny + DOL.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRG.JobID)]
        DrgAny = AdvAny + DRG.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRK.JobID)]
        DrkAny = AdvAny + DRK.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", GNB.JobID)]
        GnbAny = AdvAny + GNB.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MCH.JobID)]
        MchAny = AdvAny + MCH.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MNK.JobID)]
        MnkAny = AdvAny + MNK.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", NIN.JobID)]
        NinAny = AdvAny + NIN.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PLD.JobID)]
        PldAny = AdvAny + PLD.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RDM.JobID)]
        RdmAny = AdvAny + RDM.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RPR.JobID)]
        RprAny = AdvAny + RPR.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SAM.JobID)]
        SamAny = AdvAny + SAM.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SCH.JobID)]
        SchAny = AdvAny + SCH.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SGE.JobID)]
        SgeAny = AdvAny + SGE.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SMN.JobID)]
        SmnAny = AdvAny + SMN.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
        WarAny = AdvAny + WAR.JobID,

        [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
        WhmAny = AdvAny + WHM.JobID,

        [CustomComboInfo("Disabled", "This should not be used.", ADV.JobID)]
        Disabled = 99999,

        #endregion
        // ====================================================================================
        #region ADV
        #endregion
        /*
        #region GLOBAL FEATURES
        [CustomComboInfo("Global Interrupt Feature", "Replaces Stun (LowBlow) with interrupt (Interject) when the target can be interrupted.", All.JobID)]
        InterruptFeature = 90000,

        [ConflictingCombos(SchRaiseFeature, WHMRaiseFeature, AstrologianAscendFeature, SageEgeiroFeature)]
        [CustomComboInfo("Global Raise Feature", "Replaces Swiftcast with Raise/Resurrection/Verraise/Ascend/Egeiro when appropriate.", All.JobID)]
        DoMSwiftcastFeature = 90001,

        #endregion
        */
        // ====================================================================================
        #region ASTROLOGIAN

        [CustomComboInfo("Draw on Play", "Play turns into Draw when no card is drawn, as well as the usual Play behavior.", AST.JobID)]
        AstrologianCardsOnDrawFeaturelikewhat = 1000,

        [CustomComboInfo("Minor Arcana to Crown Play", "Changes Minor Arcana to Crown Play when a card is not drawn or has Lord Or Lady Buff.", AST.JobID)]
        AstrologianCrownPlayFeature = 1001,

        [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID)]
        AstrologianBeneficFeature = 1002,

        [ConflictingCombos(AstrologianAlternateAscendFeature)]
        [CustomComboInfo("AST Raise Feature", "Changes Swiftcast to Ascend", AST.JobID)]
        AstrologianAscendFeature = 1003,

        [ConflictingCombos(AstrologianAscendFeature)]
        [CustomComboInfo("AST Raise Alternate Feature", "Changes Resurrection To Swiftcast when Swiftcast is available", AST.JobID)]
        AstrologianAlternateAscendFeature = 1019,

        [ConflictingCombos(AstrologianAlternateDpsFeature, CustomValuesTest)]
        [CustomComboInfo("DPS Feature(On Malefic)", "Adds Combust to the main malefic combo whenever the debuff is not present or about to expire", AST.JobID)]
        AstrologianDpsFeature = 1004,

        [CustomComboInfo("Lucid Dreaming Feature", "Adds Lucid dreaming to the DPS feature when below 8k mana", AST.JobID)]
        AstrologianLucidFeature = 1008,

        [CustomComboInfo("Astrodyne Feature", "Adds Astrodyne to the DPS feature when ready", AST.JobID)]
        AstrologianAstrodyneFeature = 1009,

        [CustomComboInfo("Aspected Helios Feature", "Replaces Aspected Helios whenever you are under Aspected Helios regen with Helios", AST.JobID)]
        AstrologianHeliosFeature = 1010,

        [CustomComboInfo("Auto Card Draw", "Adds Auto Card Draw Onto Main DPS Feature", AST.JobID)]
        AstrologianAutoDrawFeature = 1011,

        [CustomComboInfo("Auto Crown Card Draw", "Adds Auto Crown Card Draw Onto Main DPS Feature ", AST.JobID)]
        AstrologianAutoCrownDrawFeature = 1012,

        [CustomComboInfo("AoE DPS Feature", "Adds AutoDraws/Astrodyne to the AoE Gravity combo", AST.JobID)]
        AstrologianDpsAoEFeature = 1013,

        [CustomComboInfo("LazyLordFeature", "Adds LordOfCrowns Onto Main DPS/AoE Feature", AST.JobID)]
        AstrologianLazyLordFeature = 1014,

        [CustomComboInfo("Astrodyne On Play", "Play becomes Astrodyne when you have 3 seals.", AST.JobID)]
        AstrologianAstrodyneOnPlayFeature = 1015,

        [ConflictingCombos(AstrologianDpsFeature)]
        [CustomComboInfo("Alternate DPS Feature(On Combust)", "Adds Combust to the main malefic combo whenever the debuff is not present or about to expire", AST.JobID)]
        AstrologianAlternateDpsFeature = 1016,

        [ConflictingCombos(AstrologianDpsFeature, AstrologianAlternateDpsFeature)]
        [CustomComboInfo("DPS Feature Custom Values Testing", "Same as DPSFeature(OnMalefic).Allows you to customize target MaxHp & CurrentPercentageHp & CurrentHp checks. Testing Only! ", AST.JobID)]
        CustomValuesTest = 1017,

        [ParentCombo(AstrologianDpsFeature)]
        [ConflictingCombos(AstrologianAlternateDpsFeature)]
        [CustomComboInfo("Removes DoT From DPS Feature", "Removed DoT From the DPS Feature, You can still use all other features that are on malefic! ", AST.JobID)]
        DisableCombustOnDpsFeature = 1018,

        [CustomComboInfo("Lightspeed Feature", "Adds Lightspeed to the DPS Feature", AST.JobID)]
        AstrologianLightSpeedFeature = 1020,

        #endregion
        // ====================================================================================
        #region BLACK MAGE


        [CustomComboInfo("Enochian Stance Switcher ++", "Change Scathe to Fire 4 or Blizzard 4 depending on stance. \nScathe becomes all in one rotation. \nIf Thunder Feature is turned on it also adds Thunder3 proces onto all in one combo when DoT is about to expire or dosen't exist \n This REQUIRES other features to be turned on!!!", BLM.JobID)]
        BlackEnochianFeature = 2000,

        [CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
        BlackManaFeature = 2001,

        [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
        BlackLeyLinesFeature = 2002,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Blizzard 1/2/3 Feature", "Blizzard 1 becomes Blizzard 3 when out of Umbral Ice. Freeze becomes Blizzard 2 when synced.", BLM.JobID)]
        BlackBlizzardFeature = 2003,

        [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
        BlackScatheFeature = 2004,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Fire 1/3", "Fire 1 becomes Fire 3 outside of Astral Fire, OR when Firestarter proc is up.", BLM.JobID)]
        BlackFire13Feature = 2005,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Thunder", "Thunder 1/3 replaces Enochian/Fire 4/Blizzard 4 on Enochian switcher.\n Occurs when Thundercloud is up and either\n- Thundercloud buff on you is about to run out, or\n- Thunder debuff on your CURRENT target is about to run out\nassuming it won't interrupt timer upkeep.\nEnochian Stance Switcher must be active.", BLM.JobID)]
        BlackThunderFeature = 2006,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Despair Feature", "Despair replaces Fire 4 when below 2400 MP.\nEnochian Stance Switcher must be active.", BLM.JobID)]
        BlackDespairFeature = 2007,

        [CustomComboInfo("AoE Combo Feature", "One Button AoE Feature that adds whole AoE rotation onto FLARE (TESTING ONLY!!!)", BLM.JobID)]
        BlackAoEComboFeature = 2008,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Blizzard Paradox Feature", "Adds Paradox onto ice phase combo", BLM.JobID)]
        BlackBlizzardParadoxFeature = 2009,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Aspect Swap Feature", "Changes Scathe to Blizzard 3 when at 0 MP in Astral Fire or to Fire 3 when at 10000 MP in Umbral Ice with 3 Umbral Hearts.", BLM.JobID)]
        BlackAspectSwapFeature = 2010,

        [ParentCombo(BlackThunderFeature)]
        [CustomComboInfo("Thunder Uptime Feature", "Changes Scathe to Thunder 1/3 when not detected on target.", BLM.JobID)]
        BlackThunderUptimeFeature = 2011,

        [ParentCombo(BlackAspectSwapFeature)]
        [CustomComboInfo("Manafont Feature", "Adds Manafont when 0 mana in astral fire phase and available to weave.", BLM.JobID)]
        BlackManafontFeature = 2012,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Polygot Overcap Feature", "Changes Scathe to Xenoglossy / Foul when polygot stacks are capped.", BLM.JobID)]
        BlackPolygotFeature = 2013,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Sharpcast Feature", "Changes Scathe to Sharpcast when available to weave.", BLM.JobID)]
        BlackSharpcastFeature = 2014,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Amplifier Feature", "Changes Scathe to Amplifier when available to weave.", BLM.JobID)]
        BlackAmplifierFeature = 2015,

        [CustomComboInfo("Ley Lines Auto Feature", "Changes to Scathe to Ley Lines when available to weave.", BLM.JobID)]
        BlackLeyLinesAutoFeature = 2016,

        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Enochain Recovery Feature", "Changes Scathe to Fire3 / Blizzard3 depending on current player's mana when enochain is inactive.", BLM.JobID)]
        BlackEnochainRecoveryFeature = 2017,

        #endregion
        // ====================================================================================
        #region BLUE MAGE

        [CustomComboInfo("Buffed Song of Torment", "Turns Song of Torment into Bristle so SoT is buffed. \nSpells Required: Song of Torment.", BLU.JobID)]
        BluBuffedSoT = 70000,

        [CustomComboInfo("Moon Flute Opener", "Puts the Full Moon Flute Opener on Moon Flute or Whistle. \nSpells Required: Whistle, Tingle, Moon Flute, J Kick, Triple Trident, Nightbloom, Rose of Destruction, Feather Rain, Bristle, Glass Dance, Surpanakha, Matra Magic, Shock Strike, Phantom Flurry.", BLU.JobID)]
        BluOpener = 70001,

        [CustomComboInfo("Final Sting Combo", "Turns Final Sting into the buff combo of: Moon Flute, Tingle, Whistle, Final Sting. Will use any primals off CD before casting Final Sting. \nSpells Required: Moon Flute, Tingle, Whistle, Final Sting", BLU.JobID)]
        BluFinalSting = 70002,

        [ParentCombo(BluFinalSting)]
        [CustomComboInfo("Off CD Primal Additions", "Adds any Primals that are off CD to the Final Sting Combo. \nPrimals Used: Feather Rain, Shock Strike, Glass Dance, J Kick, Rose of Destruction. ", BLU.JobID)]
        BluPrimals = 70003,

        [CustomComboInfo("Swiftcasted Angel Whisper", "Turns Angel Whisper to Swiftcast when Swiftcast and Angel Whisper are available. \nSpells required: Angel Whisper ", BLU.JobID)]
        BluRez = 70004,

        [CustomComboInfo("Ram's Voice into Ultravibration", "Turns Ultravibration into Ram's Voice if Deep Freeze isn't on the target. Will swiftcast Ultravibration if available. \nSpells Required: Ram's Voice, Ultravibration. ", BLU.JobID)]
        BluUltravibrate = 70005,

        [CustomComboInfo("Tank Debuff Feature", "Puts Devour, Off-Guard, Lucid Dreaming, and Bad Breath into one button when under Tank Mimicry. \nSpells Required: Devour, Off-Guard, Bad Breath.", BLU.JobID)]
        BluDebuffCombo = 70006,

        [CustomComboInfo("Addle/Magic Hammer Debuff Feature", "Turns Magic Hammer into Addle when off CD. \nSpells Required: Magic Hammer.", BLU.JobID)]
        BluAddleFeature = 70007,

        [CustomComboInfo("Primal Feature", "Turns Feather Rain into any Primals that are off CD. \nSpells Required: Feather Rain, Shock Strike, The Rose of Destruction, Glass Dance, J Kick. \nWill cause primals to desync from Moon Flute burst phases if used on CD.", BLU.JobID)]
        BluPrimalFeature = 70008,

        [CustomComboInfo("Knight's Tour Feature", "Turns Black Knight's Tour or White Knight's Tour into its counterpart when the enemy is under the effect of the spell's debuff. \nSpells Required: White Knight's Tour, Black Knight's Tour", BLU.JobID)]
        BluKnightFeature = 70009,

        [CustomComboInfo("Peripheral Synthesis into Mustard Bomb", "Turns Peripheral Synthesis into Mustard Bomb when target is under the effect of Lightheaded. \nSpells Required: Peripheral Synthesis, Mustard Bomb.", BLU.JobID)]
        BluLightheadedCombo = 70010,


        #endregion
        // ====================================================================================
        #region BARD

        [CustomComboInfo("Wanderer's into Pitch Perfect", "Replaces Wanderer's Minuet with Pitch Perfect while in WM.", BRD.JobID)]
        BardWanderersPitchPerfectFeature = 3000,

        [ConflictingCombos(SimpleBardFeature)]
        [CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID)]
        BardStraightShotUpgradeFeature = 3001,

        [ConflictingCombos(SimpleBardFeature)]
        [ParentCombo(BardStraightShotUpgradeFeature)]
        [CustomComboInfo("Dot Maintenance Option", "Enabling this option will make Heavy Shot into Straight Shot refresh your dots on target when needed if there are any dots present.", BRD.JobID)]
        BardDoTMaintain = 3002,

        [ConflictingCombos(BardIronJawsAlternateFeature)]
        [CustomComboInfo("Iron Jaws Feature", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID)]
        BardIronJawsFeature = 3003,

        [ConflictingCombos(BardIronJawsFeature)]
        [CustomComboInfo("Iron Jaws Alternate Feature", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nIron Jaws will only show up when debuffs are about to expire.", BRD.JobID)]
        BardIronJawsAlternateFeature = 3004,

        [ConflictingCombos(SimpleBardFeature)]
        [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replaces Burst Shot and Quick Nock with Apex Arrow when gauge is full and Blast Arrow when you are Blast Arrow ready.", BRD.JobID)]
        BardApexFeature = 3005,

        [ConflictingCombos(SimpleBardFeature)]
        [CustomComboInfo("Single Target oGCD Feature", "All oGCD's on Bloodletter (+ Songs rotation) depending on their CD.", BRD.JobID)]
        BardoGCDSingleTargetFeature = 3006,

        [CustomComboInfo("AoE oGCD Feature", "All AoE oGCD's on RainOfDeath depending on their CD.", BRD.JobID)]
        BardoGCDAoEFeature = 3007,

        [ConflictingCombos(BardSimpleAoEFeature)]
        [CustomComboInfo("AoE Combo Feature", "Replaces QuickNock/Ladonsbite with Shadowbite when ready", BRD.JobID)]
        BardAoEComboFeature = 3008,

        [CustomComboInfo("SimpleBard", "Adds every single target ability except DoTs to one button,\nIf there are DoTs on target SimpleBard will try to maintain their uptime.", BRD.JobID)]
        SimpleBardFeature = 3009,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("SimpleBard DoT Option", "This option will make SimpleBard apply DoTs if none are present on the target.", BRD.JobID)]
        SimpleDoTOption = 3010,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("SimpleBard Song Option", "This option adds the bards songs to the SimpleBard feature.", BRD.JobID)]
        SimpleSongOption = 3011,

        [ParentCombo(BardoGCDAoEFeature)]
        [CustomComboInfo("Song Feature", "Adds Songs onto AoE oGCD Feature.", BRD.JobID)]
        BardSongsFeature = 3012,

        [CustomComboInfo("Bard Buffs Feature", "Adds RagingStrikes and BattleVoice onto Barrage.", BRD.JobID)]
        BardBuffsFeature = 3013,

        [CustomComboInfo("One Button Songs", "Add Mage's Ballade and Army's Paeon to Wanderer's Minuet depending on cooldowns", BRD.JobID)]
        BardOneButtonSongs = 3014,

        [CustomComboInfo("Simple AoE Bard", "Weaves oGCDs onto Quick Nock/Ladonsbite", BRD.JobID)]
        BardSimpleAoEFeature = 3015,

        [ParentCombo(BardSimpleAoEFeature)]
        [CustomComboInfo("Simple AoE Bard Song Option", "Weave songs on the Simple AoE", BRD.JobID)]
        SimpleAoESongOption = 3016,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Buffs Feature", "Adds buffs onto the SimpleBard feature.", BRD.JobID)]
        BardSimpleBuffsFeature = 3017,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Buffs - Radiant", "Adds Radiant Finale to the Simple Buffs feature.", BRD.JobID)]
        BardSimpleBuffsRadiantFeature = 3018,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Raid Mode", "Removes enemy health checking on mobs for buffs, dots and songs.", BRD.JobID)]
        BardSimpleRaidMode = 3019,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Interrupt", "Uses interrupt during simple bard rotation if applicable", BRD.JobID)]
        BardSimpleInterrupt = 3020,

        [CustomComboInfo("Disable ApexArrow From SimpleBard", "Removes Apex Arrow from SimpleBard and AoE Feature.", BRD.JobID)]
        BardRemoveApexArrowFeature = 3021,

        [ConflictingCombos(BardoGCDSingleTargetFeature)]
        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Opener", "BETA TESTING - Adds the optimum opener to simple bard.\nThis conflicts with pretty much everything outside of simple bard options due to the nature of the opener.", BRD.JobID)]
        BardSimpleOpener = 3022,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple Pooling", "BETA TESTING - Pools bloodletter chargers to allow for optimum burst phases", BRD.JobID)]
        BardSimplePooling = 3023,

        [ParentCombo(BardIronJawsFeature)]
        [CustomComboInfo("Iron Jaws Apex", "Adds apex and blast arrow to IRON JAWS when available", BRD.JobID)]
        BardIronJawsApexFeature = 3024,

        [ParentCombo(SimpleBardFeature)]
        [CustomComboInfo("Simple RagingJaws", "BETA TESTING - Enable the snapshotting of dots, within the remaining time of Raging Strikes below:", BRD.JobID)]
        BardSimpleRagingJaws = 3025,

        #endregion
        // ====================================================================================
        #region DANCER

        // Single Target Multibutton Section
        [CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID)]
        DancerSingleTargetMultibutton = 4000,

        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("ST Esprit Overcap Option", "Adds Saber Dance to the Cascade combo if you are at 85 or more Esprit.", DNC.JobID)]
        DancerEspritOvercapSTFeature = 4001,

        [ParentCombo(DancerEspritOvercapSTFeature)]
        [CustomComboInfo("ST Instant Saber Option", "Adds Saber Dance to the Cascade combo if you have at least 50 Esprit.", DNC.JobID)]
        DancerEspritOvercapSTInstantOption = 4002,

        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("Fan Dance Overcap Protection", "Adds Fan Dance 1 onto Cascade when Fourfold Feathers are full.", DNC.JobID)]
        DancerFanDanceMainComboOvercapFeature = 4003,

        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("FanDance On Cascade Feature", "Adds Fan Dance 3/4 onto Cascade when available.", DNC.JobID)]
        DancerFanDance34OnMainComboFeature = 4004,


        // AoE Multibutton Section
        [CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID)]
        DancerAoEMultibutton = 4010,

        [ParentCombo(DancerAoEMultibutton)]
        [CustomComboInfo("AoE Esprit Overcap Option", "Adds Saber Dance to the Windmill combo if you are at 85 or more Esprit.", DNC.JobID)]
        DancerEspritOvercapAoEFeature = 4011,

        [ParentCombo(DancerEspritOvercapAoEFeature)]
        [CustomComboInfo("AoE Instant Saber Option", "Adds Saber Dance to the Windmill combo if you have at least 50 Esprit.", DNC.JobID)]
        DancerEspritOvercapAoEInstantOption = 4012,

        [ParentCombo(DancerAoEMultibutton)]
        [CustomComboInfo("FanDance On Windmill Feature", "Adds FanDance 2/3/4 Onto Windmill When available", DNC.JobID)]
        DancerFanDanceOnAoEComboFeature = 4013,


        // Dance Features Section (SS/TS)
        [CustomComboInfo("Dance Features", "Features and options involving Standard Step and Technical Step.\nCollapsing this category does NOT disable the features inside.", DNC.JobID)]
        DancerMenuDanceFeatures = 4020,

        [ParentCombo(DancerMenuDanceFeatures)]
        [ConflictingCombos(DancerDanceComboCompatibility, DancerCombinedDanceFeature)]
        [CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID)]
        DancerDanceStepCombo = 4021,

        [ParentCombo(DancerMenuDanceFeatures)]
        [ConflictingCombos(DancerDanceComboCompatibility, DancerDanceStepCombo)]
        [CustomComboInfo("Combined Dance Feature", "Standard And Technical Dance on one button (SS). Standard > Technical. This combos out into Tillana and Starfall Dance.", DNC.JobID)]
        DancerCombinedDanceFeature = 4022,

        [ParentCombo(DancerCombinedDanceFeature)]
        [CustomComboInfo("Devilment Plus Option", "Adds Devilment right after Technical finish.", DNC.JobID)]
        DancerDevilmentOnCombinedDanceFeature = 4023,

        [ParentCombo(DancerCombinedDanceFeature)]
        [CustomComboInfo("Flourish Plus Option", "Adds Flourish to the Combined Dance Feature.", DNC.JobID)]
        DancerFlourishOnCombinedDanceFeature = 4024,

        [ParentCombo(DancerMenuDanceFeatures)]
        [ConflictingCombos(DancerDanceStepCombo, DancerCombinedDanceFeature)]
        [CustomComboInfo("Custom Dance Step Feature",
        "Change custom actions into dance steps while dancing." +
        "\nThis helps ensure you can still dance with combos on, without using auto dance." +
        "\nYou can change the respective actions by inputting action IDs below for each dance step." +
        "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
        "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.", DNC.JobID)]
        DancerDanceComboCompatibility = 4025,


        // Flourishing Features Section
        [CustomComboInfo("Flourishing Features", "Features and options involving Fourfold Feathers and Flourish.\nCollapsing this category does NOT disable the features inside.", DNC.JobID)]
        DancerMenuFlourishingFeatures = 4030,

        //[ParentCombo(DancerMenuGaugeFeatures)]
        //[CustomComboInfo("Fan Dance Combos", "Change Fan Dance and Fan Dance 2 into Fan Dance 3 while flourishing.", DNC.JobID)]
        //DancerFanDanceCombo = 4031,

        [ParentCombo(DancerMenuFlourishingFeatures)]
        [CustomComboInfo("Flourish Proc Saver Feature", "Change Flourish into any available Feather-generating procs before using.", DNC.JobID)]
        DancerFlourishProcFeature = 4032,

        [ConflictingCombos(DancerFlourishProcFanDanceWeaveOption)]
        [ParentCombo(DancerFlourishProcFeature)]
        [CustomComboInfo("Proc Saver Fan Dance Option", "Include Fan Dance 3 & 4 in the proc saver (disregards weave windows).", DNC.JobID)]
        DancerFlourishProcFanDanceOption = 4033,

        [ConflictingCombos(DancerFlourishProcFanDanceOption)]
        [ParentCombo(DancerFlourishProcFeature)]
        [CustomComboInfo("Proc Saver Fan Dance Weave Option", "Include Fan Dance 3 & 4 in the proc saver, ONLY during weave-windows.", DNC.JobID)]
        DancerFlourishProcFanDanceWeaveOption = 4034,

        [ParentCombo(DancerMenuFlourishingFeatures)]
        [CustomComboInfo("Fan Dance Combo Features", "Options for Fan Dance combos. Fan Dance 3 takes priority over Fan Dance 4.\nCollapsing this category disables the options inside.", DNC.JobID)]
        DancerFanDanceComboFeatures = 4035,

        [ParentCombo(DancerFanDanceComboFeatures)]
        [CustomComboInfo("Fan Dance 1 -> 3", "Changes Fan Dance 1 to Fan Dance 3 when available.", DNC.JobID)]
        DancerFanDance1_3Combo = 4036,

        [ParentCombo(DancerFanDanceComboFeatures)]
        [CustomComboInfo("Fan Dance 1 -> 4", "Changes Fan Dance 1 to Fan Dance 4 when available.", DNC.JobID)]
        DancerFanDance1_4Combo = 4037,

        [ParentCombo(DancerFanDanceComboFeatures)]
        [CustomComboInfo("Fan Dance 2 -> 3", "Changes Fan Dance 2 to Fan Dance 3 when available.", DNC.JobID)]
        DancerFanDance2_3Combo = 4038,

        [ParentCombo(DancerFanDanceComboFeatures)]
        [CustomComboInfo("Fan Dance 2 -> 4", "Changes Fan Dance 2 to Fan Dance 4 when available.", DNC.JobID)]
        DancerFanDance2_4Combo = 4039,

        // Why does this exist? I can't really think of a use-case for it, but I'm leaving it here in case I missed something
        //[ParentCombo(DancerMenuGaugeFeatures)]
        //[CustomComboInfo("Fan Saber Dance Feature", "Adds Saber Dance onto all Fan Dance skills when no feathers are available and you have 50+ Esprit", DNC.JobID)]
        //DancerSaberFanDanceFeature = 4039,

        [CustomComboInfo("Devilment to Starfall Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID)]
        DancerDevilmentFeature = 4040,

        [CustomComboInfo("Simple Dancer (Single Target)", "BETA - Single button, single target dancer. Includes songs, flourishes and overprotections.\nConflicts with all other non-simple toggles. Use at your own risk!", DNC.JobID)]
        DancerSimpleFeature = 4060,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Interrupt", "Includes an interrupt in the rotation", DNC.JobID)]
        DancerSimpleInterruptFeature = 4061,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Standard Step", "Includes Standard Step in the rotation", DNC.JobID)]
        DancerSimpleStandardFeature = 4062,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Technical Step", "Includes Technical Step in the rotation", DNC.JobID)]
        DancerSimpleTechnicalFeature = 4063,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Tech Devilment", "Includes Devilment in the rotation (during Technical Finish).", DNC.JobID)]
        DancerSimpleDevilmentFeature = 4064,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Flourish", "Includes Flourish in the rotation", DNC.JobID)]
        DancerSimpleFlourishFeature = 4065,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Feather", "Includes feather usage in the rotation", DNC.JobID)]
        DancerSimpleFeatherFeature = 4066,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Feather Pooling", "Makes the rotation only use feathers when you have more than 3, or when under the effects of Technical Step", DNC.JobID)]
        DancerSimpleFeatherPoolingFeature = 4067,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Samba", "Includes Shield Samba in the rotation when available (not optimal).", DNC.JobID)]
        DancerSimpleSambaFeature = 4068,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Panic Heals", "Includes Curing Waltz and Second Wind in the rotation when available and below 30% / 50% HP, respectively.", DNC.JobID)]
        DancerSimplePanicHealsFeature = 4069,

        [ParentCombo(DancerSimpleFeature)]
        [CustomComboInfo("Simple Improvisation", "Includes Improvisation in the rotation when available", DNC.JobID)]
        DancerSimpleImprovFeature = 4070,

        [CustomComboInfo("Simple Dancer (AOE)", "BETA - Single button aoe dancer, including songs, flourishes and overprotections.\nConflicts with all other non-simple toggles. Use at your own risk!\nExtra features like in simple single target coming soon (after other fixes!)", DNC.JobID)]
        DancerSimpleAoeFeature = 4080,

        [ParentCombo(DancerSimpleAoeFeature)]
        [CustomComboInfo("Simple AOE Standard", "Includes Standard Step in the AoE rotation", DNC.JobID)]
        DancerSimpleAoeStandardFeature = 4081,

        [ParentCombo(DancerSimpleAoeFeature)]
        [CustomComboInfo("Simple AOE Technical", "Includes Technical Step in the AoE rotation", DNC.JobID)]
        DancerSimpleAoeTechnicalFeature = 4082,

        [ParentCombo(DancerSimpleAoeFeature)]
        [CustomComboInfo("Simple AOE Buffs", "Includes Devilment and Flourish in the AoE rotation", DNC.JobID)]
        DancerSimpleAoeBuffsFeature = 4083,

        [ParentCombo(DancerSimpleAoeFeature)]
        [CustomComboInfo("Simple AOE Feathers", "Includes feather usage in the AoE rotation", DNC.JobID)]
        DancerSimpleAoeFeatherFeature = 4084,

        [ParentCombo(DancerSimpleAoeFeature)]
        [CustomComboInfo("Simple AOE Feather Pooling", "Makes it so the AoE rotation only uses feathers when you have more than 3", DNC.JobID)]
        DancerSimpleAoeFeatherPoolingFeature = 4085,


        #endregion
        // ====================================================================================
        #region DARK KNIGHT

        [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
        DarkSouleaterCombo = 5000,

        [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
        DarkStalwartSoulCombo = 5001,

        [ParentCombo(DarkSouleaterCombo)]
        [ConflictingCombos(DeliriumFeatureOption)]
        [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID)]
        DeliriumFeature = 5002,

        [CustomComboInfo("Dark Knight Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap.", DRK.JobID)]
        DRKOvercapFeature = 5003,

        [ParentCombo(DarkSouleaterCombo)]
        [CustomComboInfo("Living Shadow Feature", "Living shadow will now be on main combo if its not on CD and you have gauge for it.", DRK.JobID)]
        DRKLivingShadowFeature = 5004,

        [ParentCombo(DarkSouleaterCombo)]
        [CustomComboInfo("EoS Overcap Feature", "Uses EoS if you are above 8.5k mana or DarkSide is about to expire(10sec or less)", DRK.JobID)]
        DarkManaOvercapFeature = 5005,

        [CustomComboInfo("oGCD Feature", "Adds Living Shadow>Salted Earth>CarveAndSpit>SaltAndDarkness to CarveAndSpit and AbysalDrain", DRK.JobID)]
        DarkoGCDFeature = 5006,

        [ParentCombo(DarkoGCDFeature)]
        [CustomComboInfo("Shadowbringer Feature", "Adds Shadowbringer to oGCD Feature ", DRK.JobID)]
        DarkShadowbringeroGCDFeature = 5007,

        [ParentCombo(DarkSouleaterCombo)]
        [ConflictingCombos(DarkPlungeFeatureOption)]
        [CustomComboInfo("Plunge Feature", "Adds Plunge onto main combo whenever its available (Uses all stacks).", DRK.JobID)]
        DarkPlungeFeature = 5008,

        [ParentCombo(DarkSouleaterCombo)]
        [ConflictingCombos(DarkPlungeFeature)]
        [CustomComboInfo("Plunge Option", "Adds Plunge onto main combo whenever its available (Leaves 1 stack).", DRK.JobID)]
        DarkPlungeFeatureOption = 5009,

        [ParentCombo(DarkSouleaterCombo)]
        [ConflictingCombos(DeliriumFeature)]
        [CustomComboInfo("Delirium Feature Option", "Replaces Souleather with Bloodspiller when Delirium has 10sec or less remaining.", DRK.JobID)]
        DeliriumFeatureOption = 5010,

        [ParentCombo(DarkSouleaterCombo)]
        [CustomComboInfo("Unmend Uptime Feature", "Replace Souleater Combo Feature with Unmend when you are out of range.", DRK.JobID)]
        DarkRangedUptimeFeature = 5011,

        [CustomComboInfo("Interrupt Feature", "Replaces LowBlow with Interject when target can be interrupted .", DRK.JobID)]
        DarkKnightInterruptFeature = 5012,

        [CustomComboInfo("Abyssal Drain Feature", "Adds abyssal drain to the AoE Combo when you fall below 60% hp.", DRK.JobID)]
        DRKStalwartabyssalDrainFeature = 5013,

        [CustomComboInfo("AoE Shadowbringer Feature", "Adds Shadowbringer to the AoE Combo.", DRK.JobID)]
        DRKStalwartShadowbringerFeature = 5014,

        [ParentCombo(DarkStalwartSoulCombo)]
        [CustomComboInfo("FoS Overcap Feature", "Uses FoS if you are above 8.5k mana or DarkSide is about to expire(10sec or less)", DRK.JobID)]
        DarkManaOvercapAoEFeature = 5015,



        #endregion
        // ====================================================================================
        #region DRAGOON

        [CustomComboInfo("Jump + Mirage Dive", "Replace (High) Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
        DragoonJumpFeature = 6000,

        [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
        DragoonCoerthanTormentCombo = 6001,

        [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
        DragoonChaosThrustCombo = 6002,

        [ConflictingCombos(DragoonFullThrustComboPlus)]
        [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
        DragoonFullThrustCombo = 6003,

        [ConflictingCombos(DragoonFullThrustCombo)]
        [CustomComboInfo("Full Thrust Combo Plus", "Replace Full Thrust with its combo chain (Disembowel/Chaosthrust/life surge added).", DRG.JobID)]
        DragoonFullThrustComboPlus = 6004,

        [CustomComboInfo("Wheeling Thrust/Fang and Claw Option", "When you have either Enhanced Fang and Claw or Wheeling Thrust,\nChaos Thrust Combo becomes Wheeling Thrust and Full Thrust Combo becomes Fang and Claw.\nRequires Chaos Thrust Combo and Full Thrust Combo.", DRG.JobID)]
        DragoonFangThrustFeature = 6005,

        [CustomComboInfo("Wheeling Thrust/Fang and Claw Feature", "Fang And Claw Becomes Wheeloing Thrust when under Enhanced Wheeling Thrust Buff.", DRG.JobID)]
        DragoonFangAndClawFeature = 6006,

        #endregion
        // ====================================================================================
        #region GUNBREAKER

        [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
        GunbreakerSolidBarrelCombo = 7000,

        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Gnashing Fang and Continuation on Main Combo", "Adds Gnashing Fang to the main combo. Gnashing Fang must be started manually and the combo will finish it off.\n Useful for when Gnashing Fang needs to be help due to downtime.", GNB.JobID)]
        GunbreakerGnashingFangOnMain = 7001,

        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Sonic Break/Bow Shock/Blasting Zone on Main Combo", "Adds Sonic Break/Bow Shock/Blasting Zone on main combo when under No Mercy buff", GNB.JobID)]
        GunbreakerCDsOnMainComboFeature = 7002,

        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Double Down on Main Combo", "Adds Double Down on main combo when under No Mercy buff", GNB.JobID)]
        GunbreakerDDonMain = 7003,

        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [ConflictingCombos(GunbreakerRoughDivide2StackOption)]
        [CustomComboInfo("Rough Divide Option (Leaves 1 Stack)", "Adds Rough Divide onto main combo whenever it's available (Leaves 1 stack).", GNB.JobID)]
        GunbreakerRoughDivide1StackOption = 7004,

        [ConflictingCombos(GunbreakerRoughDivide1StackOption)]
        [CustomComboInfo("Rough Divide Option (Uses all stacks)", "Adds Rough Divide onto main combo whenever its available (Uses all stacks).", GNB.JobID)]
        GunbreakerRoughDivide2StackOption = 7005,

        [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
        GunbreakerDemonSlaughterCombo = 7006,

        [CustomComboInfo("Ammo Overcap Feature", "Uses Burst Strike/Fated Circle on the respective ST/AoE combos when ammo is about to overcap.", GNB.JobID)]
        GunbreakerAmmoOvercapFeature = 7007,

        [ConflictingCombos(GunbreakerNoMercyRotationFeature)]
        [CustomComboInfo("Gnashing Fang Continuation Combo", "Adds Continuation to Gnashing Fang.", GNB.JobID)]
        GunbreakerGnashingFangCombo = 7008,

        [ParentCombo(GunbreakerGnashingFangCombo)]
        [CustomComboInfo("No Mercy on Gnashing Fang", "Adds No Mercy to Gnashing Fang when it's ready.", GNB.JobID)]
        GunbreakerNoMercyonGF = 7009,

        [ParentCombo(GunbreakerGnashingFangCombo)]
        [CustomComboInfo("Double Down on Gnashing Fang", "Adds Double Down to Gnashing Fang when No Mercy buff is up.", GNB.JobID)]
        GunbreakerDDOnGF = 7010,

        [ParentCombo(GunbreakerGnashingFangCombo)]
        [CustomComboInfo("CDs on Gnashing Fang", "Adds Sonic Break/Bow Shock/Blasting Zone on Gnashing Fang, order dependent on No Mercy buff. \nBurst Strike added if there's charges while No Mercy buff is up.", GNB.JobID)]
        GunbreakerCDsOnGF = 7011,

        [CustomComboInfo("BurstStrikeContinuation", "Adds Hypervelocity on Burst Strike Continuation combo and main combo and Gnashing Fang.", GNB.JobID)]
        GunbreakerBurstStrikeConFeature = 7012,

        [CustomComboInfo("Burst Strike to Bloodfest Feature", "Replace Burst Strike with Bloodfest if you have no powder gauge.", GNB.JobID)]
        GunbreakerBloodfestOvercapFeature = 7013,

        [ConflictingCombos(GunbreakerGnashingFangCombo)]
        [CustomComboInfo("No Mercy Rotation Feature", "Turns No Mercy into the the No Mercy Gnashing Fang Rotation when used. \nCurrently coded for the level 90 burst window.", GNB.JobID)]
        GunbreakerNoMercyRotationFeature = 7014,

        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Lightning Shot Uptime", "Replace Solid Barrel Combo Feature with Lightning Shot when you are out of range.", GNB.JobID)]
        GunbreakerRangedUptimeFeature = 7015,

        [CustomComboInfo("Interrupt Feature", "Replaces LowBlow with Interject when target can be interrupted .", GNB.JobID)]
        GunbreakerInterruptFeature = 7016,

        #endregion
        // ====================================================================================
        #region MACHINIST

        [CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID)]
        MachinistMainCombo = 8000,

        [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", MCH.JobID)]
        MachinistOverdriveFeature = 8002,

        [CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has more charges.", MCH.JobID)]
        MachinistGaussRoundRicochetFeature = 8003,

        [CustomComboInfo("Drill / Air Anchor (Hot Shot) Feature", "Replace Drill and Air Anchor (Hot Shot) with one or the other (or Chainsaw) depending on which is on cooldown.", MCH.JobID)]
        MachinistHotShotDrillChainsawFeature = 8004,

        [ParentCombo(MachinistMainCombo)]
        [ConflictingCombos(MachinistAlternateMainCombo)]
        [CustomComboInfo("Drill/Air/Chain Saw Feature On Main Combo", "Air Anchor followed by Drill is added onto main combo if you use Reassemble.\nIf AirAnchor is on cooldown and you use Reassemble Chain Saw will be added to main combo instead.", MCH.JobID)]
        MachinistDrillAirOnMainCombo = 8005,

        [CustomComboInfo("Single Button Heat Blast", "Switches Heat Blast to Hypercharge.", MCH.JobID)]
        MachinistHeatblastGaussRicochetFeature = 8006,

        [CustomComboInfo("Single Button Auto Crossbow", "Switches Auto Crossbow to Hypercharge and weaves gauss/rico.", MCH.JobID)]
        MachinistAutoCrossBowGaussRicochetFeature = 8018,

        [ParentCombo(MachinistMainCombo)]
        [ConflictingCombos(MachinistDrillAirOnMainCombo)]
        [CustomComboInfo("Alternate Drill/Air Feature on Main Combo", "Drill/Air/Hotshot Feature is added onto main combo (Note: It will add them onto main combo ONLY if you are under Reassemble Buff \nOr Reasemble is on CD(Will do nothing if Reassemble is OFF CD)", MCH.JobID)]
        MachinistAlternateMainCombo = 8007,

        [ParentCombo(MachinistMainCombo)]
        [CustomComboInfo("Single Button HeatBlast On Main Combo Option", "Adds Single Button Heatblast onto the main combo when the option is enabled.", MCH.JobID)]
        MachinistHeatBlastOnMainCombo = 8008,

        [ParentCombo(MachinistMainCombo)]
        [CustomComboInfo("Battery Overcap Option", "Overcharge protection for your Battery, If you are at 100 battery charge rook/queen will be added to your (Heated) Shot Combo.", MCH.JobID)]
        MachinistOverChargeOption = 8009,

        [ParentCombo(MachinistSpreadShotFeature)]
        [CustomComboInfo("Battery AOE Overcap Option", "Adds overcharge protection to Spread Shot/Scattergun.", MCH.JobID)]
        MachinistAoEOverChargeOption = 8010,

        [ParentCombo(MachinistSpreadShotFeature)]
        [CustomComboInfo("Gauss Round Ricochet on AOE Feature", "Adds Gauss Round/Ricochet to the AoE combo during Hypercharge.", MCH.JobID)]
        MachinistAoEGaussRicochetFeature = 8011,

        [ParentCombo(MachinistAoEGaussRicochetFeature)]
        [CustomComboInfo("Always Gauss Round/Ricochet on AoE Option", "Adds Gauss Round/Ricochet to the AoE combo outside of Hypercharge windows.", MCH.JobID)]
        MachinistAoEGaussOption = 8012,

        [ConflictingCombos(MachinistRicochetGaussMainCombo)]
        [ParentCombo(MachinistMainCombo)]
        [CustomComboInfo("Ricochet & Gauss Round Feature", "Adds Ricochet and Gauss Round to main combo. Will use all charges.", MCH.JobID)]
        MachinistRicochetGaussChargesMainCombo = 8017,

        [ConflictingCombos(MachinistRicochetGaussChargesMainCombo)]
        [ParentCombo(MachinistMainCombo)]
        [CustomComboInfo("Ricochet & Gauss Round overcap protection option", "Adds Ricochet and Gauss Round to main combo. Will leave 1 charge of each.", MCH.JobID)]
        MachinistRicochetGaussMainCombo = 8013,

        [ParentCombo(MachinistMainCombo)]
        [CustomComboInfo("Barrel Stabilizer drift protection feature", "Adds Barrel Stabilizer onto the main combo if heat is between 5-20.", MCH.JobID)]
        BarrelStabilizerDrift = 8014,

        [ParentCombo(MachinistHeatblastGaussRicochetFeature)]
        [CustomComboInfo("WildFire Feature", "Adds WildFire to the Single Button Heat Blast Feature If Wildfire is off cooldown and you have enough heat for Hypercharge then Hypercharge will be replaced with Wildfire.\nAlso weaves Ricochet/Gauss Round on Heat Blast when necessary.", MCH.JobID)]
        MachinistWildfireFeature = 8015,

        [ParentCombo(MachinistSpreadShotFeature)]
        [CustomComboInfo("BioBlaster Feature", "Adds Bioblaster to the Spreadshot feature", MCH.JobID)]
        MachinistBioblasterFeature = 8016,


        [CustomComboInfo("Barrel Feature", "Adds Barrel Stabalizer to Single Button Heat Blast and Single Button Auto Crossbow Features when below 50 heat and is off cooldown", MCH.JobID)]
        MachinistAutoBarrel = 8019,

        [ConflictingCombos(MachinistMainCombo)]
        [CustomComboInfo("Simple Machinist", "Single button single target machinist, including buffs and overprotections.\nConflicts with other ST toggles!!", MCH.JobID)]
        MachinistSimpleFeature = 8020,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Interrupt", "Uses interrupt during simple machinist rotation, if applicable.", MCH.JobID)]
        MachinistSimpleInterrupt = 8021,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Gadget", "Adds Queen or Rook uses to the feature, based on your current level.\nTry to use Queen at optimal intervals between :55 to :05 windows.", MCH.JobID)]
        MachinistSimpleGadget = 8022,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Assembling", "Adds optimal reassemble uses to the feature.", MCH.JobID)]
        MachinistSimpleAssembling = 8023,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Gauss Ricochet", "Adds Gauss Round and Ricochet uses to the feature.", MCH.JobID)]
        MachinistSimpleGaussRicochet = 8024,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Wildcharge", "Adds Hypercharge and Wildfire uses to the feature.\nIt respects the 8 second rule of Drill, AirAnchor and Chainsaw.", MCH.JobID)]
        MachinistSimpleWildCharge = 8025,

        [ParentCombo(MachinistSimpleFeature)]
        [CustomComboInfo("Simple Stabilizer", "Adds Barrel Stabilizer to the feature.\n When heat < 50 and Wildfire is off CD or about to come off CD.", MCH.JobID)]
        MachinistSimpleStabilizer = 8026,

        [ParentCombo(MachinistSpreadShotFeature)]
        [CustomComboInfo("Hypercharge", "Adds hypercharge to the AoE.", MCH.JobID)]
        MachinistAoEHyperchargeFeature = 8027,

        [CustomComboInfo("Simple Machinist AOE", "Spread Shot turns into Scattergun when lvl 82 or higher, Both turn into Auto Crossbow when overheated\nand Bioblaster is used first whenever it is off cooldown.", MCH.JobID)]
        MachinistSpreadShotFeature = 8028,

        #endregion
        // ====================================================================================
        #region MONK

        [CustomComboInfo("Monk AoE Combo", "Replaces ArmOfTheDestroyer/ShadowOfTheDestroyer with the AoE combo chain.", MNK.JobID)]
        MnkAoECombo = 9000,

        [CustomComboInfo("Monk Bootshine Feature", "Replaces Dragon Kick with Bootshine if both a form and Leaden Fist are up.", MNK.JobID)]
        MnkBootshineFeature = 9001,

        [CustomComboInfo("Monk Twin Snakes Feature", "Replaces True Strike with Twin Snakes if Disciplined Fist is not applied or is less than 6 seconds from falling off.", MNK.JobID)]
        MnkTwinSnakesFeature = 9011,

        [ConflictingCombos(MnkBasicComboPlus)]
        [CustomComboInfo("Monk Basic Rotation", "Basic Monk Combo on one button", MNK.JobID)]
        MnkBasicCombo = 9002,

        [CustomComboInfo("Perfect Balance Feature", "Perfect Balance becomes Masterful Blitz while you have 3 Beast Chakra.", MNK.JobID)]
        MonkPerfectBalanceFeature = 9003,

        [CustomComboInfo("Monk Bootshine Balance Feature", "Replaces Dragon Kick with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID)]
        MnkBootshineBalanceFeature = 9004,

        [CustomComboInfo("Howling Fist / Meditation Feature", "Replaces Howling Fist/Enlightenment with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
        MonkHowlingFistMeditationFeature = 9005,

        [ConflictingCombos(MnkBasicCombo)]
        [CustomComboInfo("Monk Basic Rotation Plus", "Basic Monk Combo on one button Plus (Only for Testing)", MNK.JobID)]
        MnkBasicComboPlus = 9006,

        [CustomComboInfo("Perfect Balance Feature Plus", "All of the (Optimal?) Blitz combos on Masterfull Bliz when Perfect Balance Is Active", MNK.JobID)]
        MnkPerfectBalancePlus = 9007,

        [ParentCombo(MnkBasicComboPlus)]
        [CustomComboInfo("MasterfullBliz To Main Combo", "Adds all of (Optimal?) Bliz combos and Masterfull Bliz on Main Combo", MNK.JobID)]
        MonkMasterfullBlizOnMainCombo = 9008,

        [ParentCombo(MnkAoECombo)]
        [CustomComboInfo("MasterfullBliz To AoE Combo", "Adds all of (Optimal?) Bliz combos and Masterfull Bliz on AoE Combo.", MNK.JobID)]
        MonkMasterfullBlizOnAoECombo = 9009,

        [CustomComboInfo("Forbidden Chakra Feature", "Adds Forbidden Chakra/Enlightement to the Main/AoE feature combo. Testing Only for now!", MNK.JobID)]
        MonkForbiddenChakraFeature = 9010,

        [CustomComboInfo("Riddle of Fire/Brotherhood Feature", "Replaces Riddle of Fire with Brotherhood when Riddle of Fire is on cooldown.", MNK.JobID)]
        MnkRiddleOfFireBrotherhoodFeature = 9012,

        [ParentCombo(MnkBasicComboPlus)]
        [CustomComboInfo("Damage Buffs to Main Combo Feature", "Places Riddle of Fire and Brotherhood onto main combo when Perfect Balance is up.", MNK.JobID)]
        MnkMainComboBuffsFeature = 9013,

        [ParentCombo(MnkBasicComboPlus)]
        [CustomComboInfo("Riddle of Wind Main Combo Feature", "Places Riddle of Wind onto main combo after using Twin Snakes.", MNK.JobID)]
        MnkRiddleOfWindFeature = 9014,


        #endregion
        // ====================================================================================
        #region NINJA

        [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID, 0, "Smush Attack", "Goes Smush Smush")]
        NinjaArmorCrushCombo = 10000,

        [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
        NinjaAeolianEdgeCombo = 10001,

        //[CustomComboInfo("Simple AoE", "Replaces Death Blossom with the AoE rotation.", NIN.JobID)]
        //NinjaHakkeMujinsatsuCombo = 10002,

        //[CustomComboInfo("Dream to Assassinate", "Replace Dream Within a Dream with Assassinate when Assassinate Ready.", NIN.JobID)]
        //NinjaAssassinateFeature = 10003,

        [CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
        NinjaKassatsuTrickFeature = 10004,

        [CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
        NinjaTCJMeisuiFeature = 10005,

        [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
        NinjaKassatsuChiJinFeature = 10006,

        [CustomComboInfo("Hide to Mug", "Replaces Hide with Mug while in combat.", NIN.JobID)]
        NinjaHideMugFeature = 10007,

        [CustomComboInfo("Aeolian to Ninjutsu Feature", "Replaces Aeolian Edge (combo) with Ninjutsu if any Mudra are used.", NIN.JobID)]
        NinjaNinjutsuFeature = 10008,

        [CustomComboInfo("GCDs to Ninjutsu Feature", "Every GCD combo becomes Ninjutsu while Mudras are being used.", NIN.JobID)]
        NinjaGCDNinjutsuFeature = 10009,

        [CustomComboInfo("Huraijin / Raiju Feature", "Replaces Huraijin with Forked and Fleeting Raiju when available.", NIN.JobID)]
        NinjaHuraijinRaijuFeature = 10010,

        [ParentCombo(NinjaHuraijinRaijuFeature)]
        [CustomComboInfo("Huraijin / Raiju Feature Option1", "Replaces Huraijin with Fleeting Raiju when available.", NIN.JobID)]
        NinjaHuraijinRaijuFeature1 = 10011,

        [ParentCombo(NinjaHuraijinRaijuFeature)]
        [CustomComboInfo("Huraijin / Raiju Feature Option2", "Replaces Huraijin with Forked Raiju when available.", NIN.JobID)]
        NinjaHuraijinRaijuFeature2 = 10012,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Armor Crush Feature", "Adds Armor Crush onto main combo.", NIN.JobID)]
        NinjaArmorCrushOnMainCombo = 10013,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Raiju Feature", "Adds Fleeting Raiju to Aeolian Edge Combo.", NIN.JobID)]
        NinjaFleetingRaijuFeature = 10014,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("HuraijinToMainCombo", "Adds Huraijin to main combo if Huton buff is not present", NIN.JobID)]
        NinjaHuraijinFeature = 10015,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("BunshinOnMainCombo", "Adds Bunshin whenever its off cd and you have gauge for it on main combo.", NIN.JobID)]
        NinjaBunshinFeature = 10016,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("BavacakraOnMainCombo", "Adds Bavacakra you have gauge for it on main combo.", NIN.JobID)]
        NinjaBhavacakraFeature = 10017,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Throwing Dagger Uptime Feature", "Replace Aeolian Edge with Throwing Daggers when targer is our of range.", NIN.JobID)]
        NinjaRangedUptimeFeature = 10018,

        [CustomComboInfo("Simple Mudras", "Simplify the mudra casting to avoid failing.", NIN.JobID)]
        NinjaSimpleMudras = 10020,

        [ParentCombo(NinjaTCJMeisuiFeature)]
        [CustomComboInfo("Ten Chi Jin Feature", "Turns Ten Chi Jin (the move) into Ten, Chi, and Jin.", NIN.JobID)]
        NinTCJFeature = 10021,

        [ConflictingCombos(NinjaArmorCrushCombo, NinjaAeolianEdgeCombo, NinjaGCDNinjutsuFeature)]
        [CustomComboInfo("Simple Ninja Single Target", "Turns Spinning Edge into a one-button full single target rotation.\nUses Ninjitsus, applies Trick Attack and uses Armor Crush to upkeep Huton buff.\nConflicts with a lot of features. Please only use this and the AoE version and disable all other Ninja features.", NIN.JobID)]
        NinSimpleSingleTarget = 10022,

        [CustomComboInfo("Simple Ninja AoE", "Turns Death Blossom into a one-button full AoE rotation.\nApplies Doton but will only use Ninjitsus if under the effect of Kassatsu or have 2 charges to ensure more Doton uptime.", NIN.JobID)]
        NinSimpleAoE = 10023,

        [ParentCombo(NinSimpleSingleTarget)]
        [CustomComboInfo("Include Trick Attack", "Add or disable Trick Attack as part of the feature.", NIN.JobID)]
        NinSimpleTrickFeature = 10024,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Assassinate/Dream Within a Dream Feature", "Adds Assassinate and Dream Within a Dream to the combo.", NIN.JobID)]
        NinAeolianAssassinateFeature = 10025,

        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Mug Feature", "Adds Mug to the combo.", NIN.JobID)]
        NinAeolianMugFeature = 10026,

        #endregion
        // ====================================================================================
        #region PALADIN

        [CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID)]
        PaladinGoringBladeCombo = 11000,

        [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
        PaladinRoyalAuthorityCombo = 11001,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [ConflictingCombos(PaladinAtonementTestFeature)]
        [CustomComboInfo("Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID)]
        PaladinAtonementFeature = 11002,

        [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
        PaladinProminenceCombo = 11003,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Requiescat Feature", "Replace Royal Authority/Goring Blade combo with Holy Spirit and Prominence combo with Holy Circle while Requiescat is active \n And when Fight Or Flight is not Active.\nRequires said combos to be activated to work.", PLD.JobID)]
        PaladinRequiescatFeature = 11004,

        [ParentCombo(PaladinRequiescatFeature)]
        [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor when Requiescat is up and MP is under 2000 or only one stack remains \nand adds Faith/Truth/Valor Combo after Confiteor. \n Requiescat Feature Needs to be Enabled for this one to work!!!  ", PLD.JobID)]
        PaladinConfiteorFeature = 11005,

        [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within and Circle of Scorn with whichever is available soonest.", PLD.JobID)]
        PaladinScornfulSpiritsFeature = 11006,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Royal Goring Option", "Insert Goring Blade into the main combo when appropriate.\nRequires Royal Authority Combo", PLD.JobID)]
        PaladinRoyalGoringOption = 11007,

        [CustomComboInfo("Standalone Holy Spirit Feature", "Replaces Holy Spirit with Confiteor and Confiteor combo", PLD.JobID)]
        PaladinStandaloneHolySpiritFeature = 11008,

        [CustomComboInfo("Standalone Holy Circle Feature", "Replaces Holy Circle with Confiteor and Confiteor combo", PLD.JobID)]
        PaladinStandaloneHolyCircleFeature = 11009,

        [ConflictingCombos(PaladinInterveneFeatureOption)]
        [CustomComboInfo("Intervene Feature", "Adds intervene onto main combo whenever its available (Uses all stacks).", PLD.JobID)]
        PaladinInterveneFeature = 11010,

        [ConflictingCombos(PaladinInterveneFeature)]
        [CustomComboInfo("Intervene Option", "Adds intervene onto main combo whenever its available (Leaves 1 stack).", PLD.JobID)]
        PaladinInterveneFeatureOption = 11011,

        [ConflictingCombos(PaladinRangedUptimeFeature2)]
        [CustomComboInfo("Shield Lob Uptime Feature", "Replace Royal Authority/Rage of Halone Feature with Shield Lob when out of range.", PLD.JobID)]
        PaladinRangedUptimeFeature = 11012,

        [ParentCombo(PaladinFightOrFlightMainComboFeature)]
        [ConflictingCombos(PaladinFightOrFlightMainComboFeatureTest)]
        [CustomComboInfo("FoF Feature", "Adds FoF onto the main combo (Testing).", PLD.JobID)]
        PaladinFightOrFlightMainComboFeature = 11013,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Req Feature", "Adds Req onto the main combo (Testing).", PLD.JobID)]
        PaladinReqMainComboFeature = 11014,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [ConflictingCombos(PaladinAtonementFeature, SkillCooldownRemaining)]
        [CustomComboInfo("Atonement Drop Feature", "Drops Atonement to prevent Potency loss (Testing).", PLD.JobID)]
        PaladinAtonementTestFeature = 11015,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [ConflictingCombos(PaladinRangedUptimeFeature)]
        [CustomComboInfo("Holyspirit Uptime Feature", "Replace Royal Authority/Rage of Halone Feature with HolySpirit when out of range.", PLD.JobID)]
        PaladinRangedUptimeFeature2 = 11016,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [ConflictingCombos(PaladinRangedUptimeFeature, PaladinFightOrFlightMainComboFeature)]
        [CustomComboInfo("FoF Feature (Custom Values) ", "Adds FoF onto the main combo (Testing). You can Input your own gcd value(Value represtents percentage of your GCD, 1 = full GCD).", PLD.JobID)]
        PaladinFightOrFlightMainComboFeatureTest = 11017,

        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [ConflictingCombos(PaladinAtonementFeature, PaladinAtonementTestFeature)]
        [CustomComboInfo("Atonement Drop Feature (Custom Value Test)", "Drops Atonement to prevent Potency loss when FoF is about to expire.", PLD.JobID)]
        SkillCooldownRemaining = 11018,

        [CustomComboInfo("Interrupt Feature", "Replaces LowBlow with Interject when target can be interrupted .", PLD.JobID)]
        PaladinInterruptFeature = 11019,

        #endregion
        // ====================================================================================
        #region REAPER

        // Single Target Combo Section
        [CustomComboInfo("Slice Combo Feature", "Replace Slice with its combo chain. Features and options inside.\nCollapsing this category disables the features inside.", RPR.JobID)]
        ReaperSliceCombo = 12000,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Soul Slice Option", "Adds Soul Slice to Slice Combo when Soul Gauge is 50 or less, and target is under Death's Design debuff.", RPR.JobID)]
        ReaperSoulSliceFeature = 12001,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Shadow Of Death Option", "Adds Shadow of Death to Slice Combo if debuff is not present or is about to expire.", RPR.JobID)]
        ReaperShadowOfDeathFeature = 12002,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Stun Option", "Adds Leg Sweep to main combo when target is performing an interruptible cast i.e. uses stun as an interrupt.", RPR.JobID)]
        ReaperStunOption = 12003,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Combo Heals Option", "Adds Bloodbath and Second Wind to the combo at 65 and 40 percent HP, respectively.", RPR.JobID)]
        ReaperComboHealsOption = 12004,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Ranged Filler Option", "Replaces the combo chain with Harpe (or Harvest Moon, if available) when outside of melee range. Will not override Communio.", RPR.JobID)]
        ReaperRangedFillerOption = 12005,

        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Feint Option", "Adds Feint into the combo.\nOnly use this if you're really asleep at the wheel (NOT optimal).", RPR.JobID)]
        ReaperFeintOption = 12006,

        // AoE Combo Section
        [CustomComboInfo("Scythe Combo Feature", "Replace Spinning Scythe with its combo chain. Features and options inside.\nCollapsing this category disables the features inside.", RPR.JobID)]
        ReaperScytheCombo = 12010,

        [ParentCombo(ReaperScytheCombo)]
        [CustomComboInfo("Soul Scythe Option", "Adds Soul Scythe to Scythe Combo when Soul Gauge is 50 or less, and target is under Death's Design debuff.", RPR.JobID)]
        ReaperSoulScytheFeature = 12011,

        [ParentCombo(ReaperScytheCombo)]
        [CustomComboInfo("Whorl Of Death Option", "Adds Whorl of Death to Scythe Combo if debuff is not present or is about to expire.", RPR.JobID)]
        ReaperWhorlOfDeathFeature = 12012,


        // Gibbet, Gallows, Guillotine Combo Section
        [CustomComboInfo("[Unveiled Features]", "Features and options involving Gibbet, Gallows and Guillotine.\nCollapsing this category does NOT disable the features inside.", RPR.JobID)]
        ReaperMenuUnveiledFeatures = 12020,

        [ParentCombo(ReaperMenuUnveiledFeatures)]
        [ConflictingCombos(ReaperGibbetGallowsInverseFeature)]
        [CustomComboInfo("Gibbet/Gallows Feature", "Slice and Shadow of Death are replaced with Gibbet and Gallows while Soul Reaver or Shroud is active.", RPR.JobID)]
        ReaperGibbetGallowsFeature = 12021,

        [ParentCombo(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gibbet/Gallows One-Button Option", "Slice is instead replaced with whichever move is procced, and Shadow of Death remains untouched.", RPR.JobID)]
        ReaperGibbetGallowsOption = 12022,

        [ParentCombo(ReaperMenuUnveiledFeatures)]
        [ConflictingCombos(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gallows/Gibbet (Inverse) Feature - BROKEN (Currently same effect as above)", "Slice and Shadow of Death are replaced with Gallows and Gibbet while Soul Reaver or Shroud is active.\n(Positional replacements swapped)", RPR.JobID)]
        ReaperGibbetGallowsInverseFeature = 12023,

        [ParentCombo(ReaperMenuUnveiledFeatures)]
        [CustomComboInfo("Guillotine Feature", "Spinning Scythe's combo gets replaced with Guillotine while Soul Reaver or Shroud is active.", RPR.JobID)]
        ReaperGuillotineFeature = 12024,


        // Blood Stalk, Grim Swathe, Gluttony Combo Section
        [CustomComboInfo("[Soul Reaver Features]", "Features and options involving Blood Stalk, Grim Swathe and Gluttony.\nCollapsing this category does NOT disable the features inside.", RPR.JobID)]
        ReaperMenuSoulReaverFeatures = 12030,

        [ParentCombo(ReaperMenuSoulReaverFeatures)]
        [ConflictingCombos(ReaperBloodStalkComboFeature, ReaperBloodStalkAlternateComboOption, ReaperGrimSwatheComboFeature)]
        [CustomComboInfo("Blood Stalk/Grim Swathe Feature", "When Gluttony is off-cooldown, Blood Stalk and Grim Swathe will turn into Gluttony.", RPR.JobID)]
        ReaperBloodSwatheFeature = 12031,

        [ParentCombo(ReaperMenuSoulReaverFeatures)]
        [ConflictingCombos(ReaperBloodSwatheFeature, ReaperBloodStalkAlternateComboOption)]
        [CustomComboInfo("Blood Stalk Multi-Combo Feature", "Turns Blood Stalk into Gluttony when off-cooldown and puts Gibbet and Gallows on the same button as Blood Stalk. Also adds Enshrouded Combo.", RPR.JobID)]
        ReaperBloodStalkComboFeature = 12032,

        [ParentCombo(ReaperMenuSoulReaverFeatures)]
        [ConflictingCombos(ReaperBloodSwatheFeature, ReaperBloodStalkComboFeature)]
        [CustomComboInfo("Blood Stalk Multi-Combo Feature Alternative - Same but better (?)", "Turns Blood Stalk into Gluttony when off-cooldown and puts Gibbet and Gallows on the same button as Blood Stalk. Also adds Enshrouded Combo.\n[Seems like the code is more effective in edge cases. Both features need further review.", RPR.JobID)]
        ReaperBloodStalkAlternateComboOption = 12033,

        [ParentCombo(ReaperMenuSoulReaverFeatures)]
        [ConflictingCombos(ReaperBloodSwatheFeature)]
        [CustomComboInfo("Grim Swathe Multi-Combo Feature", "Turns Grim Swathe into Gluttony when off-cooldown and puts Guillotine on the same button as Grim Swathe. Also adds Enshrouded Combo.", RPR.JobID)]
        ReaperGrimSwatheComboFeature = 12034,


        // Enshroud Combo Section
        [CustomComboInfo("[Enshroud Features]", "Features and options involving the Enshrouded burst phase.\nCollapsing this category does NOT disable the features inside.", RPR.JobID)]
        ReaperMenuEnshroudFeatures = 12040,

        [ParentCombo(ReaperMenuEnshroudFeatures)]
        [CustomComboInfo("Lemure Feature", "When you have two or more stacks of Void Shroud, Lemure Slice replaces Gibbet/Gallows and Lemure Scythe replaces Guillotine.", RPR.JobID)]
        ReaperLemureFeature = 12041,

        [ParentCombo(ReaperMenuEnshroudFeatures)]
        [CustomComboInfo("Combo Communio Feature", "When one stack of Lemure Shroud remains, Communio replaces Gibbet/Gallows/Guillotine.", RPR.JobID)]
        ReaperComboCommunioFeature = 12042,

        [ParentCombo(ReaperMenuEnshroudFeatures)]
        // [ConflictingCombos(ReaperEnshroudComboFeature)]
        [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
        ReaperEnshroudCommunioFeature = 12043,

        // [ParentCombo(ReaperMenuEnshroudFeatures)]
        // [ConflictingCombos(ReaperEnshroudCommunioFeature)]
        // [CustomComboInfo("Enshroud One-Button Single Target Combo - DOESN'T EXIST YET", "Turns Enshroud into Void/Cross Reaping, weaves Lemure Slice and finishes with Communio.", RPR.JobID)]
        // ReaperEnshroudComboFeature = 12044,


        // Miscellaneous Combo Section
        [CustomComboInfo("[Extra Features]", "Miscellaneous features and options.\nCollapsing this category does NOT disable the features inside.", RPR.JobID)]
        ReaperMenuExtraFeatures = 12050,

        [ParentCombo(ReaperMenuExtraFeatures)]
        [CustomComboInfo("Arcane Circle Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID)]
        ReaperHarvestFeature = 12051,

        [ParentCombo(ReaperMenuExtraFeatures)]
        [CustomComboInfo("Regress Feature", "Both Hell's Ingress and Hell's Egress turn into Regress when Threshold is active, instead of just the opposite of the one you used.", RPR.JobID)]
        ReaperRegressFeature = 12052,

        [ParentCombo(ReaperMenuExtraFeatures)]
        [CustomComboInfo("Harpe Soulsow Feature", "Changes Harpe into Soulsow when you are out of combat or have no target, and are not already under the effect of Soulsow.", RPR.JobID)]
        ReaperHarpeSoulsowFeature = 12053,

        [ParentCombo(ReaperMenuExtraFeatures)]
        [CustomComboInfo("Harpe Harvest Moon Feature", "Changes Harpe into Harvest Moon when you are in combat with Soulsow active.", RPR.JobID)]
        ReaperHarpeHarvestMoonFeature = 12054,

        [ParentCombo(ReaperHarpeHarvestMoonFeature)]
        [CustomComboInfo("Enhanced Harpe Option", "Prevent Harvest Moon replacing Harpe when Enhanced Harpe is active.\nThis option also affects the Ranged Filler Option for the Slice Combo Feature.", RPR.JobID)]
        ReaperHarpeHarvestMoonEnhancedOption = 12055,

        [ParentCombo(ReaperHarpeHarvestMoonFeature)]
        [CustomComboInfo("Combat Harpe Option", "Prevent Harvest Moon replacing Harpe when you are not in combat.\nThis option also affects the Ranged Filler Option for the Slice Combo Feature.", RPR.JobID)]
        ReaperHarpeHarvestMoonCombatOption = 12056,

        #endregion
        // ====================================================================================
        #region RED MAGE

        [ConflictingCombos(RedMageSmartcastAoECombo)]
        [CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when Dualcast or Swiftcast are active.", RDM.JobID)]
        RedMageAoECombo = 13000,

        [CustomComboInfo("Redoublement combo", "Replaces Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
        RedMageMeleeCombo = 13001,

        [CustomComboInfo("Redoublement Combo Plus", "Replaces Redoublement with Verflare/Verholy after Enchanted Redoublement, whichever is more appropriate.\nRequires Redoublement Combo.", RDM.JobID)]
        RedMageMeleeComboPlus = 13002,

        [ConflictingCombos(RedMageSmartSingleTargetCombo)]
        [CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt/Scorch when no proc is available.", RDM.JobID)]
        RedMageVerprocCombo = 13003,

        [ConflictingCombos(RedMageSmartSingleTargetCombo)]
        [CustomComboInfo("Verproc into Jolt Plus", "Additionally replaces Verstone/Verfire with Veraero/Verthunder if dualcast/swiftcast are up.\nRequires Verproc into Jolt.", RDM.JobID)]
        RedMageVerprocComboPlus = 13004,

        [ConflictingCombos(RedMageSmartSingleTargetCombo)]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature", "Turns Verfire into Verthunder when out of combat.\nRequires Verproc into Jolt Plus.", RDM.JobID)]
        RedMageVerprocOpenerFeature = 13005,

        [CustomComboInfo("Resolution Feature", "Adds Resolution finisher to Verthunder/Verareo Combo ", RDM.JobID)]
        RedmageResolutionFinisher = 13006,

        [CustomComboInfo("Resolution Feature Melee", "Adds Resolution finisher to melee combo ", RDM.JobID)]
        RedmageResolutionFinisherMelee = 13007,

        [ConflictingCombos(RedMageAoECombo)]
        [CustomComboInfo("Smart AoE Feature", "Replaces Verthunder II With Veraero II and impact depending on mana", RDM.JobID)]
        RedMageSmartcastAoECombo = 13008,

        [ConflictingCombos(RedMageVerprocComboPlus, RedMageVerprocOpenerFeature, RedMageVerprocCombo)]
        [CustomComboInfo("Smart Single Target Feature", "Smart Single target feature Credit: PrincessRTFM", RDM.JobID)]
        RedMageSmartSingleTargetCombo = 13009,

        [CustomComboInfo("oGCD Feature", "Replace Contre Strike and Fleche with whichever is available soonest.", RDM.JobID)]
        RedMageOgcdCombo = 13010,

        [CustomComboInfo("SmartCast Opener Feature", "Verthunder Opener Feature. Allows you to prepull with verthunder and still let the combo balance the mana for you", RDM.JobID)]
        RedMageVerprocOpenerSmartCastFeature = 13011,

        [ParentCombo(RedMageSmartcastAoECombo)]
        [CustomComboInfo("Red Mage AoE Finisher", "Adds Finishers onto Moulinet and SmartCast AoE Feature.", RDM.JobID)]
        RedMageMeleeAoECombo = 13012,

        [CustomComboInfo("Engagement Feature", "Adds Engagement in all melee combos. (Testing Only!)", RDM.JobID)]
        RedMageEngagementFeature = 13013,

        [CustomComboInfo("Simple Red Mage Feature Single Target", "Combines Smartcast feature with melee combo on Verstone,Verfire or melee skills (This is not optimal until i find a solution for distance delay)", RDM.JobID)]
        SimpleRedMage = 13014,

        [CustomComboInfo("Simple Red Mage Feature AoE", "Combines Smartcast AoE feature with melee AoE combo on Verthunder2/Veraero2 (This is not optimal until i find a solution for distance delay)", RDM.JobID)]
        SimpleRedMageAoE = 13015,

        [CustomComboInfo("Corps-A-corps/Displacement Feature", "Corps-A-corps becomes displacement when in melee range", RDM.JobID)]
        RedMageMovementFeature = 13016,

        [ParentCombo(RedMageOgcdCombo)]
        [CustomComboInfo("oGCD Feature Everywhere", "Adds oGCD Feature to all other combos", RDM.JobID)]
        RedMageOgcdComboOnCombos = 13017,

        [ParentCombo(SimpleRedMage)]
        [CustomComboInfo("Verstone/Verfire Activation", "Add Acceleration and Swiftcast to Simple Red Mage to force activation of verstone or verfire effects when necessary.", RDM.JobID)]
        SimpleRedMageFishing = 13018,

        [ParentCombo(SimpleRedMageFishing)]
        [CustomComboInfo("Acceleration only", "Only use Acceleration to force verfire or verstone activations.", RDM.JobID)]
        SimpleRedMageAccelOnlyFishing = 13019,

        [ParentCombo(SimpleRedMage)]
        [ConflictingCombos(RedMageVerprocOpenerSmartCastFeature)]
        [CustomComboInfo("Simple opener", "Do the optimal opener. [lv90 only]", RDM.JobID)]
        SimpleRedMageOpener = 13020,

        #endregion
        // ====================================================================================
        #region SAGE

        [CustomComboInfo("Soteria into Kardia Feature", "Soteria turns into Kardia when not active or Soteria is on-cooldown.", SGE.JobID)]
        SageKardiaFeature = 14000,

        [CustomComboInfo("Rhizomata Feature", "Replaces Taurochole, Druochole, Ixochole and Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
        SageRhizomataFeature = 14001,

        [CustomComboInfo("Taurochole into Druochole Feature", "Replaces Taurochole with Druochole when Taurochole is on cooldown.", SGE.JobID)]
        SageTauroDruoFeature = 14002,

        [CustomComboInfo("Phlegma into Toxikon Feature", "Phlegma turns into Toxikon when you are out of charges and have Addersting.\nTakes priority over the Phlegma into Dyskrasia Feature.", SGE.JobID)]
        SagePhlegmaToxikonFeature = 14003,

        [CustomComboInfo("Phlegma into Dyskrasia Feature", "Phlegma turns into Dyskrasia when you are out of charges.", SGE.JobID)]
        SagePhlegmaDyskrasiaFeature = 14004,

        [ConflictingCombos(SageDPSFeatureTest)]
        [CustomComboInfo("Dosis DPS Feature", "Adds Eukrasia and Eukrasian Dosis on one combo button.", SGE.JobID)]
        SageDPSFeature = 14005,

        [ParentCombo(SageDPSFeature)]
        [CustomComboInfo("Lucid Dreaming Option", "Adds Lucid Dreaming into the Dosis DPS feature when you have 8,000 mana or less.", SGE.JobID)]
        SageLucidFeature = 14006,

        [ConflictingCombos(SageAlternateEgeiroFeature)]
        [CustomComboInfo("Swiftcast into Egeiro Feature", "Changes Swiftcast to Egeiro when under the effect of Swiftcast.", SGE.JobID)]
        SageEgeiroFeature = 14007,

        [ConflictingCombos(SageEgeiroFeature)]
        [CustomComboInfo("Egeiro into Swiftcast Feature", "Changes Egiero to Swiftcast when Swiftcast is available.", SGE.JobID)]
        SageAlternateEgeiroFeature = 14008,

        [ConflictingCombos(SageDPSFeature)]
        [CustomComboInfo("Dosis DPS Feature (Testing)", "Identical to the Dosis DPS feature, but you can input some values to your liking.", SGE.JobID)]
        SageDPSFeatureTest = 14009,

        [ParentCombo(SageDPSFeatureTest)]
        [CustomComboInfo("Lucid Dreaming Option", "Adds Lucid Dreaming into the Dosis DPS feature (Testing) when you have 8,000 mana or less.", SGE.JobID)]
        SageLucidFeatureTest = 14010,

        #endregion
        // ====================================================================================
        #region SAMURAI

        [ConflictingCombos(SamuraiSimpleSamuraiFeature)]
        [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
        SamuraiYukikazeCombo = 15000,

        [ConflictingCombos(SamuraiSimpleSamuraiFeature)]
        [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
        SamuraiGekkoCombo = 15001,

        [ConflictingCombos(SamuraiSimpleSamuraiFeature)]
        [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
        SamuraiKashaCombo = 15002,

        [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID)]
        SamuraiMangetsuCombo = 15003,

        [CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID)]
        SamuraiOkaCombo = 15004,

        [CustomComboInfo("Jinpu/Shifu Feature", "Replace Meikyo Shisui with Jinpu or Shifu depending on what is needed.", SAM.JobID)]
        SamuraiJinpuShifuFeature = 15005,

        [ConflictingCombos(SamuraiIaijutsuTsubameGaeshiFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is empty.", SAM.JobID)]
        SamuraiTsubameGaeshiIaijutsuFeature = 15006,

        [ConflictingCombos(SamuraiIaijutsuShohaFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID)]
        SamuraiTsubameGaeshiShohaFeature = 15007,

        [ConflictingCombos(SamuraiTsubameGaeshiIaijutsuFeature)]
        [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is not empty.", SAM.JobID)]
        SamuraiIaijutsuTsubameGaeshiFeature = 15008,

        [ConflictingCombos(SamuraiTsubameGaeshiShohaFeature)]
        [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
        SamuraiIaijutsuShohaFeature = 15009,

        [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when its cooldown is up.", SAM.JobID)]
        SamuraiSeneiFeature = 15010,

        [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
        SamuraiShohaFeature = 15011,

        [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when its cooldown is up.", SAM.JobID)]
        SamuraiGurenFeature = 15012,

        [CustomComboInfo("Kyuten to Shoha II", "Replace Hissatsu: Kyuten with Shoha II when Meditation is full.", SAM.JobID)]
        SamuraiShoha2Feature = 15013,

        [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.\nIf you have full Meditation stacks, Ikishoten becomes Shoha while you have Ogi Namikiri ready.", SAM.JobID)]
        SamuraiIkishotenNamikiriFeature = 15014,

        [ConflictingCombos(SamuraiYukikazeCombo, SamuraiGekkoCombo, SamuraiKashaCombo)]
        [CustomComboInfo("Simple Samurai Single Target", "Every Sticker Combo On One Button (On Hakaze). Big Thanks to Stein121", SAM.JobID)]
        SamuraiSimpleSamuraiFeature = 15015,

        [CustomComboInfo("Simple Samurai AoE", "Both AoE Combos on same button (On Oka). Big thanks to Stein121", SAM.JobID)]
        SamuraiSimpleSamuraiAoECombo = 15016,

        [CustomComboInfo("Kaiten Feature Option 1", "Adds Kaiten to Higanbana when it has < 5 seconds remaining.", SAM.JobID)]
        SamuraiKaitenFeature1 = 15018,

        [CustomComboInfo("Kaiten Feature Option 2", "Adds Kaiten to Tenka Goken.", SAM.JobID)]
        SamuraiKaitenFeature2 = 15019,

        [CustomComboInfo("Kaiten Feature Option 3", "Adds Kaiten to Midare Setsugekka.", SAM.JobID)]
        SamuraiKaitenFeature3 = 15020,

        [CustomComboInfo("Gyoten Feature", "Hissatsu: Gyoten becomes Yaten/Gyoten depending on the distance from your target.", SAM.JobID)]
        SamuraiYatenFeature = 15021,

        [CustomComboInfo("Kaiten Feature Option 4", "Adds Kaiten when above 20 gauge to OgiNamikiri and OgiNamikiri is ready.", SAM.JobID)]
        SamuraiOgiNamikiriFeature = 15022,

        [ConflictingCombos(SamuraiOvercapFeature85)]
        [CustomComboInfo("Samurai Overcap Feature 1", "Adds Senei>Shinten onto main combo at 75 or more Kenki", SAM.JobID)]
        SamuraiOvercapFeature75 = 15023,

        [ConflictingCombos(SamuraiOvercapFeature75)]
        [CustomComboInfo("Samurai Overcap Feature 2", "Adds Senei>Shinten onto main combo at 85 or more Kenki", SAM.JobID)]
        SamuraiOvercapFeature85 = 15024,

        [ConflictingCombos(SamuraiOvercapFeatureAoe85)]
        [CustomComboInfo("Samurai AoE Overcap Feature 1", "Adds Guren>Kyuten onto main AoE combos at 75 or more Kenki", SAM.JobID)]
        SamuraiOvercapFeatureAoe75 = 15025,

        [ConflictingCombos(SamuraiOvercapFeatureAoe75)]
        [CustomComboInfo("Samurai AoE Overcap Feature 2", "Adds Guren>Kyuten onto main AoE combos at 85 or more Kenki", SAM.JobID)]
        SamuraiOvercapFeatureAoe85 = 15026,

        [CustomComboInfo("Ikishoten on combos", "Adds Ikishoten to most Single Target/AoE combos when at or below 50 Kenki", SAM.JobID)]
        SamuraiIkishotenonmaincombo = 15027,

        [ParentCombo(SamuraiIkishotenNamikiriFeature)]
        [CustomComboInfo("Kaiten On Ikishoten", "Adds Kaiten to Ikishoten Namikiri Feature", SAM.JobID)]
        SamuraiIkishotenKaitenNamikiriFeature = 15028,



        #endregion
        // ====================================================================================
        #region SCHOLAR

        [CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID)]
        ScholarSeraphConsolationFeature = 16000,

        [CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
        ScholarEnergyDrainFeature = 16001,

        [ConflictingCombos(SCHAlternateRaiseFeature)]
        [CustomComboInfo("SCH Raise Feature", "Changes Swiftcast to Resurrection.", SCH.JobID)]
        SchRaiseFeature = 16002,

        [ConflictingCombos(SchRaiseFeature)]
        [CustomComboInfo("SCH Raise Alternate Feature", "Changes Resurrection To Swiftcast when Swiftcast is available.", SCH.JobID)]
        SCHAlternateRaiseFeature = 16008,

        [CustomComboInfo("Fairy Feature", "Change every action that requires a fairy into Summon Eos if you do not have a fairy summoned.", SCH.JobID)]
        ScholarFairyFeature = 16004,

        [CustomComboInfo("DPS Feature", "Adds Bio1/Bio2/Biosys to Broil/Ruin whenever the debuff is not present or about to expire.", SCH.JobID)]
        ScholarDPSFeature = 16005,

        [ParentCombo(ScholarDPSFeature)]
        [CustomComboInfo("DPS Feature Buff Option", "Adds Chainstratagem to the DPS Feature.", SCH.JobID)]
        ScholarDPSFeatureBuffOption = 16006,

        [ParentCombo(ScholarDPSFeature)]
        [CustomComboInfo("DPS Feature Lucid Dreaming Option", "Adds Lucid dreaming to the DPS feature when below set MP value.", SCH.JobID)]
        ScholarLucidDPSFeature = 16007,

        [CustomComboInfo("SCH Alternate DPS Feature", "Adds Biolysis on Ruin II. Won't work below level 38", SCH.JobID)]
        SCHDPSAlternateFeature = 16003,

        #endregion
        // ====================================================================================
        #region SUMMONER


        [ConflictingCombos(SummonerMainComboFeature, SummonerRuinIVMobilityFeature)]
        [CustomComboInfo("Enable Single Target (Ruin1)", "Enables changing Single-Target Combo (Ruin I).", SMN.JobID)]
        SummonerMainComboFeatureRuin1 = 16999,

        [ConflictingCombos(SummonerMainComboFeatureRuin1)]
        [CustomComboInfo("Enable Single Target (RuinIII)", "Enables changing Single-Target Combo (Ruin III).", SMN.JobID)]
        SummonerMainComboFeature = 17000,

        [CustomComboInfo("Enable AOE", "Enables changing AOE Combo (Tri-Disaster)", SMN.JobID)]
        SummonerAOEComboFeature = 17001,

        [CustomComboInfo("Single Target Demi Feature", "Replaces Astral Impulse/Fountain of Fire with Enkindle/Deathflare/Rekindle when appropriate.", SMN.JobID)]
        SummonerSingleTargetDemiFeature = 17002,

        [ParentCombo(SummonerAOEComboFeature)]
        [CustomComboInfo("AOE Demi Feature", "Replaces Astral Flare/Brand of Purgatory with Enkindle/Deathflare/Rekindle when appropriate.", SMN.JobID)]
        SummonerAOEDemiFeature = 17003,

        [CustomComboInfo("Egi Attacks Feature", "Replaces RuinI/Ruin III (Depending On Enabeled Combo) and Tri-Disaster with Egi attacks. Will not work without enabling Single Target and/or AOE.", SMN.JobID)]
        SummonerEgiAttacksFeature = 17004,

        [CustomComboInfo("Garuda Slipstream Feature", "Adds Slipstream on RuinI/Ruin III/Tri-disaster.", SMN.JobID)]
        SummonerGarudaUniqueFeature = 17005,

        [CustomComboInfo("Ifrit Cyclone Feature", "Adds Crimson Cyclone/Crimson Strike on RuinI/Ruin III/Tri-disaster.", SMN.JobID)]
        SummonerIfritUniqueFeature = 17006,

        [CustomComboInfo("Titan Mountain Buster Feature", "Adds Mountain Buster on RuinI/Ruin III/Tri-disaster.", SMN.JobID)]
        SummonerTitanUniqueFeature = 17007,

        [CustomComboInfo("ED Fester", "Change Fester into Energy Drain when our of Aetherflow stacks.", SMN.JobID)]
        SummonerEDFesterCombo = 17008,

        [CustomComboInfo("ES Painflare", "Change Painflare into Energy Siphon when out of Aetherflow stacks.", SMN.JobID)]
        SummonerESPainflareCombo = 17009,

        // BONUS TWEAKS
        [CustomComboInfo("Carbuncle Reminder Feature", "Reminds you always to summon Carbuncle by replacing Ruin (Carbuncle Summon Reminder Feature).", SMN.JobID)]
        SummonerCarbuncleSummonFeature = 17010,

        [CustomComboInfo("Ruin 4 On Ruin3 Combo Feature", "Adds Ruin4 on main RuinI/RuinIII combo feature when there are currently no summons being active.", SMN.JobID)]
        SummonerRuin4ToRuin3Feature = 17011,

        [CustomComboInfo("Ruin 4 On Tri-disaster Feature", "Adds Ruin4 on main Tridisaster combo feature when there are currently no summons being active.", SMN.JobID)]
        SummonerRuin4ToTridisasterFeature = 17012,

        [ParentCombo(SummonerEDFesterCombo)]
        [CustomComboInfo("Ruin IV Fester/PainFlare Feature", "Change Fester/PainFlare into Ruin IV when out of Aetherflow stacks, ED/ES is on cooldown, and Ruin IV is up.", SMN.JobID)]
        SummonerFesterPainflareRuinFeature = 17013,

        [ParentCombo(SummonerEDFesterCombo)]
        [CustomComboInfo("Lazy Fester Feature", "Adds ED/Fester during (AstralImpulse).\n. Will only ED during Phoenix phase in order to save it Fester for burst in bahamut", SMN.JobID)]
        SummonerLazyFesterFeature = 17014,

        [ConflictingCombos(SimpleSummonerOption2)]
        [CustomComboInfo("One Button Rotation Feature", "Summoner Single Target One Button Rotation (Single Target) on Ruin1/Ruin3.(Titan>Garuda>Ifrit) ", SMN.JobID)]
        SimpleSummoner = 17015,

        [CustomComboInfo("One Button AoE Rotation Feature", "Summoner AoE One Button Rotation (AoE) on Tridisaster", SMN.JobID)]
        SimpleAoESummoner = 17016,

        [ParentCombo(SimpleSummoner)]
        [CustomComboInfo("Searing Light Rotation Option", "Adds Searing Light to Simple Summoner Rotation, Single Target", SMN.JobID)]
        BuffOnSimpleSummoner = 17017,

        [ParentCombo(SimpleAoESummoner)]
        [CustomComboInfo("Searing Light  AoE Option", "Adds Searing Light to Simple Summoner Rotation, AoE", SMN.JobID)]
        BuffOnSimpleAoESummoner = 17018,

        [CustomComboInfo("DemiReminderFeature", "Adds Only Demi Summons on RuinIII (So you can still choose your Egis but never forget to summon Demis) ", SMN.JobID)]
        SummonerDemiSummonsFeature = 17019,

        [CustomComboInfo("DemiReminderAoEFeature", "Adds Only Demi Summons on TriDisaster (So you can still choose your Egis but never forget to summon Demis) ", SMN.JobID)]
        SummonerDemiAoESummonsFeature = 17020,

        [ConflictingCombos(SummonerMainComboFeatureRuin1)]
        [CustomComboInfo("Ruin III mobility", "Allows you to cast Ruin III while Ruin IV is unavailable for mobility reasons. Shows up as Ruin I.\nWill break combos with Ruin I. Might break combos with Ruin IV.", SMN.JobID)]
        SummonerRuinIVMobilityFeature = 17021,

        [ConflictingCombos(SummonerSwiftcastFeatureIfrit)]
        [CustomComboInfo("Swiftcast Garuda Option", "Always swiftcasts Slipstream if available.", SMN.JobID)]
        SummonerSwiftcastFeatureGaruda = 17022,

        [ConflictingCombos(SummonerSwiftcastFeatureGaruda)]
        [CustomComboInfo("Swiftcast Ifrit Option", "Always swiftcasts 2nd Ruby Rite if available.", SMN.JobID)]
        SummonerSwiftcastFeatureIfrit = 17023,

        [ConflictingCombos(SimpleSummoner)]
        [CustomComboInfo("One Button Rotation Feature Option2 ", "Same feature as One Button Rotation Feature but Garua>Titan>Ifrit .", SMN.JobID)]
        SimpleSummonerOption2 = 17024,

        [CustomComboInfo("Prevent Ruin4 Waste Feature", "Puts Ruin4 Above anything if FurtherRuin about to expire and there is no Demi present.", SMN.JobID)]
        SummonerRuin4WastePrevention = 17025,

        [CustomComboInfo("Rekindle Feature", "Adds Rekindle onto the main Ruin1 or Ruin3 combo. Requires other features to work.", SMN.JobID)]
        SummonerRekindlePhoenix = 17026,


        #endregion
        // ====================================================================================
        #region WARRIOR

        [CustomComboInfo("Storms Path Combo", "All in one main combo feature adds Storm's Eye/Path", WAR.JobID)]
        WarriorStormsPathCombo = 18000,

        [CustomComboInfo("Storms Eye Combo", "Replace Storms Eye with its combo chain", WAR.JobID)]
        WarriorStormsEyeCombo = 18001,

        [CustomComboInfo("Overpower Combo", "Add combos to Overpower", WAR.JobID)]
        WarriorMythrilTempestCombo = 18002,

        [CustomComboInfo("Warrior Gauge Overcap Feature", "Replace Single-target or AoE combo with gauge spender if you are about to overcap and are before a step of a combo that would generate beast gauge", WAR.JobID)]
        WarriorGaugeOvercapFeature = 18003,

        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Inner Release Feature", "Replace Single-target and AoE combo with Fell Cleave/Decimate during Inner Release", WAR.JobID)]
        WarriorInnerReleaseFeature = 18004,

        [CustomComboInfo("Nascent Flash Feature", "Replace Nascent Flash with Raw intuition when level synced below 76", WAR.JobID)]
        WarriorNascentFlashFeature = 18005,

        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Fellcleave/IB Feature", "Replaces Main Combo With Fellcleave/IB When you are about to overcap ", WAR.JobID)]
        WarriorFellCleaveOvercapFeature = 18006,

        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Upheaval Feature", "Adds Upheaval into maincombo if you have Surging Tempest and if you're synced below 70 while Beserk buff is ON CD", WAR.JobID)]
        WarriorUpheavalMainComboFeature = 18007,

        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Primal Rend Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available (Also added onto Main AoE combo)", WAR.JobID)]
        WarriorPrimalRendFeature = 18008,

        [CustomComboInfo("Orogeny Feature", "Adds Orogeny onto main AoE combo when you are buffed with Surging Tempest", WAR.JobID)]
        WarriorOrogenyFeature = 18009,

        [CustomComboInfo("Inner Chaos option", "Adds Inner Chaos to Storms Path Combo and Chaotic Cyclone to Overpower Combo if you are buffed with Nascent Chaos and Surging Tempest.\nRequires Storms Path Combo and Overpower Combo", WAR.JobID)]
        WarriorInnerChaosOption = 18010,

        [CustomComboInfo("Fell Cleave/Decimate Option", "Adds Fell Cleave to main combo when gauge is at 50 or more and adds Decimate to the AoE combo", WAR.JobID)]
        WarriorSpenderOption = 18011,

        [ConflictingCombos(WarriorOnslaughtFeatureOption, WarriorOnslaughtFeatureOptionTwo)]
        [CustomComboInfo("Onslaught Feature", "Adds Onslaught to Storm's Path feature combo if you are under Surging Tempest Buff (Uses all stacks)", WAR.JobID)]
        WarriorOnslaughtFeature = 18012,

        [ConflictingCombos(WarriorOnslaughtFeature, WarriorOnslaughtFeatureOptionTwo)]
        [CustomComboInfo("Onslaught Option", "Adds Onslaught to Storm's Path feature combo if you are under Surging Tempest Buff (Leaves 1 stack)", WAR.JobID)]
        WarriorOnslaughtFeatureOption = 18013,

        [ConflictingCombos(WarriorOnslaughtFeature, WarriorOnslaughtFeatureOption)]
        [CustomComboInfo("Onslaught Option Two", "Adds Onslaught to Storm's Path feature combo if you are under Surging Tempest Buff (Leaves 1/2 stacks depending on lvl)", WAR.JobID)]
        WarriorOnslaughtFeatureOptionTwo = 18014,

        [CustomComboInfo("Infuriate Feature", "Replaces Infuriate with FellCleave when under InnerRelease buff. Replaces Infuriate with Inner Chaos When under Nascent Chaos buff", WAR.JobID)]
        WarriorInfuriateFeature = 18015,

        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Tomahawk Uptime Feature", "Replace Storm's Path Combo Feature with Tomahawk when you are out of range.", WAR.JobID)]
        WARRangedUptimeFeature = 18016,

        [CustomComboInfo("Interrupt Feature", "Replaces LowBlow with Interject when target can be interrupted .", WAR.JobID)]
        WarriorInterruptFeature = 18017,

        #endregion
        // ====================================================================================
        #region WHITE MAGE


        [CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used", WHM.JobID)]
        WhiteMageSolaceMiseryFeature = 19000,

        [CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used", WHM.JobID)]
        WhiteMageRaptureMiseryFeature = 19001,

        [CustomComboInfo("Cure 2 to Cure Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID)]
        WhiteMageCureFeature = 19002,

        [CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID)]
        WhiteMageAfflatusFeature = 19003,

        [ConflictingCombos(WHMAlternativeRaise)]
        [CustomComboInfo("WHM Raise Feature", "Changes Swiftcast to Raise", WHM.JobID)]
        WHMRaiseFeature = 19004,

        [ConflictingCombos(WHMRaiseFeature)]
        [CustomComboInfo("WHM Raise Feature alternative", "Raise Becomes Swiftcast when Swiftcast is available. Thin air feature also applies to this if enabled.", WHM.JobID)]
        WHMAlternativeRaise = 19015,

        [CustomComboInfo("DoT on Glare3 Feature", "Adds DoT on Glare3 when DoT is not preset on about to expire and when you are inCombat (You can still prepull Glare)", WHM.JobID)]
        WHMDotMainComboFeature = 19005,

        [ParentCombo(WHMDotMainComboFeature)]
        [CustomComboInfo("Lucid Dreaming Feature", "Adds Lucid dreaming onto Glare1/3 Feature combo when you are below 8k mana", WHM.JobID)]
        WHMLucidDreamingFeature = 19006,

        [CustomComboInfo("Medica Feature", "Replaces Medica2 whenever you are under Medica2 regen with Medica1", WHM.JobID)]
        WHMMedicaFeature = 19007,

        [ParentCombo(WHMDotMainComboFeature)]
        [CustomComboInfo("Presence Of Mind Feature", "Adds Presence of mind as oGCD onto main DPS Feature(Glare3)", WHM.JobID)]
        WHMPresenceOfMindFeature = 19008,

        [ParentCombo(WHMDotMainComboFeature)]
        [CustomComboInfo("Assize Feature", "Adds Assize as oGCD onto main DPS Feature(Glare3)", WHM.JobID)]
        WHMAssizeFeature = 19009,

        [ParentCombo(WHMMedicaFeature)]
        [CustomComboInfo("Afflatus Misery On Medica Feature", "Adds Afflatus Misery onto the Medica Feature", WHM.JobID)]
        WhiteMageAfflatusMiseryMedicaFeature = 19010,

        [ParentCombo(WHMMedicaFeature)]
        [CustomComboInfo("Afflatus Rapture On Medica Feature", "Adds Afflatus Rapture onto the Medica Feature", WHM.JobID)]
        WhiteMageAfflatusRaptureMedicaFeature = 19011,

        [CustomComboInfo("Afflatus Misery Feature", "Changes Cure 2 into Afflatus Misery.", WHM.JobID)]
        WhiteMageAfflatusMiseryCure2Feature = 19012,

        [ParentCombo(WHMDotMainComboFeature)]
        [CustomComboInfo("Remove DoT From Glare3 Feature", "Removes DoT from DPS feature", WHM.JobID)]
        WHMRemoveDotFromDPSFeature = 19013,

        [CustomComboInfo("Thin Air Raise Feature", "Adds Thin Air to the WHM Raise Feature/Alternative Feature", WHM.JobID)]
        WHMThinAirFeature = 19014,

        #endregion
        // ====================================================================================
        #region DOH

        // [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
        // DohPlaceholder = 50001,

        #endregion
        // ====================================================================================
        #region DOL

        [CustomComboInfo("Eureka Feature", "Replace Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
        DolEurekaFeature = 51001,

        [CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", DOL.JobID)]
        DolCastHookFeature = 51002,

        [CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when underwater.", DOL.JobID)]
        DolCastGigFeature = 51003,

        [CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when underwater.", DOL.JobID)]
        DolSurfaceTradeFeature = 51004,

        [CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when underwater.", DOL.JobID)]
        DolPrizeBountyFeature = 51005,

        [CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when underwater.", DOL.JobID)]
        DolSnaggingSalvageFeature = 51006,

        [CustomComboInfo("Cast Light / Electric Current Feature", "Replace Cast Light with Electric Current when underwater.", DOL.JobID)]
        DolCastLightElectricCurrentFeature = 51007,

        #endregion
        // ====================================================================================
        #region PvP Combos

        [SecretCustomCombo]
        [CustomComboInfo("BurstShotFeature", "Adds Shadowbite/EmpyArrow/PitchPerfect(3stacks)/SideWinder(When Target is low hp)/ApexArrow when gauge is 100 all on one button combo.", BRDPvP.JobID)]
        BurstShotFeaturePVP = 80000,

        [SecretCustomCombo]
        [CustomComboInfo("SongsFeature", "Replaces WanderersMinnuet and Peons song all on one button in an optimal order", BRDPvP.JobID)]
        SongsFeaturePVP = 80001,

        [SecretCustomCombo]
        [CustomComboInfo("SouleaterComboFeature", "Adds EoS as oGCD onto main combo and Bloodspiller when at 50 gauge or under delirium buff.", DRKPVP.JobID)]
        SouleaterComboFeature = 80002,

        [SecretCustomCombo]
        [CustomComboInfo("StalwartSoulComboFeature", "Adds FoS as oGCD onto main combo and Quietus when at 50 gauge or under delirium buff.", DRKPVP.JobID)]
        StalwartSoulComboFeature = 80003,

        [SecretCustomCombo]
        [CustomComboInfo("StormsPathComboFeature", "Replaces Storm's Path Combo with FellCleave/IC when at 50 gauge or under IR", WARPVP.JobID)]
        StormsPathComboFeature = 80004,

        [SecretCustomCombo]
        [CustomComboInfo("SteelCycloneFeature", "Replaces Steel Cyclone Combo with Decimate/CC when at 50 gauge or under IR", WARPVP.JobID)]
        SteelCycloneFeature = 80005,

        [SecretCustomCombo]
        [CustomComboInfo("RoyalAuthorityComboFeature", "Adds HolySpirit To the main combo", PLDPVP.JobID)]
        RoyalAuthorityComboFeature = 80006,

        [SecretCustomCombo]
        [CustomComboInfo("ProminenceComboFeature", "Adds HolyCircle to the main AoE Combo", PLDPVP.JobID)]
        ProminenceComboFeature = 80007,

        [SecretCustomCombo]
        [CustomComboInfo("GnashingFangComboFeature", "Adds BowShock(When target is meleeRange) and Burststrike at 2 ammo gauge to the main combo", GNBPVP.JobID)]
        SolidBarrelComboFeature = 80008,

        [SecretCustomCombo]
        [CustomComboInfo("DemonSlaughterComboFeature", "Adds BowShock(When target is meleeRange) and Fated Circle at 2 ammo gauge to the main AoE combo", GNBPVP.JobID)]
        DemonSlaughterComboFeature = 80009,

        [SecretCustomCombo]
        [CustomComboInfo("HeatedCleanShotFeature", "Adds Gauss/Rico weave to maincombo", MCHPVP.JobID)]
        HeatedCleanShotFeature = 80010,

        [SecretCustomCombo]
        [CustomComboInfo("WildfireBlankFeature", "Adds Blank To Wildfire if you are in melee Range", MCHPVP.JobID)]
        WildfireBlankFeature = 80011,

        [SecretCustomCombo]
        [CustomComboInfo("InfernalSliceComboFeature", "Adds Gluttony/BloodStalk/Smite/EnshroudComboRotation on InfernalSliceCombo", RPRPVP.JobID)]
        InfernalSliceComboFeature = 80012,

        [SecretCustomCombo]
        [CustomComboInfo("NightmareScytheComboFeature", "Adds Gluttony/GrimSwathe/Smite/EnshroudComboRotation on InfernalScytheCombo", RPRPVP.JobID)]
        NightmareScytheComboFeature = 80013,

        [SecretCustomCombo]
        [CustomComboInfo("NinjaAeolianEdgePvpCombo", "Adds Cha/Assassinate/Smite on AeolianEdge combo", NINPVP.JobID)]
        NinjaAeolianEdgePvpCombo = 80014,

        [SecretCustomCombo]
        [CustomComboInfo("MnkBootshinePvPFeature", "Adds Axekick/Smite/TornadoKick on main combo", MNKPVP.JobID)]
        MnkBootshinePvPFeature = 80015,

        [SecretCustomCombo]
        [CustomComboInfo("BlackEnochianPVPFeature", "Enochian Stance Switcher", BLMPVP.JobID)]
        BlackEnochianPVPFeature = 80016,


        #endregion
    }
}
