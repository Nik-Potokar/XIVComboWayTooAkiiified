using Dalamud.Game.Command;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace XIVSlothComboPlugin
{
    /// <summary>
    /// Main plugin implementation.
    /// </summary>
    public sealed partial class XIVComboExpandedPlugin : IDalamudPlugin
    {
        private const string Command = "/scombo";

        private readonly WindowSystem windowSystem;
        private readonly ConfigWindow configWindow;

        private readonly TextPayload starterMotd = new("[Sloth Message of the Day] ");

        /// <summary>
        /// Initializes a new instance of the <see cref="XIVComboExpandedPlugin"/> class.
        /// </summary>
        /// <param name="pluginInterface">Dalamud plugin interface.</param>
        public XIVComboExpandedPlugin(DalamudPluginInterface pluginInterface)
        {
            FFXIVClientStructs.Resolver.Initialize();

            pluginInterface.Create<Service>();

            Service.Configuration = pluginInterface.GetPluginConfig() as PluginConfiguration ?? new PluginConfiguration();
            Service.Address = new PluginAddressResolver();
            Service.Address.Setup();

            if (Service.Configuration.Version == 4)
                this.UpgradeConfig4();

            Service.ComboCache = new CustomComboCache();
            Service.IconReplacer = new IconReplacer();
            ActionWatching.Enable();

            this.configWindow = new();
            this.windowSystem = new("XIVSlothCombo");
            this.windowSystem.AddWindow(this.configWindow);

            Service.Interface.UiBuilder.OpenConfigUi += this.OnOpenConfigUi;
            Service.Interface.UiBuilder.Draw += this.windowSystem.Draw;

            Service.CommandManager.AddHandler(Command, new CommandInfo(this.OnCommand)
            {
                HelpMessage = "Open a window to edit custom combo settings.",
                ShowInHelp = true,
            });

            Service.ClientState.Login += PrintLoginMessage;

        }

        private void PrintLoginMessage(object? sender, EventArgs e)
        {
            if (!Service.Configuration.HideMessageOfTheDay)
                Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(task => PrintMotD());

        }

        private void PrintMotD()
        {
            try
            {
                using var motd = Dalamud.Utility.Util.HttpClient.GetAsync("https://raw.githubusercontent.com/Nik-Potokar/XIVSlothCombo/main/res/motd.txt").Result;
                motd.EnsureSuccessStatusCode();
                var data = motd.Content.ReadAsStringAsync().Result;
                var payloads = new List<Payload>()
                {
                    starterMotd,
                    EmphasisItalicPayload.ItalicsOn,
                    new TextPayload(data.Trim()),
                    EmphasisItalicPayload.ItalicsOff
                };

                Service.ChatGui.PrintChat(new XivChatEntry
                {
                    Message = new SeString(payloads),
                    Type = XivChatType.Echo
                });
            }
            catch (Exception ex)
            {
                Dalamud.Logging.PluginLog.Error(ex, "Unable to retrieve MOTD");
            }
        }

        /// <inheritdoc/>
        public string Name => "XIVSlothCombo";

        /// <inheritdoc/>
        public void Dispose()
        {
            Service.CommandManager.RemoveHandler(Command);

            Service.Interface.UiBuilder.OpenConfigUi -= this.OnOpenConfigUi;
            Service.Interface.UiBuilder.Draw -= this.windowSystem.Draw;

            Service.IconReplacer?.Dispose();
            Service.ComboCache?.Dispose();
            ActionWatching.Dispose();

            Service.ClientState.Login -= PrintLoginMessage;
        }

        private void OnOpenConfigUi()
            => this.configWindow.IsOpen = true;

        private void OnCommand(string command, string arguments)
        {
            var argumentsParts = arguments.Split();

            switch (argumentsParts[0].ToLower())
            {
                case "unsetall":
                    {
                        foreach (var preset in Enum.GetValues<CustomComboPreset>())
                        {
                            Service.Configuration.EnabledActions.Remove(preset);
                        }

                        Service.ChatGui.Print("All UNSET");
                        Service.Configuration.Save();
                        break;
                    }

                case "set":
                    {
                        if (!Service.Condition[Dalamud.Game.ClientState.Conditions.ConditionFlag.InCombat])
                        {
                            var targetPreset = argumentsParts[1].ToLowerInvariant();
                            foreach (var preset in Enum.GetValues<CustomComboPreset>())
                            {
                                if (preset.ToString().ToLowerInvariant() != targetPreset)
                                    continue;

                                Service.Configuration.EnabledActions.Add(preset);
                                Service.ChatGui.Print($"{preset} SET");
                            }

                            Service.Configuration.Save();
                        }
                        else
                        {
                            Service.ChatGui.PrintError("Features cannot be set in combat.");
                        }
                        break;
                    }

                case "toggle":
                    {
                        if (!Service.Condition[Dalamud.Game.ClientState.Conditions.ConditionFlag.InCombat])
                        {


                            var targetPreset = argumentsParts[1].ToLowerInvariant();
                            foreach (var preset in Enum.GetValues<CustomComboPreset>())
                            {
                                if (preset.ToString().ToLowerInvariant() != targetPreset)
                                    continue;

                                if (Service.Configuration.EnabledActions.Contains(preset))
                                {
                                    Service.Configuration.EnabledActions.Remove(preset);
                                    Service.ChatGui.Print($"{preset} UNSET");
                                }
                                else
                                {
                                    Service.Configuration.EnabledActions.Add(preset);
                                    Service.ChatGui.Print($"{preset} SET");
                                }
                            }

                            Service.Configuration.Save();
                        }
                        else
                        {
                            Service.ChatGui.PrintError("Features cannot be toggled in combat.");
                        }
                        break;
                    }

                case "unset":
                    {
                        if (!Service.Condition[Dalamud.Game.ClientState.Conditions.ConditionFlag.InCombat])
                        {
                            var targetPreset = argumentsParts[1].ToLowerInvariant();
                            foreach (var preset in Enum.GetValues<CustomComboPreset>())
                            {
                                if (preset.ToString().ToLowerInvariant() != targetPreset)
                                    continue;

                                Service.Configuration.EnabledActions.Remove(preset);
                                Service.ChatGui.Print($"{preset} UNSET");
                            }

                            Service.Configuration.Save();
                        }
                        else
                        {
                            Service.ChatGui.PrintError("Features cannot be unset in combat.");
                        }
                        break;
                    }

                case "list":
                    {
                        var filter = argumentsParts.Length > 1
                            ? argumentsParts[1].ToLowerInvariant()
                            : "all";

                        if (filter == "set")
                        {
                            foreach (var preset in Enum.GetValues<CustomComboPreset>()
                                .Select(preset => Service.Configuration.IsEnabled(preset)))
                            {
                                Service.ChatGui.Print(preset.ToString());
                            }
                        }
                        else if (filter == "unset")
                        {
                            foreach (var preset in Enum.GetValues<CustomComboPreset>()
                                .Select(preset => !Service.Configuration.IsEnabled(preset)))
                            {
                                Service.ChatGui.Print(preset.ToString());
                            }
                        }
                        else if (filter == "all")
                        {
                            foreach (var preset in Enum.GetValues<CustomComboPreset>())
                            {
                                Service.ChatGui.Print(preset.ToString());
                            }
                        }
                        else
                        {
                            Service.ChatGui.PrintError("Available list filters: set, unset, all");
                        }

                        break;
                    }
                case "enabled":
                    {
                        foreach (var preset in Service.Configuration.EnabledActions.OrderBy(x => x))
                        {
                            if (int.TryParse(preset.ToString(), out int pres)) continue;
                            Service.ChatGui.Print($"{(int)preset} - {preset}");
                        }
                        break;
                    }
                case "debug":
                    {
                        try
                        {
                            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                            using StreamWriter file = new($"{desktopPath}/SlothDebug.txt", append: false);

                            file.WriteLine("START DEBUG LOG");
                            file.WriteLine($"Current Job: {Service.ClientState.LocalPlayer.ClassJob.Id}");
                            file.WriteLine($"Current Zone: {Service.ClientState.TerritoryType}");
                            file.WriteLine($"Current Party Size: {Service.PartyList.Length}");
                            file.WriteLine($"START ENABLED FEATURES");

                            int i = 0;
                            foreach (var preset in Service.Configuration.EnabledActions.OrderBy(x => x))
                            {
                                if (int.TryParse(preset.ToString(), out _)) { i++; continue; }
                                file.WriteLine($"{(int)preset} - {preset}");
                            }
                            file.WriteLine($"END ENABLED FEATURES");
                            file.WriteLine($"Redundant IDs found: {i}");
                            if (i > 0)
                            {
                                file.WriteLine($"START REDUNDANT IDs");
                                foreach (var preset in Service.Configuration.EnabledActions.Where(x => int.TryParse(x.ToString(), out _)).OrderBy(x => x))
                                {
                                    file.WriteLine($"{(int)preset}");
                                }
                                file.WriteLine($"END REDUNDANT IDs");
                            }
                            file.WriteLine($"Status Effect Count: {Service.ClientState.LocalPlayer.StatusList.Count(x => x != null)}");
                            if (Service.ClientState.LocalPlayer.StatusList.Count() > 0)
                            {
                                file.WriteLine($"START STATUS EFFECTS");
                                foreach (var status in Service.ClientState.LocalPlayer.StatusList)
                                {
                                    file.WriteLine($"ID: {status.StatusId}, COUNT: {status.StackCount}, SOURCE: {status.SourceID}");
                                }
                                file.WriteLine($"END STATUS EFFECTS");

                            }

                            file.WriteLine("END DEBUG LOG");
                            Service.ChatGui.Print("Please check your desktop for SlothDebug.txt and upload this file where requested.");
                            break;
                        }
                        catch
                        {
                            Service.ChatGui.Print("Unable to write Debug log.");
                            break;
                        }
                    }
                default:
                    this.configWindow.Toggle();
                    break;
            }

            Service.Configuration.Save();
        }

        private void UpgradeConfig4()
        {
            Service.Configuration.Version = 5;
            Service.Configuration.EnabledActions = Service.Configuration.EnabledActions4
                .Select(preset => (int)preset switch
                    {
                        27 => 3301,
                        75 => 3302,
                        73 => 3303,
                        25 => 2501,
                        26 => 2502,
                        56 => 2503,
                        70 => 2504,
                        71 => 2505,
                        110 => 2506,
                        95 => 2507,
                        41 => 2301,
                        42 => 2302,
                        63 => 2303,
                        74 => 2304,
                        33 => 3801,
                        31 => 3802,
                        34 => 3803,
                        43 => 3804,
                        50 => 3805,
                        72 => 3806,
                        103 => 3807,
                        44 => 2201,
                        0 => 2202,
                        1 => 2203,
                        2 => 2204,
                        3 => 3201,
                        4 => 3202,
                        57 => 3203,
                        85 => 3204,
                        20 => 3701,
                        52 => 3702,
                        96 => 3703,
                        97 => 3704,
                        22 => 3705,
                        30 => 3706,
                        83 => 3707,
                        84 => 3708,
                        23 => 3101,
                        24 => 3102,
                        47 => 3103,
                        58 => 3104,
                        66 => 3105,
                        102 => 3106,
                        54 => 2001,
                        82 => 2002,
                        106 => 2003,
                        17 => 3001,
                        18 => 3002,
                        19 => 3003,
                        87 => 3004,
                        88 => 3005,
                        89 => 3006,
                        90 => 3007,
                        91 => 3008,
                        92 => 3009,
                        107 => 3010,
                        108 => 3011,
                        5 => 1901,
                        6 => 1902,
                        59 => 1903,
                        7 => 1904,
                        55 => 1905,
                        86 => 1906,
                        69 => 1907,
                        48 => 3501,
                        49 => 3502,
                        68 => 3503,
                        53 => 3504,
                        93 => 3505,
                        101 => 3506,
                        94 => 3507,
                        11 => 3401,
                        12 => 3402,
                        13 => 3403,
                        14 => 3404,
                        15 => 3405,
                        81 => 3406,
                        60 => 3407,
                        61 => 3408,
                        64 => 3409,
                        65 => 3410,
                        109 => 3411,
                        29 => 2801,
                        37 => 2802,
                        39 => 2701,
                        40 => 2702,
                        8 => 2101,
                        9 => 2102,
                        10 => 2103,
                        78 => 2104,
                        79 => 2105,
                        67 => 2106,
                        104 => 2107,
                        35 => 2401,
                        36 => 2402,
                        76 => 2403,
                        77 => 2404,
                        _ => 0,
                    })
                .Where(id => id != 0)
                .Select(id => (CustomComboPreset)id)
                .ToHashSet();
            Service.Configuration.EnabledActions4 = new();
            Service.Configuration.Save();
        }
    }
}