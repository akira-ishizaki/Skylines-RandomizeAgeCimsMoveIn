using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.IO;

namespace RandomizeAgeCimsMoveIn
{
    public class ModInfo : IUserMod
    {
        public const string SETTINGFILENAME = "RandomizeAgeCimsMoveIn.xml";

        public string MODNAME = "Randomize Age Cims Move in";

		List<RedirectCallsState> m_redirectionStates = new List<RedirectCallsState>();

		public RedirectCallsState[] revertMethods = new RedirectCallsState[8];

		public string Name
		{
			get
			{
                return MODNAME;
			}
        }

        public string Description
        {
            get { return "This increases the randomization of incoming cims' initial ages."; }
        }

        public static string configPath;

        public static ModConfiguration ModConf;

        public void OnSettingsUI(UIHelperBase helper)
        {
            this.InitConfigFile();
            UIHelperBase group = helper.AddGroup("Settings");
            group.AddCheckbox("Randomize incoming cims' education level", ModConf.RandomizeEducationLevel, delegate (bool isChecked)
            {
                ModInfo.ModConf.RandomizeEducationLevel = isChecked;
                ModConfiguration.Serialize(ModInfo.configPath, ModInfo.ModConf);
            });
        }

        private void InitConfigFile()
        {
            try
            {
                string pathName = GameSettings.FindSettingsFileByName("gameSettings").pathName;
                string str = "";
                if (pathName != "")
                {
                    str = Path.GetDirectoryName(pathName) + Path.DirectorySeparatorChar;
                }
                ModInfo.configPath = str + SETTINGFILENAME;
                ModInfo.ModConf = ModConfiguration.Deserialize(ModInfo.configPath);
                if (ModInfo.ModConf == null)
                {
                    ModInfo.ModConf = ModConfiguration.Deserialize(SETTINGFILENAME);
                    if (ModInfo.ModConf != null && ModConfiguration.Serialize(str + SETTINGFILENAME, ModInfo.ModConf))
                    {
                        try
                        {
                            File.Delete(SETTINGFILENAME);
                        }
                        catch
                        {
                        }
                    }
                }
                if (ModInfo.ModConf == null)
                {
                    ModInfo.ModConf = new ModConfiguration();
                    if (!ModConfiguration.Serialize(ModInfo.configPath, ModInfo.ModConf))
                    {
                        ModInfo.configPath = SETTINGFILENAME;
                        ModConfiguration.Serialize(ModInfo.configPath, ModInfo.ModConf);
                    }
                }
            }
            catch
            {
            }
        }
    }
    
    public sealed class LoadingExtension : LoadingExtensionBase
    {
        List<RedirectCallsState> m_redirectionStates = new List<RedirectCallsState>();

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
            {
                RedirectionHelper.RedirectCalls(m_redirectionStates, typeof(OutsideConnectionAI), typeof(CustomOutsideConnectionAI), "StartConnectionTransfer", 7);
            }
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            foreach (RedirectCallsState rcs in m_redirectionStates)
            {
                RedirectionHelper.RevertRedirect(rcs);
            }
        }
    }
}