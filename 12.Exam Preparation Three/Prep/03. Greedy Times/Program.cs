using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            var itemAndQuantityPairs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, Dictionary<string, long>> ItemTypeQuantoty = new Dictionary<string, Dictionary<string, long>>();

            long totalGoldAmount = 0;
            long totalGemAmount = 0;

            for (int i = 0; i < itemAndQuantityPairs.Length; i += 2)
            {

                string item = itemAndQuantityPairs[i].ToLower();

                long quantity = long.Parse(itemAndQuantityPairs[i + 1]);

                if (item == "gold")
                {

                    var TypeQuantoty = new Dictionary<string, long>();
                    TypeQuantoty[item] = quantity;

                    if (!ItemTypeQuantoty.ContainsKey("Gold"))
                    {
                        if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                        {
                            TypeQuantoty[item] = quantity;
                            ItemTypeQuantoty["Gold"] = TypeQuantoty;
                            bagCapacity -= quantity;
                        }
                    }
                    else
                    {
                        TypeQuantoty = ItemTypeQuantoty["Gold"];

                        if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                        {
                            bagCapacity -= quantity;
                            TypeQuantoty[item] += quantity;
                            ItemTypeQuantoty["Gold"] = TypeQuantoty;
                        }
                    }
                }

                else if (item.EndsWith("gem"))
                {
                    var TypeQuantoty = new Dictionary<string, long>();
                    TypeQuantoty[item] = quantity;

                    if (!ItemTypeQuantoty.ContainsKey("Gem"))
                    {
                        if (ItemTypeQuantoty.ContainsKey("Gold"))
                            totalGoldAmount = ItemTypeQuantoty["Gold"].Values.Sum();

                        if (totalGoldAmount >= quantity)
                        {
                            if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                            {
                                TypeQuantoty[item] = quantity;
                                ItemTypeQuantoty["Gem"] = TypeQuantoty;
                                bagCapacity -= quantity;
                            }
                        }
                    }
                    else
                    {
                        if (!ItemTypeQuantoty["Gem"].ContainsKey(item))
                        {
                            if (ItemTypeQuantoty.ContainsKey("Gold"))
                                totalGoldAmount = ItemTypeQuantoty["Gold"].Values.Sum();

                            if (totalGoldAmount >= ItemTypeQuantoty["Gem"].Values.Sum() + quantity)
                            {
                                if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                                {
                                    ItemTypeQuantoty["Gem"].Add(item, quantity);
                                }
                            }
                        }
                        else
                        {

                            if (ItemTypeQuantoty.ContainsKey("Gold"))
                                totalGoldAmount = ItemTypeQuantoty["Gold"].Values.Sum();

                            if (totalGoldAmount >= ItemTypeQuantoty["Gem"].Values.Sum() + quantity)
                            {
                                if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                                {
                                    bagCapacity -= quantity;
                                    ItemTypeQuantoty["Gem"][item] += quantity;
                                }
                            }
                        }
                    }
                }

                else if (item.Length == 3)
                {
                    item = item.ToUpper();

                    var TypeQuantoty = new Dictionary<string, long>();
					
                    TypeQuantoty[item] = quantity;

                    if (!ItemTypeQuantoty.ContainsKey("Cash"))
                    {
                        if (ItemTypeQuantoty.ContainsKey("Gem"))
                            totalGemAmount = ItemTypeQuantoty["Gem"].Values.Sum();

                        if (totalGemAmount >= quantity)
                        {
                            if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                            {
                                TypeQuantoty[item] = quantity;
                                ItemTypeQuantoty["Cash"] = TypeQuantoty;
                                bagCapacity -= quantity;
                            }
                        }
                    }
                    else
                    {
                        if (!ItemTypeQuantoty["Cash"].ContainsKey(item))
                        {
                            if (ItemTypeQuantoty.ContainsKey("Gem"))
                                totalGemAmount = ItemTypeQuantoty["Gem"].Values.Sum();

                            long totalCashAmount = ItemTypeQuantoty["Cash"].Values.Sum();
                            if (totalGemAmount >= totalCashAmount + quantity)
                            {
                                if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                                {
                                    ItemTypeQuantoty["Cash"].Add(item, quantity);
                                }
                            }
                        }
                        else
                        {
                            if (ItemTypeQuantoty.ContainsKey("Gem"))
                                totalGemAmount = ItemTypeQuantoty["Gem"].Values.Sum();

                            if (totalGemAmount >= ItemTypeQuantoty["Cash"].Values.Sum() + quantity)
                            {
                                if (bagCapacity >= 0 && (bagCapacity - quantity >= 0))
                                {
                                    bagCapacity -= quantity;
                                    ItemTypeQuantoty["Cash"][item] += quantity;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var kvp in ItemTypeQuantoty)
            {
                Console.WriteLine($"<{kvp.Key}> ${kvp.Value.Values.Sum()}");

                foreach (var item in kvp.Value.OrderByDescending(k => k.Key)
                    .ThenBy(kk => kk.Value))
                {
                    string key = Char.ToUpper(item.Key.First()).ToString();
                    key += item.Key.ToString().Substring(1);

                    Console.WriteLine($"##{key} - {item.Value}");
                }
            }
        }
    }
}
