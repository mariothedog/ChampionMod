using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace SingleSwordMod
{
	class SingleSwordMod : Mod
	{
		public SingleSwordMod()
		{
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Common Broadswords", new int[]
            {
                    ItemID.LeadBroadsword,
                    ItemID.IronBroadsword
            });
            RecipeGroup.RegisterGroup("SingleSwordMod:CommonBroadswords", group);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.AddRecipeGroup("SingleSwordMod:CommonBroadswords");
            recipe.SetResult(ItemID.IronHammer);
            recipe.AddRecipe();
        }
    }
}
