using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using WebApi.Entities.BaseEntities;

namespace WebApi.Entities.TagEntities
{
    public class TagsReport : ReportBase<dynamic>
    {
        public TagsReport()
        {
            Total = 10399;
            Records = new Dictionary<DateTime, dynamic>()
            {
                { DateTime.Parse("2024-01-01"), new { Adam = 13, Alex = 26, Chernozub_l = 15, Close_in_progress = 18 } },
                { DateTime.Parse("2024-01-02"), new { Adam = 5 } },
                { DateTime.Parse("2024-01-03"), new { Steven = 18, Suhak_I = 8, Support =  364, TEST = 1, Tesliuk_P = 41, Tovkach_S = 8, Tsos_I = 39, Tymchuk_O = 32 } },
                { DateTime.Parse("2024-01-04"), new { Julian = 23, Kopusyak_V = 41, Kostiuchyk_I =  5, Lily = 12, Limit = 3, Lishchuk_O = 40, Lukomska_D = 18, Mironov_V = 7 } },
                { DateTime.Parse("2024-01-05"), new { Max = 1, Mia = 1 } },
                { DateTime.Parse("2024-01-06"), new { Kopusyak_V = 19, Kostiuchyk_I = 15, Liam =  1 } },
                { DateTime.Parse("2024-01-07"), new { Amelia = 35, Andrew = 1, VIP =  198, Vasylieva_D = 20, Veretelnyk_M = 6, Verification = 17 } },
                { DateTime.Parse("2024-01-08"), new { Withdrawal_general_info = 65, Withdrawal_issue = 21, Yaremenko_Yu = 8, Yevchuk_L = 17, Zhyzhko_V = 13 } },
                { DateTime.Parse("2024-01-09"), new { Support = 364, Tesliuk_P = 3, Tomakh_D = 9, Tsos_I = 24, Tymchuk_O = 7, VIP = 116 } },
                { DateTime.Parse("2024-01-10"), new { Alex = 34, Amy = 5, Babii_B = 11, Badalian_M = 37, Bidnenko_I = 34 } },
                { DateTime.Parse("2024-01-11"), new { Amy = 1, Badalian_M = 37, Bidnenko_I = 27, Bondar_B = 1, Bonus_general_info = 28 } },
                { DateTime.Parse("2024-01-12"), new { Alex = 7, Amy = 7, Babii_B = 10, Badalian_M = 55 } },
                { DateTime.Parse("2024-01-13"), new { Mia = 3, Mironov_V = 13, Morrrigan = 1, NewVip = 1, Nikitina_O = 8, Reopen = 10, Review_Left = 1, Review_Requested = 1, Rudkovskyi_O = 2 } },
                { DateTime.Parse("2024-01-14"), new { Bonus_general_info = 4, Casino_Bonus = 25, Close_in_progress = 3, Closed_PG_01 = 1, Closed_Personal_Reason_03 = 1, Closure = 1 } }
            };
        }
    }
}
