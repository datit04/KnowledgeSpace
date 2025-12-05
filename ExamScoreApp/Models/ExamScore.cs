namespace ExamScoreApp.Models
{
	public class ExamScore
	{
		public string CandidateName { get; set; }
		public bool IsPolicyFamily { get; set; }
		public string Area { get; set; }
		public double MathScore { get; set; }
		public double PhysicsScore { get; set; }
		public double ChemistryScore { get; set; }
		public double TotalScore { get; set; }
		public string Result { get; set; }
	}
}