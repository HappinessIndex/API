using System;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.IO;
using CsvHelper;
using Microsoft.SqlServer.Types;
using SqlServerTypes;

namespace RegionLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RegionDbContext();
            Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            using (TextReader textReader = File.OpenText(@"c:\Users\Rich\wellington4326.csv"))
            {
                var csv = new CsvReader(textReader);
                while (csv.Read())
                {
                    var record = csv.GetRecord<CsvRow>();
                    SqlGeography poly = SqlGeography.Null;
                    switch (record.WKT[0])
                    {
                        case 'P':
                            poly = SqlGeography.STPolyFromText(new SqlChars(record.WKT.ToCharArray()), 4326).MakeValid();
                            break;

                        case 'M':
                            poly = SqlGeography.STMPolyFromText(new SqlChars(record.WKT.ToCharArray()), 4326).MakeValid();
                            break;
                    }
                    if (poly != SqlGeography.Null)
                    {
                        var invertedMp = poly.ReorientObject();
                        if (invertedMp.STArea() < poly.STArea())
                        {
                            poly = invertedMp;
                        }
                        Console.WriteLine(poly.STArea());

                        db.Regions.Add(new Region
                        {
                            Name = record.NAME,
                            AU12 = record.AU12,
                            Polygon = DbGeography.FromBinary(poly.STAsBinary().Value, (int)poly.STSrid),
                        });
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
