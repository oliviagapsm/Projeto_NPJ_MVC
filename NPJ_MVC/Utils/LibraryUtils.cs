namespace NPJ_MVC.Utils
{
    public class LibraryUtils
    {
        public static string ClearMask(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.Replace("(", "").Replace(")", "").Replace(".", "").Replace("-", "").Replace("/", "").Replace("<", "").Replace(">", "").Replace(":", "").Replace(" ", "").Trim();
            }
            else
            {
                return value;
            }
        }

        public static string MaskTelefone(string nuTelefone)
        {
            nuTelefone = nuTelefone.Replace(" ", string.Empty);

            switch (nuTelefone.Length)
            {
                case 8:
                    return string.Format("{0}-{1}", Mid(nuTelefone, 1, 4), Mid(nuTelefone, 5, 4));
                case 9:
                    return string.Format("{0}-{1}", Mid(nuTelefone, 1, 5), Mid(nuTelefone, 6, 4));
                case 10:
                    return string.Format("({0}) {1}-{2}", Mid(nuTelefone, 1, 2), Mid(nuTelefone, 3, 4), Mid(nuTelefone, 7, 4));
                case 11:
                    return string.Format("({0}) {1}-{2}", Mid(nuTelefone, 1, 2), Mid(nuTelefone, 3, 5), Mid(nuTelefone, 6, 4));
                default:
                    return nuTelefone;
            }
        }
        public static string MaskCPF(string cpf)
        {
            try
            {
                return string.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9, 2));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static bool ValidCPF(string value)
        {

            int d1, d2;
            int soma = 0;
            string digitado;
            string calculado;

            // Pega a string passada no parametro
            string cpf;

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] n = new int[11];

            bool retorno;

            // Limpa a string
            cpf = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "");

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
            {

                return false;
            }

            if (cpf == "11122233355")
            {
                return true;
            }

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {

                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {

                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));

            }
            catch
            {

                return false;
            }


            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
            {

                soma += (peso1[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
            {

                d1 = 0;

            }
            else
            {

                d1 = 11 - resto;
            }

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
            {

                soma += (peso2[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            resto = soma % 11;

            if (resto == 1 || resto == 0)
            {

                d2 = 0;

            }
            else
            {

                d2 = 11 - resto;
            }

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;

        }
        public static string MaskCEP(string cep)
        {
            if (cep != null)
            {
                return string.Format("{0}{1}-{2}", cep.Substring(0, 2), cep.Substring(2, 3), cep.Substring(5, 3));
            }
            else
            {
                return string.Empty;
            }
        }
        private static string Mid(string Str, int Start, int Length)
        {

            if (Length < 0)
                throw new ArgumentException("Argument 'Length' must be greater or equal to zero.", "Length");
            if (Start <= 0)
                throw new ArgumentException("Argument 'Start' must be greater than zero.", "Start");
            if ((Str == null) || (Str.Length == 0))
                return String.Empty; // VB.net does this.

            if ((Length == 0) || (Start > Str.Length))
                return String.Empty;

            if (Length > (Str.Length - Start))
                Length = (Str.Length - Start) + 1;

            return Str.Substring(Start - 1, Length);

        }
    }
}
