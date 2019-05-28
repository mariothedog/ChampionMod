using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class OrangeFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Fish");
        }

        public override void SetDefaults()
        {
            item.questItem = true;
            item.maxStack = 1;
            item.width = 26;
            item.height = 26;
            item.uniqueStack = true;  // So you can only have one in your inventory
            item.rare = ItemRarityID.Quest;
        }

        public override bool IsQuestFish()
        {
            return true;
        }

        public override bool IsAnglerQuestAvailable()
        {
            return NPC.downedSlimeKing;  // Quest only available once King Slime is killed
        }

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "I know a guy who knows a fish who knows a slime who knows that you need a baby slime for this quest.\nIt's a me a Mario!";
            catchLocation = "Caught anywhere but you need a baby slime to help you";
        }
    }
}