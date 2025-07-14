using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDataDb.Migrations
{
    /// <inheritdoc />
    public partial class currency_add_symbol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "AED",
                column: "Symbol",
                value: "AED");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "AFN",
                column: "Symbol",
                value: "Af");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ALL",
                column: "Symbol",
                value: "ALL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "AMD",
                column: "Symbol",
                value: "AMD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ARS",
                column: "Symbol",
                value: "AR$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "AUD",
                column: "Symbol",
                value: "AU$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZN",
                column: "Symbol",
                value: "man.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BAM",
                column: "Symbol",
                value: "KM");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BDT",
                column: "Symbol",
                value: "Tk");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BGN",
                column: "Symbol",
                value: "BGN");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BHD",
                column: "Symbol",
                value: "BD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BIF",
                column: "Symbol",
                value: "FBu");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BND",
                column: "Symbol",
                value: "BN$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BOB",
                column: "Symbol",
                value: "Bs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BRL",
                column: "Symbol",
                value: "R$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BWP",
                column: "Symbol",
                value: "BWP");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BYN",
                column: "Symbol",
                value: "Br");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "BZD",
                column: "Symbol",
                value: "BZ$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CAD",
                column: "Symbol",
                value: "CA$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CDF",
                column: "Symbol",
                value: "CDF");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CHF",
                column: "Symbol",
                value: "CHF");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CLP",
                column: "Symbol",
                value: "CL$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CNY",
                column: "Symbol",
                value: "CN¥");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "COP",
                column: "Symbol",
                value: "CO$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CRC",
                column: "Symbol",
                value: "₡");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CVE",
                column: "Symbol",
                value: "CV$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "CZK",
                column: "Symbol",
                value: "Kč");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "DJF",
                column: "Symbol",
                value: "Fdj");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "DKK",
                column: "Symbol",
                value: "Dkr");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "DOP",
                column: "Symbol",
                value: "RD$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "DZD",
                column: "Symbol",
                value: "DA");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "EEK",
                column: "Symbol",
                value: "Ekr");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "EGP",
                column: "Symbol",
                value: "EGP");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ERN",
                column: "Symbol",
                value: "Nfk");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ETB",
                column: "Symbol",
                value: "Br");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "EUR",
                column: "Symbol",
                value: "€");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "GBP",
                column: "Symbol",
                value: "£");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "GEL",
                column: "Symbol",
                value: "GEL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "GHS",
                column: "Symbol",
                value: "GH₵");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "GNF",
                column: "Symbol",
                value: "FG");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "GTQ",
                column: "Symbol",
                value: "GTQ");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "HKD",
                column: "Symbol",
                value: "HK$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "HNL",
                column: "Symbol",
                value: "HNL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "HRK",
                column: "Symbol",
                value: "kn");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "HUF",
                column: "Symbol",
                value: "Ft");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "IDR",
                column: "Symbol",
                value: "Rp");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ILS",
                column: "Symbol",
                value: "₪");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "INR",
                column: "Symbol",
                value: "Rs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "IQD",
                column: "Symbol",
                value: "IQD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "IRR",
                column: "Symbol",
                value: "IRR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ISK",
                column: "Symbol",
                value: "Ikr");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "JMD",
                column: "Symbol",
                value: "J$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "JOD",
                column: "Symbol",
                value: "JD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "JPY",
                column: "Symbol",
                value: "¥");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KES",
                column: "Symbol",
                value: "Ksh");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KHR",
                column: "Symbol",
                value: "KHR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KMF",
                column: "Symbol",
                value: "CF");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KRW",
                column: "Symbol",
                value: "₩");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KWD",
                column: "Symbol",
                value: "KD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "KZT",
                column: "Symbol",
                value: "KZT");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "LBP",
                column: "Symbol",
                value: "L.L.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "LKR",
                column: "Symbol",
                value: "SLRs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "LTL",
                column: "Symbol",
                value: "Lt");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "LVL",
                column: "Symbol",
                value: "Ls");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "LYD",
                column: "Symbol",
                value: "LD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MAD",
                column: "Symbol",
                value: "MAD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MDL",
                column: "Symbol",
                value: "MDL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MGA",
                column: "Symbol",
                value: "MGA");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MKD",
                column: "Symbol",
                value: "MKD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MMK",
                column: "Symbol",
                value: "MMK");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MOP",
                column: "Symbol",
                value: "MOP$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MUR",
                column: "Symbol",
                value: "MURs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MXN",
                column: "Symbol",
                value: "MX$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MYR",
                column: "Symbol",
                value: "RM");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "MZN",
                column: "Symbol",
                value: "MTn");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NAD",
                column: "Symbol",
                value: "N$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NGN",
                column: "Symbol",
                value: "₦");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NIO",
                column: "Symbol",
                value: "C$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NOK",
                column: "Symbol",
                value: "Nkr");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NPR",
                column: "Symbol",
                value: "NPRs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "NZD",
                column: "Symbol",
                value: "NZ$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "OMR",
                column: "Symbol",
                value: "OMR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PAB",
                column: "Symbol",
                value: "B/.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PEN",
                column: "Symbol",
                value: "S/.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PHP",
                column: "Symbol",
                value: "₱");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PKR",
                column: "Symbol",
                value: "PKRs");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PLN",
                column: "Symbol",
                value: "zł");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "PYG",
                column: "Symbol",
                value: "₲");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "QAR",
                column: "Symbol",
                value: "QR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "RON",
                column: "Symbol",
                value: "RON");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "RSD",
                column: "Symbol",
                value: "din.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "RUB",
                column: "Symbol",
                value: "RUB");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "RWF",
                column: "Symbol",
                value: "RWF");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SAR",
                column: "Symbol",
                value: "SR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SDG",
                column: "Symbol",
                value: "SDG");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SEK",
                column: "Symbol",
                value: "Skr");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SGD",
                column: "Symbol",
                value: "S$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SOS",
                column: "Symbol",
                value: "Ssh");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "SYP",
                column: "Symbol",
                value: "SY£");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "THB",
                column: "Symbol",
                value: "฿");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TND",
                column: "Symbol",
                value: "DT");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TOP",
                column: "Symbol",
                value: "T$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TRY",
                column: "Symbol",
                value: "TL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TTD",
                column: "Symbol",
                value: "TT$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TWD",
                column: "Symbol",
                value: "NT$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "TZS",
                column: "Symbol",
                value: "TSh");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "UAH",
                column: "Symbol",
                value: "₴");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "UGX",
                column: "Symbol",
                value: "USh");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "Symbol",
                value: "$");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "UYU",
                column: "Symbol",
                value: "$U");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "UZS",
                column: "Symbol",
                value: "UZS");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "VEF",
                column: "Symbol",
                value: "Bs.F.");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "VND",
                column: "Symbol",
                value: "₫");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "XAF",
                column: "Symbol",
                value: "FCFA");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "XOF",
                column: "Symbol",
                value: "CFA");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "YER",
                column: "Symbol",
                value: "YR");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ZAR",
                column: "Symbol",
                value: "R");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ZMK",
                column: "Symbol",
                value: "ZK");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencyCode",
                keyValue: "ZWL",
                column: "Symbol",
                value: "ZWL$");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currencies");
        }
    }
}
