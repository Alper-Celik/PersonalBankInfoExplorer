using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankDataDb.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Alpha3Code = table.Column<string>(type: "TEXT", nullable: false),
                    Alpha2Code = table.Column<string>(type: "TEXT", nullable: false),
                    NumericCode = table.Column<short>(type: "INTEGER", nullable: false),
                    EnglishName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Alpha3Code);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MinorUnitFractions = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CardType = table.Column<int>(type: "varchar(50)", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TransactionTime = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    AmountInMinorUnit = table.Column<long>(type: "INTEGER", nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    CountryAlpha3Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardTransactions_Countries_CountryAlpha3Code",
                        column: x => x.CountryAlpha3Code,
                        principalTable: "Countries",
                        principalColumn: "Alpha3Code");
                    table.ForeignKey(
                        name: "FK_CardTransactions_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Alpha3Code", "Alpha2Code", "EnglishName", "NumericCode" },
                values: new object[,]
                {
                    { "afg", "af", "Afghanistan", (short)4 },
                    { "ago", "ao", "Angola", (short)24 },
                    { "alb", "al", "Albania", (short)8 },
                    { "and", "ad", "Andorra", (short)20 },
                    { "are", "ae", "United Arab Emirates", (short)784 },
                    { "arg", "ar", "Argentina", (short)32 },
                    { "arm", "am", "Armenia", (short)51 },
                    { "atg", "ag", "Antigua and Barbuda", (short)28 },
                    { "aus", "au", "Australia", (short)36 },
                    { "aut", "at", "Austria", (short)40 },
                    { "aze", "az", "Azerbaijan", (short)31 },
                    { "bdi", "bi", "Burundi", (short)108 },
                    { "bel", "be", "Belgium", (short)56 },
                    { "ben", "bj", "Benin", (short)204 },
                    { "bfa", "bf", "Burkina Faso", (short)854 },
                    { "bgd", "bd", "Bangladesh", (short)50 },
                    { "bgr", "bg", "Bulgaria", (short)100 },
                    { "bhr", "bh", "Bahrain", (short)48 },
                    { "bhs", "bs", "Bahamas", (short)44 },
                    { "bih", "ba", "Bosnia and Herzegovina", (short)70 },
                    { "blr", "by", "Belarus", (short)112 },
                    { "blz", "bz", "Belize", (short)84 },
                    { "bol", "bo", "Bolivia, Plurinational State of", (short)68 },
                    { "bra", "br", "Brazil", (short)76 },
                    { "brb", "bb", "Barbados", (short)52 },
                    { "brn", "bn", "Brunei Darussalam", (short)96 },
                    { "btn", "bt", "Bhutan", (short)64 },
                    { "bwa", "bw", "Botswana", (short)72 },
                    { "caf", "cf", "Central African Republic", (short)140 },
                    { "can", "ca", "Canada", (short)124 },
                    { "che", "ch", "Switzerland", (short)756 },
                    { "chl", "cl", "Chile", (short)152 },
                    { "chn", "cn", "China", (short)156 },
                    { "civ", "ci", "Côte d'Ivoire", (short)384 },
                    { "cmr", "cm", "Cameroon", (short)120 },
                    { "cod", "cd", "Congo, Democratic Republic of the", (short)180 },
                    { "cog", "cg", "Congo", (short)178 },
                    { "col", "co", "Colombia", (short)170 },
                    { "com", "km", "Comoros", (short)174 },
                    { "cpv", "cv", "Cabo Verde", (short)132 },
                    { "cri", "cr", "Costa Rica", (short)188 },
                    { "cub", "cu", "Cuba", (short)192 },
                    { "cyp", "cy", "Cyprus", (short)196 },
                    { "cze", "cz", "Czechia", (short)203 },
                    { "deu", "de", "Germany", (short)276 },
                    { "dji", "dj", "Djibouti", (short)262 },
                    { "dma", "dm", "Dominica", (short)212 },
                    { "dnk", "dk", "Denmark", (short)208 },
                    { "dom", "do", "Dominican Republic", (short)214 },
                    { "dza", "dz", "Algeria", (short)12 },
                    { "ecu", "ec", "Ecuador", (short)218 },
                    { "egy", "eg", "Egypt", (short)818 },
                    { "eri", "er", "Eritrea", (short)232 },
                    { "esp", "es", "Spain", (short)724 },
                    { "est", "ee", "Estonia", (short)233 },
                    { "eth", "et", "Ethiopia", (short)231 },
                    { "fin", "fi", "Finland", (short)246 },
                    { "fji", "fj", "Fiji", (short)242 },
                    { "fra", "fr", "France", (short)250 },
                    { "fsm", "fm", "Micronesia, Federated States of", (short)583 },
                    { "gab", "ga", "Gabon", (short)266 },
                    { "gbr", "gb", "United Kingdom of Great Britain and Northern Ireland", (short)826 },
                    { "geo", "ge", "Georgia", (short)268 },
                    { "gha", "gh", "Ghana", (short)288 },
                    { "gin", "gn", "Guinea", (short)324 },
                    { "gmb", "gm", "Gambia", (short)270 },
                    { "gnb", "gw", "Guinea-Bissau", (short)624 },
                    { "gnq", "gq", "Equatorial Guinea", (short)226 },
                    { "grc", "gr", "Greece", (short)300 },
                    { "grd", "gd", "Grenada", (short)308 },
                    { "gtm", "gt", "Guatemala", (short)320 },
                    { "guy", "gy", "Guyana", (short)328 },
                    { "hnd", "hn", "Honduras", (short)340 },
                    { "hrv", "hr", "Croatia", (short)191 },
                    { "hti", "ht", "Haiti", (short)332 },
                    { "hun", "hu", "Hungary", (short)348 },
                    { "idn", "id", "Indonesia", (short)360 },
                    { "ind", "in", "India", (short)356 },
                    { "irl", "ie", "Ireland", (short)372 },
                    { "irn", "ir", "Iran, Islamic Republic of", (short)364 },
                    { "irq", "iq", "Iraq", (short)368 },
                    { "isl", "is", "Iceland", (short)352 },
                    { "isr", "il", "Israel", (short)376 },
                    { "ita", "it", "Italy", (short)380 },
                    { "jam", "jm", "Jamaica", (short)388 },
                    { "jor", "jo", "Jordan", (short)400 },
                    { "jpn", "jp", "Japan", (short)392 },
                    { "kaz", "kz", "Kazakhstan", (short)398 },
                    { "ken", "ke", "Kenya", (short)404 },
                    { "kgz", "kg", "Kyrgyzstan", (short)417 },
                    { "khm", "kh", "Cambodia", (short)116 },
                    { "kir", "ki", "Kiribati", (short)296 },
                    { "kna", "kn", "Saint Kitts and Nevis", (short)659 },
                    { "kor", "kr", "Korea, Republic of", (short)410 },
                    { "kwt", "kw", "Kuwait", (short)414 },
                    { "lao", "la", "Lao People's Democratic Republic", (short)418 },
                    { "lbn", "lb", "Lebanon", (short)422 },
                    { "lbr", "lr", "Liberia", (short)430 },
                    { "lby", "ly", "Libya", (short)434 },
                    { "lca", "lc", "Saint Lucia", (short)662 },
                    { "lie", "li", "Liechtenstein", (short)438 },
                    { "lka", "lk", "Sri Lanka", (short)144 },
                    { "lso", "ls", "Lesotho", (short)426 },
                    { "ltu", "lt", "Lithuania", (short)440 },
                    { "lux", "lu", "Luxembourg", (short)442 },
                    { "lva", "lv", "Latvia", (short)428 },
                    { "mar", "ma", "Morocco", (short)504 },
                    { "mco", "mc", "Monaco", (short)492 },
                    { "mda", "md", "Moldova, Republic of", (short)498 },
                    { "mdg", "mg", "Madagascar", (short)450 },
                    { "mdv", "mv", "Maldives", (short)462 },
                    { "mex", "mx", "Mexico", (short)484 },
                    { "mhl", "mh", "Marshall Islands", (short)584 },
                    { "mkd", "mk", "North Macedonia", (short)807 },
                    { "mli", "ml", "Mali", (short)466 },
                    { "mlt", "mt", "Malta", (short)470 },
                    { "mmr", "mm", "Myanmar", (short)104 },
                    { "mne", "me", "Montenegro", (short)499 },
                    { "mng", "mn", "Mongolia", (short)496 },
                    { "moz", "mz", "Mozambique", (short)508 },
                    { "mrt", "mr", "Mauritania", (short)478 },
                    { "mus", "mu", "Mauritius", (short)480 },
                    { "mwi", "mw", "Malawi", (short)454 },
                    { "mys", "my", "Malaysia", (short)458 },
                    { "nam", "na", "Namibia", (short)516 },
                    { "ner", "ne", "Niger", (short)562 },
                    { "nga", "ng", "Nigeria", (short)566 },
                    { "nic", "ni", "Nicaragua", (short)558 },
                    { "nld", "nl", "Netherlands", (short)528 },
                    { "nor", "no", "Norway", (short)578 },
                    { "npl", "np", "Nepal", (short)524 },
                    { "nru", "nr", "Nauru", (short)520 },
                    { "nzl", "nz", "New Zealand", (short)554 },
                    { "omn", "om", "Oman", (short)512 },
                    { "pak", "pk", "Pakistan", (short)586 },
                    { "pan", "pa", "Panama", (short)591 },
                    { "per", "pe", "Peru", (short)604 },
                    { "phl", "ph", "Philippines", (short)608 },
                    { "plw", "pw", "Palau", (short)585 },
                    { "png", "pg", "Papua New Guinea", (short)598 },
                    { "pol", "pl", "Poland", (short)616 },
                    { "prk", "kp", "Korea, Democratic People's Republic of", (short)408 },
                    { "prt", "pt", "Portugal", (short)620 },
                    { "pry", "py", "Paraguay", (short)600 },
                    { "qat", "qa", "Qatar", (short)634 },
                    { "rou", "ro", "Romania", (short)642 },
                    { "rus", "ru", "Russian Federation", (short)643 },
                    { "rwa", "rw", "Rwanda", (short)646 },
                    { "sau", "sa", "Saudi Arabia", (short)682 },
                    { "sdn", "sd", "Sudan", (short)729 },
                    { "sen", "sn", "Senegal", (short)686 },
                    { "sgp", "sg", "Singapore", (short)702 },
                    { "slb", "sb", "Solomon Islands", (short)90 },
                    { "sle", "sl", "Sierra Leone", (short)694 },
                    { "slv", "sv", "El Salvador", (short)222 },
                    { "smr", "sm", "San Marino", (short)674 },
                    { "som", "so", "Somalia", (short)706 },
                    { "srb", "rs", "Serbia", (short)688 },
                    { "ssd", "ss", "South Sudan", (short)728 },
                    { "stp", "st", "Sao Tome and Principe", (short)678 },
                    { "sur", "sr", "Suriname", (short)740 },
                    { "svk", "sk", "Slovakia", (short)703 },
                    { "svn", "si", "Slovenia", (short)705 },
                    { "swe", "se", "Sweden", (short)752 },
                    { "swz", "sz", "Eswatini", (short)748 },
                    { "syc", "sc", "Seychelles", (short)690 },
                    { "syr", "sy", "Syrian Arab Republic", (short)760 },
                    { "tcd", "td", "Chad", (short)148 },
                    { "tgo", "tg", "Togo", (short)768 },
                    { "tha", "th", "Thailand", (short)764 },
                    { "tjk", "tj", "Tajikistan", (short)762 },
                    { "tkm", "tm", "Turkmenistan", (short)795 },
                    { "tls", "tl", "Timor-Leste", (short)626 },
                    { "ton", "to", "Tonga", (short)776 },
                    { "tto", "tt", "Trinidad and Tobago", (short)780 },
                    { "tun", "tn", "Tunisia", (short)788 },
                    { "tur", "tr", "Türkiye", (short)792 },
                    { "tuv", "tv", "Tuvalu", (short)798 },
                    { "tza", "tz", "Tanzania, United Republic of", (short)834 },
                    { "uga", "ug", "Uganda", (short)800 },
                    { "ukr", "ua", "Ukraine", (short)804 },
                    { "ury", "uy", "Uruguay", (short)858 },
                    { "usa", "us", "United States of America", (short)840 },
                    { "uzb", "uz", "Uzbekistan", (short)860 },
                    { "vct", "vc", "Saint Vincent and the Grenadines", (short)670 },
                    { "ven", "ve", "Venezuela, Bolivarian Republic of", (short)862 },
                    { "vnm", "vn", "Viet Nam", (short)704 },
                    { "vut", "vu", "Vanuatu", (short)548 },
                    { "wsm", "ws", "Samoa", (short)882 },
                    { "yem", "ye", "Yemen", (short)887 },
                    { "zaf", "za", "South Africa", (short)710 },
                    { "zmb", "zm", "Zambia", (short)894 },
                    { "zwe", "zw", "Zimbabwe", (short)716 }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyCode", "MinorUnitFractions", "Name" },
                values: new object[,]
                {
                    { "AED", 2, "United Arab Emirates Dirham" },
                    { "AFN", 0, "Afghan Afghani" },
                    { "ALL", 0, "Albanian Lek" },
                    { "AMD", 0, "Armenian Dram" },
                    { "ARS", 2, "Argentine Peso" },
                    { "AUD", 2, "Australian Dollar" },
                    { "AZN", 2, "Azerbaijani Manat" },
                    { "BAM", 2, "Bosnia-Herzegovina Convertible Mark" },
                    { "BDT", 2, "Bangladeshi Taka" },
                    { "BGN", 2, "Bulgarian Lev" },
                    { "BHD", 3, "Bahraini Dinar" },
                    { "BIF", 0, "Burundian Franc" },
                    { "BND", 2, "Brunei Dollar" },
                    { "BOB", 2, "Bolivian Boliviano" },
                    { "BRL", 2, "Brazilian Real" },
                    { "BWP", 2, "Botswanan Pula" },
                    { "BYN", 2, "Belarusian Ruble" },
                    { "BZD", 2, "Belize Dollar" },
                    { "CAD", 2, "Canadian Dollar" },
                    { "CDF", 2, "Congolese Franc" },
                    { "CHF", 2, "Swiss Franc" },
                    { "CLP", 0, "Chilean Peso" },
                    { "CNY", 2, "Chinese Yuan" },
                    { "COP", 0, "Colombian Peso" },
                    { "CRC", 0, "Costa Rican Colón" },
                    { "CVE", 2, "Cape Verdean Escudo" },
                    { "CZK", 2, "Czech Republic Koruna" },
                    { "DJF", 0, "Djiboutian Franc" },
                    { "DKK", 2, "Danish Krone" },
                    { "DOP", 2, "Dominican Peso" },
                    { "DZD", 2, "Algerian Dinar" },
                    { "EEK", 2, "Estonian Kroon" },
                    { "EGP", 2, "Egyptian Pound" },
                    { "ERN", 2, "Eritrean Nakfa" },
                    { "ETB", 2, "Ethiopian Birr" },
                    { "EUR", 2, "Euro" },
                    { "GBP", 2, "British Pound Sterling" },
                    { "GEL", 2, "Georgian Lari" },
                    { "GHS", 2, "Ghanaian Cedi" },
                    { "GNF", 0, "Guinean Franc" },
                    { "GTQ", 2, "Guatemalan Quetzal" },
                    { "HKD", 2, "Hong Kong Dollar" },
                    { "HNL", 2, "Honduran Lempira" },
                    { "HRK", 2, "Croatian Kuna" },
                    { "HUF", 0, "Hungarian Forint" },
                    { "IDR", 0, "Indonesian Rupiah" },
                    { "ILS", 2, "Israeli New Sheqel" },
                    { "INR", 2, "Indian Rupee" },
                    { "IQD", 0, "Iraqi Dinar" },
                    { "IRR", 0, "Iranian Rial" },
                    { "ISK", 0, "Icelandic Króna" },
                    { "JMD", 2, "Jamaican Dollar" },
                    { "JOD", 3, "Jordanian Dinar" },
                    { "JPY", 0, "Japanese Yen" },
                    { "KES", 2, "Kenyan Shilling" },
                    { "KHR", 2, "Cambodian Riel" },
                    { "KMF", 0, "Comorian Franc" },
                    { "KRW", 0, "South Korean Won" },
                    { "KWD", 3, "Kuwaiti Dinar" },
                    { "KZT", 2, "Kazakhstani Tenge" },
                    { "LBP", 0, "Lebanese Pound" },
                    { "LKR", 2, "Sri Lankan Rupee" },
                    { "LTL", 2, "Lithuanian Litas" },
                    { "LVL", 2, "Latvian Lats" },
                    { "LYD", 3, "Libyan Dinar" },
                    { "MAD", 2, "Moroccan Dirham" },
                    { "MDL", 2, "Moldovan Leu" },
                    { "MGA", 0, "Malagasy Ariary" },
                    { "MKD", 2, "Macedonian Denar" },
                    { "MMK", 0, "Myanma Kyat" },
                    { "MOP", 2, "Macanese Pataca" },
                    { "MUR", 0, "Mauritian Rupee" },
                    { "MXN", 2, "Mexican Peso" },
                    { "MYR", 2, "Malaysian Ringgit" },
                    { "MZN", 2, "Mozambican Metical" },
                    { "NAD", 2, "Namibian Dollar" },
                    { "NGN", 2, "Nigerian Naira" },
                    { "NIO", 2, "Nicaraguan Córdoba" },
                    { "NOK", 2, "Norwegian Krone" },
                    { "NPR", 2, "Nepalese Rupee" },
                    { "NZD", 2, "New Zealand Dollar" },
                    { "OMR", 3, "Omani Rial" },
                    { "PAB", 2, "Panamanian Balboa" },
                    { "PEN", 2, "Peruvian Nuevo Sol" },
                    { "PHP", 2, "Philippine Peso" },
                    { "PKR", 0, "Pakistani Rupee" },
                    { "PLN", 2, "Polish Zloty" },
                    { "PYG", 0, "Paraguayan Guarani" },
                    { "QAR", 2, "Qatari Rial" },
                    { "RON", 2, "Romanian Leu" },
                    { "RSD", 0, "Serbian Dinar" },
                    { "RUB", 2, "Russian Ruble" },
                    { "RWF", 0, "Rwandan Franc" },
                    { "SAR", 2, "Saudi Riyal" },
                    { "SDG", 2, "Sudanese Pound" },
                    { "SEK", 2, "Swedish Krona" },
                    { "SGD", 2, "Singapore Dollar" },
                    { "SOS", 0, "Somali Shilling" },
                    { "SYP", 0, "Syrian Pound" },
                    { "THB", 2, "Thai Baht" },
                    { "TND", 3, "Tunisian Dinar" },
                    { "TOP", 2, "Tongan Paʻanga" },
                    { "TRY", 2, "Turkish Lira" },
                    { "TTD", 2, "Trinidad and Tobago Dollar" },
                    { "TWD", 2, "New Taiwan Dollar" },
                    { "TZS", 0, "Tanzanian Shilling" },
                    { "UAH", 2, "Ukrainian Hryvnia" },
                    { "UGX", 0, "Ugandan Shilling" },
                    { "USD", 2, "US Dollar" },
                    { "UYU", 2, "Uruguayan Peso" },
                    { "UZS", 0, "Uzbekistan Som" },
                    { "VEF", 2, "Venezuelan Bolívar" },
                    { "VND", 0, "Vietnamese Dong" },
                    { "XAF", 0, "CFA Franc BEAC" },
                    { "XOF", 0, "CFA Franc BCEAO" },
                    { "YER", 0, "Yemeni Rial" },
                    { "ZAR", 2, "South African Rand" },
                    { "ZMK", 0, "Zambian Kwacha" },
                    { "ZWL", 0, "Zimbabwean Dollar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BankId",
                table: "Cards",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_CountryAlpha3Code",
                table: "CardTransactions",
                column: "CountryAlpha3Code");

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_CurrencyCode",
                table: "CardTransactions",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Alpha2Code",
                table: "Countries",
                column: "Alpha2Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Alpha3Code",
                table: "Countries",
                column: "Alpha3Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NumericCode",
                table: "Countries",
                column: "NumericCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyCode",
                table: "Currencies",
                column: "CurrencyCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CardTransactions");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
