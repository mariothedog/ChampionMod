using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Credit to Example Mod
// https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption
namespace ChampionMod.Items.Weapons.MagicBeamsStaffs
{
    class EclipseStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
            Tooltip.SetDefault("Creates an eclipse beam that bounces off walls");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.shoot = mod.ProjectileType("MoonStaffProjectile");
            item.damage = 16;
            item.mana = 6;
            item.useTime = 21;
            item.useAnimation = 21;
            item.value = 20000; // 40 silver
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:EvilBars", 15);
            recipe.AddRecipeGroup("ChampionMod:Tier3Bars", 5);
            recipe.AddIngredient(mod.ItemType("SunStaff"));
            recipe.AddIngredient(mod.ItemType("MoonStaff"));
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOrigin() // HoldoutOrigin works with staffs unlike HoldoutOffset
        {
            return new Vector2(20, 20);
        }
    }
}
