#region

using System;
using System.Collections.Generic;
using System.Linq;
using db.data;
using log4net;

#endregion

namespace wServer.realm.entities
{
    internal class MerchantLists
    {
        public static int[] AccessoryClothList;
        public static int[] AccessoryDyeList;
        public static int[] ClothingClothList;
        public static int[] ClothingDyeList;

        public static Dictionary<int, Tuple<int, CurrencyType>> prices = new Dictionary<int, Tuple<int, CurrencyType>>
        {

            //WEAPONS
            {0xaf6, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Wand Of Recompence T12
            {0xa87, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Wand Of Ancient Warning T11
            {0xa86, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Wand Of Shadow T10
            {0xa85, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Wand Of Deep Sorcery T9
            {0xa07, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Wand Of Death T8
            {0xb02, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Bow Of Covert Havens T12
            {0xa8d, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Bow Of Innocent Blood T11
            {0xa8c, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Bow Of fey Magic T10
            {0xa8b, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Verdant Bow T9
            {0xa1e, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Golden Bow T8
            {0xb08, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Staff of the cosmicWhole T12
            {0xaa2, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Staff of Astral Knowledge T11
            {0xaa1, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Staff of Diabolical Secrets T10
            {0xaa0, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Staff Of Necrotic Arcana T9
            {0xa9f, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Staff of Horror T8
            {0xb0b, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Sword of Acclaim T12
            {0xa47, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Skysplitter Sword T11
            {0xa84, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Achron Sword T10
            {0xa83, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Dragonsoul Sword T9
            {0xa82, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Raven Heart Sword T8
            {0xaff, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Dagger Of Maleovence T12
            {0xa8a, new Tuple<int, CurrencyType>(450, CurrencyType.Gold)}, //Agate Claw Dagger T11
            {0xa89, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Emeraldshard Dagger T10
            {0xa88, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ragetalon Dagger T9
            {0xa19, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Firedagger T8
            {0xc50, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Masamune T12
            {0xc4f, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Murmasa T11
            {0xc4e, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Ichimonj T10
            {0xc4d, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Jewel Eye Katana T9
            {0xc4c, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Demon Edge T8

            //Rings
            {0xabf, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ring of Para Attack T4
            {0xac0, new Tuple<int, CurrencyType>(120, CurrencyType.Gold)}, //Ring of para def T4
            {0xac1, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ring Of Para Spd T4
            {0xac2, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ring Of Para Vit T4
            {0xac3, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ring Of Para Wis T4
            {0xac4, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ring Of Para Dex T4
            {0xac5, new Tuple<int, CurrencyType>(120, CurrencyType.Gold)}, //Ring Of Para health T4
            {0xac6, new Tuple<int, CurrencyType>(120, CurrencyType.Gold)}, //Ring Of Para Magic T4
            {0xac7, new Tuple<int, CurrencyType>(200, CurrencyType.Gold)}, //Ring Of Exaled Att T5
            {0xac8, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Ring Of Exaled Def T5
            {0xac9, new Tuple<int, CurrencyType>(200, CurrencyType.Gold)}, //Ring Of Exaled Spd T5
            {0xaca, new Tuple<int, CurrencyType>(200, CurrencyType.Gold)}, //Ring Of Exaled Vit T5
            {0xacb, new Tuple<int, CurrencyType>(200, CurrencyType.Gold)}, //Ring Of Exaled Wis T5
            {0xacc, new Tuple<int, CurrencyType>(200, CurrencyType.Gold)}, //Ring Of Exaled Dex T5
            {0xacd, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Ring Of Exaled Health T5
            {0xace, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Ring Of Exaled Magic T5
            //ARMORS
            {0xb05, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Robe of The Grand Sorc T13
            {0xa96, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Robe of the Elder Warlock T12
            {0xa95, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //robe of the moon wizard T11
            {0xa94, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Robe of the Shadow Magus T10
            {0xa60, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Robe of the Master T9
            {0xafc, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Acropolis Armor T13
            {0xa93, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Abyssal Armor t12
            {0xa92, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //Vengance Armor T11
            {0xa91, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Desolation Armor T10
            {0xa13, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Dragonscale Armor t9
            {0xaf9, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)}, //Hydra Skin Armor T13
            {0xa90, new Tuple<int, CurrencyType>(300, CurrencyType.Gold)}, //Griffion Hide T12
            {0xa8f, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)}, //HippoGriff Armor t11
            {0xa8e, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Roc Leather Armor T10
            {0xad3, new Tuple<int, CurrencyType>(51, CurrencyType.Gold)}, //Drake Hide Armor T9
     
            //ABILITIES
            {0xb25, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Tome Of Holy Guideance T6
            {0xa5b, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Tome of Divine favor T5
            {0xb22, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Colosuss Shield T6
            {0xa0c, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Mithril Sheild T5
            {0xb24, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Elemental Detonation Spell T6
            {0xa30, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Magic Nova Spell T5
            {0xb26, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Seal of the blessed Champion T6
            {0xa55, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Seal of the Holy Warrior T5
            {0xb27, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Cloak of the Ghostly Consealment T6
            {0xae1, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Cloak of Endless Twilight T5
            {0xb28, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Quiver of Elvish Mastery T6
            {0xa65, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Golden Quiver T5
            {0xb29, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Helm of the Great General T6
            {0xa6b, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Gold Helm T5
            {0xb2a, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //BaneSerpent Poison T6
            {0xaa8, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //NightWing Venom T5
            {0xb2b, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //BloodSucker Skull T6
            {0xaaf, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Life Drinker Skull T5
            {0xb2c, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Giant Catcher Trap T6
            {0xab6, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, // DragonStalker Trap T5
            {0xb2d, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //PlaneFetter Orb T6
            {0xa46, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Banishment Orb T5
            {0xb23, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Prism of Apparations T6
            {0xb20, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Prism of Phantoms T5
            {0xb33, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Secpter of Storms T6
            {0xb32, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Scepter Of Skybolts T5
            {0xc59, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //Doom Circle T6
            {0xc58, new Tuple<int, CurrencyType>(175, CurrencyType.Gold)}, //Ice Star T5

            //PET FOOD

            //EGGS

            //KEYS
            {0x2290, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Bella's Key - just temponary for testing

            {0x701, new Tuple<int, CurrencyType>(75, CurrencyType.Gold)}, //Undead lair key
            {0x705, new Tuple<int, CurrencyType>(50, CurrencyType.Gold)}, //Pirate cave key
            {0x70a, new Tuple<int, CurrencyType>(75, CurrencyType.Gold)}, //Abyss of demons key
            {0x70b, new Tuple<int, CurrencyType>(50, CurrencyType.Gold)}, //Snake pit key
            {0x710, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Tomb of the ancients key
            {0x71f, new Tuple<int, CurrencyType>(75, CurrencyType.Gold)}, //Sprite World Key
            {0xc11, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Ocean Trench Key
            {0xc19, new Tuple<int, CurrencyType>(75, CurrencyType.Gold)}, //Totem Key
            {0xc23, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Manor Key
            {0xc2e, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Daby's Key
            {0xc2f, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)}, //Lab Key
            {0xcce, new Tuple<int, CurrencyType>(125, CurrencyType.Gold)}, //Deadwater docks key
            {0xccf, new Tuple<int, CurrencyType>(125, CurrencyType.Gold)}, //Woodland Labyrinth Key
            {0xcda, new Tuple<int, CurrencyType>(125, CurrencyType.Gold)}, //The crawling depths key
            {0xcdd, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)},//Shatters key



            {0xc6c, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //backpack
            {0x2672, new Tuple<int, CurrencyType>(450, CurrencyType.Gold)},//egg
            {0xc42, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)},//xp
            {0x2609, new Tuple<int, CurrencyType>(25000, CurrencyType.Fame)},//ammy

            
            {0x21a1, new Tuple<int, CurrencyType>(100, CurrencyType.Gold)},//100 g
            {0x21a2, new Tuple<int, CurrencyType>(250, CurrencyType.Gold)},//250 g
            {0x21a3, new Tuple<int, CurrencyType>(500, CurrencyType.Gold)},//500 g
            {0x21a4, new Tuple<int, CurrencyType>(1000, CurrencyType.Gold)},//1000 g
            {0x21a5, new Tuple<int, CurrencyType>(2500, CurrencyType.Gold)},//2500 g
        };

        public static int[] store10List = { 0xc6c };
        public static int[] store11List = { 0x2609 };
        public static int[] store12List = { 0xc42 };
        public static int[] store13List = { 0xc6c };
        public static int[] store14List = { 0xc6c };
        public static int[] store15List = { 0xc6c };
        public static int[] store16List = { 0xc6c
       };
        public static int[] store17List = { 0xc6c };
        public static int[] store18List = { 0xc6c };
        public static int[] store19List = { 0xc6c };

        public static int[] store1List =
        {
            0xcdd, 0xcda, 0xccf, 0xcce, 0xc2f, 0xc2e, 0xc23, 0xc19, 0xc11, 0x71f, 0x710,
             0x70a, 0x705, 0x701, 0x2290
        };

        public static int[] store20List = { 0xcdd };

        //keys need to add etcetc
        public static int[] store2List =
        {
            0x2672
        };

        //pet eggs
        public static int[] store3List = { 0x21a1, 0x21a2, 0x21a3, 0x21a4, 0x21a5 };

        //pet food
        public static int[] store4List =
        {
            0xb25, 0xa5b, 0xb22, 0xa0c, 0xb24, 0xa30, 0xb26, 0xa55, 0xb27, 0xae1, 0xb28,
            0xa65, 0xb29, 0xa6b, 0xb2a, 0xaa8, 0xb2b, 0xaaf, 0xb2c, 0xab6, 0xb2d, 0xa46, 0xb23, 0xb20, 0xb33, 0xb32,
            0xc59, 0xc58
        };

        //abilities
        public static int[] store5List =
        {
            0xb05, 0xa96, 0xa95, 0xa94, 0xa60, 0xafc, 0xa93, 0xa92, 0xa91, 0xa13, 0xaf9,
            0xa90, 0xa8f, 0xa8e, 0xad3
        };

        //armors
        public static int[] store6List =
        {
            0xaf6, 0xa87, 0xa86, 0xa85, 0xa07, 0xb02, 0xa8d, 0xa8c, 0xa8b, 0xa1e, 0xb08,
            0xaa2, 0xaa1, 0xaa0, 0xa9f
        };

        //Wands&staves&bows
        public static int[] store7List =
        {
            0xc42
        };

        //Swords&daggers&samurai shit
        public static int[] store8List =
        {
            0xabf, 0xac0, 0xac1, 0xac2, 0xac3, 0xac4, 0xac5, 0xac6, 0xac7, 0xac8, 0xac9,
            0xaca, 0xacb, 0xacc, 0xacd, 0xace
        };

        // rings
        public static int[] store9List = { 0xcdd };

        private static readonly ILog log = LogManager.GetLogger(typeof(MerchantLists));

        public static void InitMerchatLists(XmlData data)
        {
            log.Info("Loading merchant lists...");
            List<int> accessoryDyeList = new List<int>();
            List<int> clothingDyeList = new List<int>();
            List<int> accessoryClothList = new List<int>();
            List<int> clothingClothList = new List<int>();

            foreach (KeyValuePair<ushort, Item> item in data.Items.Where(_ => noShopCloths.All(i => i != _.Value.ObjectId)))
            {
                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Clothing") && item.Value.Class == "Dye")
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(0, CurrencyType.Fame));
                    clothingDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Accessory") && item.Value.Class == "Dye")
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(0, CurrencyType.Fame));
                    accessoryDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Cloth") &&
                    item.Value.ObjectId.Contains("Large"))
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(25, CurrencyType.Gold));
                    clothingClothList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Cloth") &&
                    item.Value.ObjectId.Contains("Small"))
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(25, CurrencyType.Gold));
                    accessoryClothList.Add(item.Value.ObjectType);
                }
            }

            ClothingDyeList = clothingDyeList.ToArray();
            ClothingClothList = clothingClothList.ToArray();
            AccessoryClothList = accessoryClothList.ToArray();
            AccessoryDyeList = accessoryDyeList.ToArray();
            log.Info("Merchat lists added.");
        }

        private static readonly string[] noShopCloths =
        {
        };
    }
}