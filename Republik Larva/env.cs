using DotNetEnv;

class EnvLoader
{
    public static string Nama_Email { get; private set; }
    public static string Email { get; private set; }
    public static string Token_Email { get; private set; }

    public static void LoadEnvironmentVariables()
    {
        Env.Load();
        Nama_Email = Env.GetString("NAMA_EMAIL");
        Email = Env.GetString("EMAIL");
        Token_Email = Env.GetString("TOKEN_SMTP");
    }
}
