

public class GetIntService
{
    private static int time;
    private static int finalResult;

    public static int GetIntFromStrMethod(string str)
    {
        if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('m') == 8 && str.IndexOf('s') != 2)
        {
            string hours = str[str.IndexOf('h')..str.IndexOf('m')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 3600;

            string minutes = str[str.IndexOf('m')..str.IndexOf('s')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            string seconds = str[str.IndexOf('s')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('s') == 8 && str.IndexOf('m') != 2)
        {
            string hours = str[str.IndexOf('h')..str.IndexOf('s')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 3600;

            string minutes = str[str.IndexOf('s')..str.IndexOf('m')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            string seconds = str[str.IndexOf('m')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('m') == 8 && str.IndexOf('h') != 2)
        {
            string hours = str[str.IndexOf('s')..str.IndexOf('m')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time;

            string minutes = str[str.IndexOf('m')..str.IndexOf('h')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            string seconds = str[str.IndexOf('h')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('h') == 8 && str.IndexOf('m') != 2)
        {
            string hours = str[str.IndexOf('s')..str.IndexOf('h')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time;

            string minutes = str[str.IndexOf('h')..str.IndexOf('m')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            string seconds = str[str.IndexOf('m')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('h') == 8 && str.IndexOf('s') != 2)
        {
            string hours = str[str.IndexOf('m')..str.IndexOf('h')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 60;

            string minutes = str[str.IndexOf('h')..str.IndexOf('s')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            string seconds = str[str.IndexOf('s')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.Contains('s') && str.IndexOf('s') == 8 && str.IndexOf('h') != 2)
        {
            string hours = str[str.IndexOf('m')..str.IndexOf('s')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 60;

            string minutes = str[str.IndexOf('s')..str.IndexOf('h')];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            string seconds = str[str.IndexOf('h')..];
            int.TryParse(string.Join("", seconds.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.IndexOf('m') != 2)
        {
            string hours = str[str.IndexOf('h')..str.IndexOf('m')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 3600;

            string minutes = str[str.IndexOf('m')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('m') && str.IndexOf('m') == 2)
        {
            string hours = str[str.IndexOf('m')..str.IndexOf('h')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 60;

            string minutes = str[str.IndexOf('h')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('s') && str.IndexOf('s') != 2)
        {
            string hours = str[str.IndexOf('h')..str.IndexOf('s')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 3600;

            string minutes = str[str.IndexOf('s')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            return finalResult;
        }

        else if (str.Contains('h') && str.Contains('s') && str.IndexOf('s') == 2)
        {
            string hours = str[str.IndexOf('s')..str.IndexOf('h')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time;

            string minutes = str[str.IndexOf('h')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 3600;

            return finalResult;
        }

        else if (str.Contains('s') && str.Contains('m') && str.IndexOf('m') != 2)
        {
            string hours = str[str.IndexOf('s')..str.IndexOf('m')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time;

            string minutes = str[str.IndexOf('m')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time * 60;

            return finalResult;
        }

        else if (str.Contains('s') && str.Contains('m') && str.IndexOf('m') == 2)
        {
            string hours = str[str.IndexOf('m')..str.IndexOf('s')];
            int.TryParse(string.Join("", hours.Where(c => char.IsDigit(c))), out time);

            finalResult = time * 60;

            string minutes = str[str.IndexOf('s')..];
            int.TryParse(string.Join("", minutes.Where(c => char.IsDigit(c))), out time);

            finalResult += time;

            return finalResult;
        }

        else if(str.Contains('h'))
        {
            int.TryParse(string.Join("", str.Where(c => char.IsDigit(c))), out time);

            return time * 3600;
        }

        else if (str.Contains('m'))
        {
            int.TryParse(string.Join("", str.Where(c => char.IsDigit(c))), out time);

            return time * 60;
        }

        else if (str.Contains('s'))
        {
            int.TryParse(string.Join("", str.Where(c => char.IsDigit(c))), out time);

            return time;
        }

        return -1;
    }
}
