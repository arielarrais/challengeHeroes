namespace Knight.API.Models
{
    public class KnightHeroViewModel
    {
        public KnightHeroViewModel(string nome, int idade, int armas, string atributo, int ataque, double exp)
        {
            Nome = nome;
            Idade = idade;
            Armas = armas;
            Atributo = atributo;
            Ataque = ataque;
            Exp = exp;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Armas { get; set; }
        public string Atributo { get; set; }
        public int Ataque { get; set; }
        public double Exp { get; set; }
    }
}
