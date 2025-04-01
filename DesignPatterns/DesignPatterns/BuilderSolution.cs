using System.Text;

namespace DesignPatterns;
public class BuilderSolution
{
    public class ChairSeat
    {
        public string SeatMaterial { get; set; }
    }

    public class ChairLegs
    {
        public string LegsMaterial { get; set; }
    }

    public class ChairBackrest
    {
        public string BackrestMaterial { get; set; }
    }

    public class Chair
    {
        public ChairSeat ChairSeatMaterial { get; set; }

        public ChairLegs ChairLegsMaterial { get; set; }

        public ChairBackrest ChairBackrestMaterial { get; set; }

        public string ShowInfo()
        {
            Console.WriteLine("\nInformation about chair:");
            StringBuilder sb = new StringBuilder();
            if (ChairSeatMaterial != null)
            {
                sb.Append("Chair seat material: " + ChairSeatMaterial.SeatMaterial+"\n");
            }
            if (ChairLegsMaterial != null)
            {
                sb.Append("Chair legs material: " + ChairLegsMaterial.LegsMaterial+"\n");
            }
            if (ChairBackrestMaterial != null)
            {
                sb.Append("Chair backrest material: " + ChairBackrestMaterial.BackrestMaterial+"\n");
            }
            return sb.ToString();
        }
    }

    public abstract class ChairBuilder
    {
        public Chair Chair { get; set; }

        public void CreateChair()
        {
            Chair = new Chair();
        }
        public abstract void AddChairSeat();

        public abstract void AddLegs();

        public abstract void AddBackrest();
    }

    public class ChairCreator
    {
        public Chair CreateChair(ChairBuilder builder)
        {
            builder.CreateChair();
            builder.AddChairSeat();
            builder.AddLegs();
            builder.AddBackrest();
            return builder.Chair;
        }
    }

    public class ChairWithBackrestBuilder : ChairBuilder
    {
        public override void AddBackrest()
        {
            this.Chair.ChairBackrestMaterial = new ChairBackrest
            {
                BackrestMaterial = "Wood"
            };
        }

        public override void AddChairSeat()
        {
            this.Chair.ChairSeatMaterial = new ChairSeat
            {
                SeatMaterial = "Leather"
            };
        }

        public override void AddLegs()
        {
            this.Chair.ChairLegsMaterial = new ChairLegs
            {
                LegsMaterial = "Wood"
            };
        }
    }

    public class ChairWithoutBackrestBuilder : ChairBuilder
    {
        public override void AddBackrest()
        {
            //not used
        }

        public override void AddChairSeat()
        {
            this.Chair.ChairSeatMaterial = new ChairSeat
            {
                SeatMaterial = "Cotton"
            };
        }

        public override void AddLegs()
        {
            this.Chair.ChairLegsMaterial = new ChairLegs
            {
                LegsMaterial = "Iron"
            };
        }
    }
    public void Execute()
    {
        Console.WriteLine("Builder Solution:");
        ChairCreator chairCreator = new ChairCreator();
        ChairBuilder builder = new ChairWithBackrestBuilder();
        Chair chairWithBackrest = chairCreator.CreateChair(builder);
        Console.WriteLine(chairWithBackrest.ShowInfo());
        builder = new ChairWithoutBackrestBuilder();
        Chair chairWithoutBackrest = chairCreator.CreateChair(builder);
        Console.WriteLine(chairWithoutBackrest.ShowInfo());
    }
}

