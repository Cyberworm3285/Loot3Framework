using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebTest.LootEngine;
using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Classes.Algorithms.TypeFetching;
using Loot3Framework.Interfaces;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SplitItemHandler.Instance.InitLootables(
                    new ILootTypeFetcher<string>[]
                    {
                        //new TypeForwardFetching<string>(typeof(Items.Item), typeof(Items.Item2)),
                        //new TypeForwardFetching<string>(typeof(Items.Item3))
                        new FetchByLootTags<string>("Space"),
                        new FetchByLootTags<string>("Pirate")
                    },
                    new ItemLibraryMode[]
                    {
                        ItemLibraryMode.Space,
                        ItemLibraryMode.Pirates
                    }
                );
            return View();
        }

        [HttpGet]
        public ContentResult Loot()
        {
            string loot = SplitItemHandler.Instance.GetLoot(
                    new RandomLoot<string>()
                ).Item;
            return Content(loot);
        }

        [HttpPost]
        public ContentResult SwitchSplitMode(string newMode)
        {
            if (SplitItemHandler.Instance.TrySwitchMode(newMode))
                return Content("new Mode: " + newMode);
            else
                return Content("Error, could not parse mode: " + newMode);
        }
    }
}
