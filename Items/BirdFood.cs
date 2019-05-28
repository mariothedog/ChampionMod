using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class BirdFood : ModItem
    {
        public override void SetDefaults()
        {
           //item.name = "Bird Food";
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            //AddTooltip("Summon the Bird!");
            item.value = 100;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Mariothedog"));
            //return !Main.dayTime; // So it only spawns at night
        }
        
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Mariothedog"));
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}