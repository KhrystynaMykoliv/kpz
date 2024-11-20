using SQLite;

namespace advertising_agency.Models { 
  public class AdCampaign
  {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string? Name { get; set; }
      public string? TargetAudience { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public decimal Budget { get; set; }
      public decimal SpentAmount { get; set; }
  }

}
