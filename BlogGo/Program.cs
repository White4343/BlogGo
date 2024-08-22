namespace BlogGo
{
    // TODO: This Error is not meant to be triggered, but with new .editorconfig settings, it is.
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o => o.CustomSchemaIds(id => id.FullName!.Replace('+', '-')));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run();
        }
    }
}