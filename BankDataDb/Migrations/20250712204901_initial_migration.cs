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
                    MinorUnitFractions = table.Column<byte>(type: "INTEGER", nullable: false)
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
                    { "AFG", "AF", "Afghanistan", (short)4 },
                    { "AGO", "AO", "Angola", (short)24 },
                    { "ALB", "AL", "Albania", (short)8 },
                    { "AND", "AD", "Andorra", (short)20 },
                    { "ARE", "AE", "United Arab Emirates", (short)784 },
                    { "ARG", "AR", "Argentina", (short)32 },
                    { "ARM", "AM", "Armenia", (short)51 },
                    { "ATG", "AG", "Antigua and Barbuda", (short)28 },
                    { "AUS", "AU", "Australia", (short)36 },
                    { "AUT", "AT", "Austria", (short)40 },
                    { "AZE", "AZ", "Azerbaijan", (short)31 },
                    { "BDI", "BI", "Burundi", (short)108 },
                    { "BEL", "BE", "Belgium", (short)56 },
                    { "BEN", "BJ", "Benin", (short)204 },
                    { "BFA", "BF", "Burkina Faso", (short)854 },
                    { "BGD", "BD", "Bangladesh", (short)50 },
                    { "BGR", "BG", "Bulgaria", (short)100 },
                    { "BHR", "BH", "Bahrain", (short)48 },
                    { "BHS", "BS", "Bahamas", (short)44 },
                    { "BIH", "BA", "Bosnia and Herzegovina", (short)70 },
                    { "BLR", "BY", "Belarus", (short)112 },
                    { "BLZ", "BZ", "Belize", (short)84 },
                    { "BOL", "BO", "Bolivia, Plurinational State of", (short)68 },
                    { "BRA", "BR", "Brazil", (short)76 },
                    { "BRB", "BB", "Barbados", (short)52 },
                    { "BRN", "BN", "Brunei Darussalam", (short)96 },
                    { "BTN", "BT", "Bhutan", (short)64 },
                    { "BWA", "BW", "Botswana", (short)72 },
                    { "CAF", "CF", "Central African Republic", (short)140 },
                    { "CAN", "CA", "Canada", (short)124 },
                    { "CHE", "CH", "Switzerland", (short)756 },
                    { "CHL", "CL", "Chile", (short)152 },
                    { "CHN", "CN", "China", (short)156 },
                    { "CIV", "CI", "Côte d'Ivoire", (short)384 },
                    { "CMR", "CM", "Cameroon", (short)120 },
                    { "COD", "CD", "Congo, Democratic Republic of the", (short)180 },
                    { "COG", "CG", "Congo", (short)178 },
                    { "COL", "CO", "Colombia", (short)170 },
                    { "COM", "KM", "Comoros", (short)174 },
                    { "CPV", "CV", "Cabo Verde", (short)132 },
                    { "CRI", "CR", "Costa Rica", (short)188 },
                    { "CUB", "CU", "Cuba", (short)192 },
                    { "CYP", "CY", "Cyprus", (short)196 },
                    { "CZE", "CZ", "Czechia", (short)203 },
                    { "DEU", "DE", "Germany", (short)276 },
                    { "DJI", "DJ", "Djibouti", (short)262 },
                    { "DMA", "DM", "Dominica", (short)212 },
                    { "DNK", "DK", "Denmark", (short)208 },
                    { "DOM", "DO", "Dominican Republic", (short)214 },
                    { "DZA", "DZ", "Algeria", (short)12 },
                    { "ECU", "EC", "Ecuador", (short)218 },
                    { "EGY", "EG", "Egypt", (short)818 },
                    { "ERI", "ER", "Eritrea", (short)232 },
                    { "ESP", "ES", "Spain", (short)724 },
                    { "EST", "EE", "Estonia", (short)233 },
                    { "ETH", "ET", "Ethiopia", (short)231 },
                    { "FIN", "FI", "Finland", (short)246 },
                    { "FJI", "FJ", "Fiji", (short)242 },
                    { "FRA", "FR", "France", (short)250 },
                    { "FSM", "FM", "Micronesia, Federated States of", (short)583 },
                    { "GAB", "GA", "Gabon", (short)266 },
                    { "GBR", "GB", "United Kingdom of Great Britain and Northern Ireland", (short)826 },
                    { "GEO", "GE", "Georgia", (short)268 },
                    { "GHA", "GH", "Ghana", (short)288 },
                    { "GIN", "GN", "Guinea", (short)324 },
                    { "GMB", "GM", "Gambia", (short)270 },
                    { "GNB", "GW", "Guinea-Bissau", (short)624 },
                    { "GNQ", "GQ", "Equatorial Guinea", (short)226 },
                    { "GRC", "GR", "Greece", (short)300 },
                    { "GRD", "GD", "Grenada", (short)308 },
                    { "GTM", "GT", "Guatemala", (short)320 },
                    { "GUY", "GY", "Guyana", (short)328 },
                    { "HND", "HN", "Honduras", (short)340 },
                    { "HRV", "HR", "Croatia", (short)191 },
                    { "HTI", "HT", "Haiti", (short)332 },
                    { "HUN", "HU", "Hungary", (short)348 },
                    { "IDN", "ID", "Indonesia", (short)360 },
                    { "IND", "IN", "India", (short)356 },
                    { "IRL", "IE", "Ireland", (short)372 },
                    { "IRN", "IR", "Iran, Islamic Republic of", (short)364 },
                    { "IRQ", "IQ", "Iraq", (short)368 },
                    { "ISL", "IS", "Iceland", (short)352 },
                    { "ISR", "IL", "Israel", (short)376 },
                    { "ITA", "IT", "Italy", (short)380 },
                    { "JAM", "JM", "Jamaica", (short)388 },
                    { "JOR", "JO", "Jordan", (short)400 },
                    { "JPN", "JP", "Japan", (short)392 },
                    { "KAZ", "KZ", "Kazakhstan", (short)398 },
                    { "KEN", "KE", "Kenya", (short)404 },
                    { "KGZ", "KG", "Kyrgyzstan", (short)417 },
                    { "KHM", "KH", "Cambodia", (short)116 },
                    { "KIR", "KI", "Kiribati", (short)296 },
                    { "KNA", "KN", "Saint Kitts and Nevis", (short)659 },
                    { "KOR", "KR", "Korea, Republic of", (short)410 },
                    { "KWT", "KW", "Kuwait", (short)414 },
                    { "LAO", "LA", "Lao People's Democratic Republic", (short)418 },
                    { "LBN", "LB", "Lebanon", (short)422 },
                    { "LBR", "LR", "Liberia", (short)430 },
                    { "LBY", "LY", "Libya", (short)434 },
                    { "LCA", "LC", "Saint Lucia", (short)662 },
                    { "LIE", "LI", "Liechtenstein", (short)438 },
                    { "LKA", "LK", "Sri Lanka", (short)144 },
                    { "LSO", "LS", "Lesotho", (short)426 },
                    { "LTU", "LT", "Lithuania", (short)440 },
                    { "LUX", "LU", "Luxembourg", (short)442 },
                    { "LVA", "LV", "Latvia", (short)428 },
                    { "MAR", "MA", "Morocco", (short)504 },
                    { "MCO", "MC", "Monaco", (short)492 },
                    { "MDA", "MD", "Moldova, Republic of", (short)498 },
                    { "MDG", "MG", "Madagascar", (short)450 },
                    { "MDV", "MV", "Maldives", (short)462 },
                    { "MEX", "MX", "Mexico", (short)484 },
                    { "MHL", "MH", "Marshall Islands", (short)584 },
                    { "MKD", "MK", "North Macedonia", (short)807 },
                    { "MLI", "ML", "Mali", (short)466 },
                    { "MLT", "MT", "Malta", (short)470 },
                    { "MMR", "MM", "Myanmar", (short)104 },
                    { "MNE", "ME", "Montenegro", (short)499 },
                    { "MNG", "MN", "Mongolia", (short)496 },
                    { "MOZ", "MZ", "Mozambique", (short)508 },
                    { "MRT", "MR", "Mauritania", (short)478 },
                    { "MUS", "MU", "Mauritius", (short)480 },
                    { "MWI", "MW", "Malawi", (short)454 },
                    { "MYS", "MY", "Malaysia", (short)458 },
                    { "NAM", "NA", "Namibia", (short)516 },
                    { "NER", "NE", "Niger", (short)562 },
                    { "NGA", "NG", "Nigeria", (short)566 },
                    { "NIC", "NI", "Nicaragua", (short)558 },
                    { "NLD", "NL", "Netherlands", (short)528 },
                    { "NOR", "NO", "Norway", (short)578 },
                    { "NPL", "NP", "Nepal", (short)524 },
                    { "NRU", "NR", "Nauru", (short)520 },
                    { "NZL", "NZ", "New Zealand", (short)554 },
                    { "OMN", "OM", "Oman", (short)512 },
                    { "PAK", "PK", "Pakistan", (short)586 },
                    { "PAN", "PA", "Panama", (short)591 },
                    { "PER", "PE", "Peru", (short)604 },
                    { "PHL", "PH", "Philippines", (short)608 },
                    { "PLW", "PW", "Palau", (short)585 },
                    { "PNG", "PG", "Papua New Guinea", (short)598 },
                    { "POL", "PL", "Poland", (short)616 },
                    { "PRK", "KP", "Korea, Democratic People's Republic of", (short)408 },
                    { "PRT", "PT", "Portugal", (short)620 },
                    { "PRY", "PY", "Paraguay", (short)600 },
                    { "QAT", "QA", "Qatar", (short)634 },
                    { "ROU", "RO", "Romania", (short)642 },
                    { "RUS", "RU", "Russian Federation", (short)643 },
                    { "RWA", "RW", "Rwanda", (short)646 },
                    { "SAU", "SA", "Saudi Arabia", (short)682 },
                    { "SDN", "SD", "Sudan", (short)729 },
                    { "SEN", "SN", "Senegal", (short)686 },
                    { "SGP", "SG", "Singapore", (short)702 },
                    { "SLB", "SB", "Solomon Islands", (short)90 },
                    { "SLE", "SL", "Sierra Leone", (short)694 },
                    { "SLV", "SV", "El Salvador", (short)222 },
                    { "SMR", "SM", "San Marino", (short)674 },
                    { "SOM", "SO", "Somalia", (short)706 },
                    { "SRB", "RS", "Serbia", (short)688 },
                    { "SSD", "SS", "South Sudan", (short)728 },
                    { "STP", "ST", "Sao Tome and Principe", (short)678 },
                    { "SUR", "SR", "Suriname", (short)740 },
                    { "SVK", "SK", "Slovakia", (short)703 },
                    { "SVN", "SI", "Slovenia", (short)705 },
                    { "SWE", "SE", "Sweden", (short)752 },
                    { "SWZ", "SZ", "Eswatini", (short)748 },
                    { "SYC", "SC", "Seychelles", (short)690 },
                    { "SYR", "SY", "Syrian Arab Republic", (short)760 },
                    { "TCD", "TD", "Chad", (short)148 },
                    { "TGO", "TG", "Togo", (short)768 },
                    { "THA", "TH", "Thailand", (short)764 },
                    { "TJK", "TJ", "Tajikistan", (short)762 },
                    { "TKM", "TM", "Turkmenistan", (short)795 },
                    { "TLS", "TL", "Timor-Leste", (short)626 },
                    { "TON", "TO", "Tonga", (short)776 },
                    { "TTO", "TT", "Trinidad and Tobago", (short)780 },
                    { "TUN", "TN", "Tunisia", (short)788 },
                    { "TUR", "TR", "Türkiye", (short)792 },
                    { "TUV", "TV", "Tuvalu", (short)798 },
                    { "TZA", "TZ", "Tanzania, United Republic of", (short)834 },
                    { "UGA", "UG", "Uganda", (short)800 },
                    { "UKR", "UA", "Ukraine", (short)804 },
                    { "URY", "UY", "Uruguay", (short)858 },
                    { "USA", "US", "United States of America", (short)840 },
                    { "UZB", "UZ", "Uzbekistan", (short)860 },
                    { "VCT", "VC", "Saint Vincent and the Grenadines", (short)670 },
                    { "VEN", "VE", "Venezuela, Bolivarian Republic of", (short)862 },
                    { "VNM", "VN", "Viet Nam", (short)704 },
                    { "VUT", "VU", "Vanuatu", (short)548 },
                    { "WSM", "WS", "Samoa", (short)882 },
                    { "YEM", "YE", "Yemen", (short)887 },
                    { "ZAF", "ZA", "South Africa", (short)710 },
                    { "ZMB", "ZM", "Zambia", (short)894 },
                    { "ZWE", "ZW", "Zimbabwe", (short)716 }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyCode", "MinorUnitFractions", "Name" },
                values: new object[,]
                {
                    { "AED", (byte)2, "United Arab Emirates Dirham" },
                    { "AFN", (byte)0, "Afghan Afghani" },
                    { "ALL", (byte)0, "Albanian Lek" },
                    { "AMD", (byte)0, "Armenian Dram" },
                    { "ARS", (byte)2, "Argentine Peso" },
                    { "AUD", (byte)2, "Australian Dollar" },
                    { "AZN", (byte)2, "Azerbaijani Manat" },
                    { "BAM", (byte)2, "Bosnia-Herzegovina Convertible Mark" },
                    { "BDT", (byte)2, "Bangladeshi Taka" },
                    { "BGN", (byte)2, "Bulgarian Lev" },
                    { "BHD", (byte)3, "Bahraini Dinar" },
                    { "BIF", (byte)0, "Burundian Franc" },
                    { "BND", (byte)2, "Brunei Dollar" },
                    { "BOB", (byte)2, "Bolivian Boliviano" },
                    { "BRL", (byte)2, "Brazilian Real" },
                    { "BWP", (byte)2, "Botswanan Pula" },
                    { "BYN", (byte)2, "Belarusian Ruble" },
                    { "BZD", (byte)2, "Belize Dollar" },
                    { "CAD", (byte)2, "Canadian Dollar" },
                    { "CDF", (byte)2, "Congolese Franc" },
                    { "CHF", (byte)2, "Swiss Franc" },
                    { "CLP", (byte)0, "Chilean Peso" },
                    { "CNY", (byte)2, "Chinese Yuan" },
                    { "COP", (byte)0, "Colombian Peso" },
                    { "CRC", (byte)0, "Costa Rican Colón" },
                    { "CVE", (byte)2, "Cape Verdean Escudo" },
                    { "CZK", (byte)2, "Czech Republic Koruna" },
                    { "DJF", (byte)0, "Djiboutian Franc" },
                    { "DKK", (byte)2, "Danish Krone" },
                    { "DOP", (byte)2, "Dominican Peso" },
                    { "DZD", (byte)2, "Algerian Dinar" },
                    { "EEK", (byte)2, "Estonian Kroon" },
                    { "EGP", (byte)2, "Egyptian Pound" },
                    { "ERN", (byte)2, "Eritrean Nakfa" },
                    { "ETB", (byte)2, "Ethiopian Birr" },
                    { "EUR", (byte)2, "Euro" },
                    { "GBP", (byte)2, "British Pound Sterling" },
                    { "GEL", (byte)2, "Georgian Lari" },
                    { "GHS", (byte)2, "Ghanaian Cedi" },
                    { "GNF", (byte)0, "Guinean Franc" },
                    { "GTQ", (byte)2, "Guatemalan Quetzal" },
                    { "HKD", (byte)2, "Hong Kong Dollar" },
                    { "HNL", (byte)2, "Honduran Lempira" },
                    { "HRK", (byte)2, "Croatian Kuna" },
                    { "HUF", (byte)0, "Hungarian Forint" },
                    { "IDR", (byte)0, "Indonesian Rupiah" },
                    { "ILS", (byte)2, "Israeli New Sheqel" },
                    { "INR", (byte)2, "Indian Rupee" },
                    { "IQD", (byte)0, "Iraqi Dinar" },
                    { "IRR", (byte)0, "Iranian Rial" },
                    { "ISK", (byte)0, "Icelandic Króna" },
                    { "JMD", (byte)2, "Jamaican Dollar" },
                    { "JOD", (byte)3, "Jordanian Dinar" },
                    { "JPY", (byte)0, "Japanese Yen" },
                    { "KES", (byte)2, "Kenyan Shilling" },
                    { "KHR", (byte)2, "Cambodian Riel" },
                    { "KMF", (byte)0, "Comorian Franc" },
                    { "KRW", (byte)0, "South Korean Won" },
                    { "KWD", (byte)3, "Kuwaiti Dinar" },
                    { "KZT", (byte)2, "Kazakhstani Tenge" },
                    { "LBP", (byte)0, "Lebanese Pound" },
                    { "LKR", (byte)2, "Sri Lankan Rupee" },
                    { "LTL", (byte)2, "Lithuanian Litas" },
                    { "LVL", (byte)2, "Latvian Lats" },
                    { "LYD", (byte)3, "Libyan Dinar" },
                    { "MAD", (byte)2, "Moroccan Dirham" },
                    { "MDL", (byte)2, "Moldovan Leu" },
                    { "MGA", (byte)0, "Malagasy Ariary" },
                    { "MKD", (byte)2, "Macedonian Denar" },
                    { "MMK", (byte)0, "Myanma Kyat" },
                    { "MOP", (byte)2, "Macanese Pataca" },
                    { "MUR", (byte)0, "Mauritian Rupee" },
                    { "MXN", (byte)2, "Mexican Peso" },
                    { "MYR", (byte)2, "Malaysian Ringgit" },
                    { "MZN", (byte)2, "Mozambican Metical" },
                    { "NAD", (byte)2, "Namibian Dollar" },
                    { "NGN", (byte)2, "Nigerian Naira" },
                    { "NIO", (byte)2, "Nicaraguan Córdoba" },
                    { "NOK", (byte)2, "Norwegian Krone" },
                    { "NPR", (byte)2, "Nepalese Rupee" },
                    { "NZD", (byte)2, "New Zealand Dollar" },
                    { "OMR", (byte)3, "Omani Rial" },
                    { "PAB", (byte)2, "Panamanian Balboa" },
                    { "PEN", (byte)2, "Peruvian Nuevo Sol" },
                    { "PHP", (byte)2, "Philippine Peso" },
                    { "PKR", (byte)0, "Pakistani Rupee" },
                    { "PLN", (byte)2, "Polish Zloty" },
                    { "PYG", (byte)0, "Paraguayan Guarani" },
                    { "QAR", (byte)2, "Qatari Rial" },
                    { "RON", (byte)2, "Romanian Leu" },
                    { "RSD", (byte)0, "Serbian Dinar" },
                    { "RUB", (byte)2, "Russian Ruble" },
                    { "RWF", (byte)0, "Rwandan Franc" },
                    { "SAR", (byte)2, "Saudi Riyal" },
                    { "SDG", (byte)2, "Sudanese Pound" },
                    { "SEK", (byte)2, "Swedish Krona" },
                    { "SGD", (byte)2, "Singapore Dollar" },
                    { "SOS", (byte)0, "Somali Shilling" },
                    { "SYP", (byte)0, "Syrian Pound" },
                    { "THB", (byte)2, "Thai Baht" },
                    { "TND", (byte)3, "Tunisian Dinar" },
                    { "TOP", (byte)2, "Tongan Paʻanga" },
                    { "TRY", (byte)2, "Turkish Lira" },
                    { "TTD", (byte)2, "Trinidad and Tobago Dollar" },
                    { "TWD", (byte)2, "New Taiwan Dollar" },
                    { "TZS", (byte)0, "Tanzanian Shilling" },
                    { "UAH", (byte)2, "Ukrainian Hryvnia" },
                    { "UGX", (byte)0, "Ugandan Shilling" },
                    { "USD", (byte)2, "US Dollar" },
                    { "UYU", (byte)2, "Uruguayan Peso" },
                    { "UZS", (byte)0, "Uzbekistan Som" },
                    { "VEF", (byte)2, "Venezuelan Bolívar" },
                    { "VND", (byte)0, "Vietnamese Dong" },
                    { "XAF", (byte)0, "CFA Franc BEAC" },
                    { "XOF", (byte)0, "CFA Franc BCEAO" },
                    { "YER", (byte)0, "Yemeni Rial" },
                    { "ZAR", (byte)2, "South African Rand" },
                    { "ZMK", (byte)0, "Zambian Kwacha" },
                    { "ZWL", (byte)0, "Zimbabwean Dollar" }
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