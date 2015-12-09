using ICities;
using System.Collections.Generic;

namespace RandomizeAgeCimsMoveIn
{
    public class ModInfo : IUserMod
	{
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