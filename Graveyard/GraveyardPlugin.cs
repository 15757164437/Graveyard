using System;
using System.Reflection;
using System.Windows.Controls;
using HDT.Plugins.Graveyard.Resources;
using Hearthstone_Deck_Tracker.Plugins;

namespace HDT.Plugins.Graveyard
{
	public class GraveyardPlugin : IPlugin
	{
		public Graveyard GraveyardInstance;
        public string Author => "RedHatter";
        public string ButtonText => Strings.Settings;


        public string Description => Strings.GraveyardDescription;

        public MenuItem MenuItem => null;
        public string Name => "Graveyard";

        public void OnButtonPress() => SettingsView.Flyout.IsOpen = true;
        public void OnLoad() => GraveyardInstance = new Graveyard();
        public void OnUnload()
        {
            Settings.Default.Save();

            GraveyardInstance.Dispose();
            GraveyardInstance = null;
        }
        public void OnUpdate() { }

        public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
        public static readonly Version PluginVersion = new Version(AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);
        public Version Version => PluginVersion;
    }
}
